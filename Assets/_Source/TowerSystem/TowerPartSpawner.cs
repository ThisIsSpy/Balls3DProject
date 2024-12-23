using System.Collections;
using System.Collections.Generic;
using TowerSystem.SO;
using UnityEngine;

namespace TowerSystem
{
    public class TowerPartSpawner : MonoBehaviour
    {
        [SerializeField] private Transform spawnPoint;
        private Vector3 startingSpawnPoint;
        private TowerPartCollectionSO partCollection;
        private TowerPartPool towerPartPool;
        private float spawnDist;

        public void Construct(TowerPartPool towerPartPool, TowerPartCollectionSO partCollection)
        {
            this.towerPartPool = towerPartPool;
            this.partCollection = partCollection;
            this.towerPartPool.OnTowerPartDisabled += OnTowerShrink;
            startingSpawnPoint = spawnPoint.position;
            for(int i = 0; i < this.partCollection.TowerHeight; i++)
            {
                SpawnPart();
            }
        }
        private void SpawnPart()
        {
            if(towerPartPool.TryGetPart(out TowerPart part))
            {
                if(part.enabled == false)
                {
                    part.gameObject.SetActive(true);
                }
                part.transform.position = spawnPoint.position;
                if(spawnDist <= 0)
                {
                    spawnDist = (part.transform.localScale.y * 2) + 0.05f;
                }
                spawnPoint.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y + spawnDist, spawnPoint.position.z);
            }
        }
        private void OnTowerShrink()
        {
            spawnPoint.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y - spawnDist, spawnPoint.position.z);
            SpawnPart();
        }
        private void OnApplicationQuit()
        {
            towerPartPool.OnTowerPartDisabled -= OnTowerShrink;
        }
        public void ResetSpawner()
        {
            towerPartPool.OnTowerPartDisabled -= OnTowerShrink;
            spawnPoint.position = startingSpawnPoint;
        }
    }
}
