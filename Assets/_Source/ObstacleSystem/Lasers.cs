using Core;
using ScoreSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObstacleSystem
{
    
    public class Lasers : MonoBehaviour
    {
        private System.Random rnd;
        private ScoreModel model;
        private CoroutineMachine coroutineMachine;
        private AudioSource sfxSource;
        private AudioClip laserWarningSound;
        private bool hasStarted;
        private float randomOffTime;
        private float randomOnTime;

        public void Construct(ScoreModel model, CoroutineMachine coroutineMachine, AudioSource sfxSource, AudioClip laserWarningSound)
        {
            rnd = new();
            this.model = model;
            this.coroutineMachine = coroutineMachine;
            this.sfxSource = sfxSource;
            this.laserWarningSound = laserWarningSound;
            hasStarted = false;
            this.model.OnScore1000Reached += StartTheLasers;
        }
        private IEnumerator LaserCoroutine(GameObject lasers)
        {
            yield return new WaitForSeconds(randomOffTime-1);
            sfxSource.PlayOneShot(laserWarningSound);
            yield return new WaitForSeconds(1);
            lasers.SetActive(true);
            yield return new WaitForSeconds(randomOnTime);
            lasers.SetActive(false);
            coroutineMachine.StartTheCoroutine(LaserCoroutine(gameObject));
        }
        private void StartTheLasers()
        {
            if(!hasStarted)
            {
                coroutineMachine.StartTheCoroutine(LaserCoroutine(gameObject));
                hasStarted = true;
            }
            randomOffTime = rnd.Next(5, 36)-(model.Score/10000);
            randomOnTime = rnd.Next(1, 4)+(model.Score/10000);
            if(randomOffTime < 1)
            {
                randomOffTime = 1;
            }
        }
        public void ResetLasers()
        {
            StopAllCoroutines();
            coroutineMachine.StopCoroutine(LaserCoroutine(gameObject));
            coroutineMachine.StopAllCoroutines();
            gameObject.SetActive(false);
        }
    }
}
