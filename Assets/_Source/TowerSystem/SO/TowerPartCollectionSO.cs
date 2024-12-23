using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerSystem.SO
{
    [CreateAssetMenu(fileName = "TowerPartCollectionSO", menuName = "SO/New Tower Part Collection SO", order = 3)]
    public class TowerPartCollectionSO : ScriptableObject
    {
        [SerializeField] private List<TowerPart> partList;
        [SerializeField] private int towerHeight;

        public List<TowerPart> PartList { get { return partList; } }
        public int TowerHeight { get { return towerHeight; } }
    }
    
}
