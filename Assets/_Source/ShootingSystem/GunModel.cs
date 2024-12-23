using ScoreSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootingSystem
{
    public class GunModel
    {
        private int maxShots;
        private readonly int absoluteMaxShots;
        private readonly int initialMaxShots;
        private int shots;
        private float rechargeTime;
        public event System.Action OnShotFired;

        public int MaxShots
        {
            get { return maxShots; }
            private set
            {
                if (value <= 0)
                {
                    maxShots = 1;
                }
                else
                {
                    maxShots = value;
                }
            }
        }
        public int AbsoluteMaxShots { get { return absoluteMaxShots; } }
        public int Shots
        {
            get { return shots; }
            set
            {
                if (value < 0)
                {
                    shots = 0;
                }
                else if (value > maxShots)
                {
                    shots = maxShots;
                }
                else if (value > shots)
                {
                    shots = value;
                }
                else
                {
                    shots = value;
                    OnShotFired?.Invoke();
                }
            }
        }
        public float RechargeTime
        {
            get { return rechargeTime; }
            set
            {
                if (value <= 0)
                {
                    rechargeTime = 0.1f;
                }
                else
                {
                    rechargeTime = value;
                }
            }
        }
        public GunModel(int maxShots, int absoluteMaxShots, float rechargeTime, ScoreModel scoreModel)
        {
            MaxShots = maxShots;
            this.absoluteMaxShots = absoluteMaxShots;
            initialMaxShots = maxShots;
            Shots = maxShots;
            RechargeTime = rechargeTime;
            scoreModel.OnScore1000Reached += IncreaseMaxShots;
        }

        private void IncreaseMaxShots()
        {
            if (MaxShots < absoluteMaxShots)
            {
                MaxShots++;
                OnShotFired?.Invoke();
            }
        }
        public void ResetGun()
        {
            maxShots = initialMaxShots;
            shots = maxShots;
            OnShotFired?.Invoke();
        }
    }
}