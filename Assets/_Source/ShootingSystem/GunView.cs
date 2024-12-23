using ShootingSystem.BulletSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ShootingSystem
{
    public class GunView : MonoBehaviour
    {
        private GunModel model;
        private BulletPool bulletPool;
        private Transform firePoint;
        private AudioSource sfxSource;
        private AudioClip shootSound;
        private AudioClip shootEmptySound;
        private AudioClip reloadSound;
        private TextMeshPro ammoCountText;
        public void Construct(GunModel model, BulletPool bulletPool, Transform firePoint, AudioSource sfxSource, AudioClip shootSound, AudioClip shootEmptySound, AudioClip reloadSound, TextMeshPro ammoCountText)
        {
            this.model = model;
            this.bulletPool = bulletPool;
            this.firePoint = firePoint;
            this.sfxSource = sfxSource;
            this.shootSound = shootSound;
            this.shootEmptySound = shootEmptySound;
            this.reloadSound = reloadSound;
            this.ammoCountText = ammoCountText;
            this.model.OnShotFired += RechargeShot;
        }
        private IEnumerator ShotRechargeCoroutine()
        {
            if (model.Shots == model.MaxShots) yield break;
            yield return new WaitForSeconds(model.RechargeTime);
            model.Shots++;
            sfxSource.PlayOneShot(reloadSound);
            UpdateText();
        }
        public void Shoot()
        {
            if (model.Shots > 0)
            {
                if (bulletPool.TryGetBullet(out var bullet))
                {
                    bullet.transform.position = firePoint.position;
                    bullet.gameObject.SetActive(true);
                    sfxSource.PlayOneShot(shootSound);
                    model.Shots--;
                }
            }
            else
            {
                sfxSource.PlayOneShot(shootEmptySound);
            }
        }
        private void RechargeShot()
        {
            StartCoroutine(ShotRechargeCoroutine());
        }
        public void UpdateText()
        {
            ammoCountText.text = $"{model.Shots}/{model.MaxShots}";
        }
        public void ResetGun()
        {
            StopAllCoroutines();
        }
    }
}