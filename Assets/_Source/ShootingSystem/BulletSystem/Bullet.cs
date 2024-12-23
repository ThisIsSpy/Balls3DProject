using ScoreSystem.Observer;
using System.Collections.Generic;
using TowerSystem;
using UnityEngine;
using ObstacleSystem;
using Statemachine;
using Statemachine.GameStates;

namespace ShootingSystem.BulletSystem
{
    
    public class Bullet : MonoBehaviour, IObservable
    {
        [SerializeField] private float speed;
        private BulletPool _bulletPool;
        private Rigidbody _rb;
        private List<IObserver> observers;
        private IStatemachine gameStatemachine;

        public void Construct(BulletPool bulletPool, IStatemachine gameStatemachine)
        {
            _bulletPool = bulletPool;
            this.gameStatemachine = gameStatemachine;
            observers = new();
        }
        private void OnEnable()
        {
            if(_rb == null)
            {
                _rb = GetComponent<Rigidbody>();
            }
            _rb.velocity += new Vector3(-speed,0,speed);

        }
        private void OnDisable()
        {
            _bulletPool.ReturnToPool(this);
            _rb.velocity = Vector3.zero;
        }
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.TryGetComponent(out TowerPart part))
            {
                Notify(part.Score);
            }
            if (collision.gameObject.CompareTag("Laser") || collision.gameObject.TryGetComponent(out MovingLaser mLaser))
            {
                gameStatemachine.ChangeState<FailState>();
            }
            this.gameObject.SetActive(false);
        }
        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }
        public void UnregisterObserver(IObserver observer)
        {
            observers.Remove(observer);
        }
        public void Notify(int score)
        {
            foreach(var observer in observers)
            {
                observer.UpdateObject(score);
            }
        }
    }
    
}
