using ShootingSystem.BulletSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerSystem
{
    public class TowerPart : MonoBehaviour
    {
        [SerializeField] private int score;
        private TowerPartPool pool;
        public event System.Action OnDisabled;

        public int Score { get { return score; } private set { } }

        public void Construct(TowerPartPool pool)
        {
            this.pool = pool;
        }
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.TryGetComponent(out Bullet bullet))
            {
                OnAttacked();
            }
        }
        private void OnAttacked()
        {
            pool.ReturnToPool(this);
            OnDisabled?.Invoke();
        }
    }
    
}
