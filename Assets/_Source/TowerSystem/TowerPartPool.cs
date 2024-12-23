using ShootingSystem.BulletSystem;
using System.Collections;
using System.Collections.Generic;
using TowerSystem.SO;
using UnityEngine;

namespace TowerSystem
{
    public class TowerPartPool
    {
        private readonly Queue<TowerPart> towerPartPool;
        private readonly List<TowerPart> towerParts;
        private readonly int towerHeight;
        private readonly System.Random rnd;
        public event System.Action OnTowerPartDisabled;

        public TowerPartPool(TowerPartCollectionSO towerPartCollection)
        {
            towerHeight = towerPartCollection.TowerHeight;
            rnd = new();
            towerPartPool = new();
            towerParts = new();
        }
        public void InitPool(TowerPartCollectionSO towerPartCollection)
        {
            for(int i = 0; i < towerHeight; i++)
            {
                TowerPart part = Object.Instantiate(towerPartCollection.PartList[rnd.Next(0, towerPartCollection.PartList.Count)]);
                part.Construct(this);
                part.OnDisabled += OnDisabledEventRecieved;
                towerPartPool.Enqueue(part);
                towerParts.Add(part);
            }
        }
        public bool TryGetPart(out TowerPart part)
        {
            part = null;
            if (towerPartPool.Count > 0)
            {
                part = towerPartPool.Dequeue();
                return true;
            }
            return false;
        }
        public void ReturnToPool(TowerPart part)
        {
            towerPartPool.Enqueue(part);
        }
        private void OnDisabledEventRecieved()
        {
            OnTowerPartDisabled?.Invoke();
        }
        public void ClearPool()
        {
            foreach(var part in towerParts)
            {
                Object.Destroy(part.gameObject);
                part.OnDisabled -= OnDisabledEventRecieved;
            }
            towerPartPool.Clear();
            towerParts.Clear();
        }
    }
}
