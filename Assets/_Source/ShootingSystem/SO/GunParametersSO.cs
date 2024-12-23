using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootingSystem.SO
{
    [CreateAssetMenu(fileName = "GunParametersSO", menuName = "SO/New Gun Parameters SO", order = 2)]
    public class GunParametersSO : ScriptableObject
    {
        [SerializeField] private int maxShots;
        [SerializeField] private int absoluteMaxShots;
        [SerializeField] private float rechargeTime;

        public int MaxShots { get { return maxShots; } }
        public int AbsoluteMaxShots { get { return absoluteMaxShots; } }
        public float RechargeTime { get {  return rechargeTime; } }
    }
    
}
