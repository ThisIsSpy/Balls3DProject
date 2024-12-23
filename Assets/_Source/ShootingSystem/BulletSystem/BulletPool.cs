using ScoreSystem;
using Statemachine;
using System.Collections;
using System.Collections.Generic;
using TowerSystem;
using UnityEngine;

namespace ShootingSystem.BulletSystem
{
    public class BulletPool
    {
        private readonly Queue<Bullet> _bulletPool;
        private readonly List<Bullet> _bullets;
        private readonly GunModel gunModel;

        public Queue<Bullet> BulletQueue { get { return _bulletPool; } private set { } }
        public BulletPool(GunModel gunModel)
        {
            this.gunModel = gunModel;
            _bulletPool = new();
            _bullets = new();
        }
        public void InitPool(Bullet bulletPrefab, IStatemachine gameStatemachine)
        {
            for (int i = 0; i < gunModel.AbsoluteMaxShots; i++)
            {
                Bullet bulletInstance = Object.Instantiate(bulletPrefab);
                bulletInstance.Construct(this, gameStatemachine);
                _bulletPool.Enqueue(bulletInstance);
                _bullets.Add(bulletInstance);
            }
        }
        public bool TryGetBullet(out Bullet bullet)
        {
            bullet = null;
            if (_bulletPool.Count > 0)
            {
                bullet = _bulletPool.Dequeue();
                return true;
            }
            return false;
        }
        public void ReturnToPool(Bullet bullet)
        {
            _bulletPool.Enqueue(bullet);
        }
        public void ClearPool()
        {
            foreach (var part in _bullets)
            {
                Object.Destroy(part.gameObject);
            }
            _bulletPool.Clear();
            _bullets.Clear();
        }
    }
}
