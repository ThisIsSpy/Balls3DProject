using Cinemachine;
using ScoreSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObstacleSystem
{
    public class MovingLaserCart : MonoBehaviour
    {
        private CinemachineDollyCart dollyCart;
        private float startingSpeed;

        public void Construct(ScoreModel model)
        {
            dollyCart = GetComponent<CinemachineDollyCart>();
            model.OnScore1000Reached += IncreaseSpeed;
            startingSpeed = dollyCart.m_Speed;
        }
        private void IncreaseSpeed()
        {
            dollyCart.m_Speed += 0.5f;
        }
        public void ResetSpeed()
        {
            dollyCart.m_Speed = startingSpeed;
        }
    }
}
