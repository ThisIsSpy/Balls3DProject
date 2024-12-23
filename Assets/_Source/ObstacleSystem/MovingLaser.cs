using ScoreSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObstacleSystem
{
    public class MovingLaser : MonoBehaviour
    {
        private Vector3 startingSize;
        public void Construct(ScoreModel model)
        {
            model.OnScore1000Reached += EnlargeLaser;
            startingSize = gameObject.transform.localScale;
        }
        private void EnlargeLaser()
        {
            if(gameObject.transform.localScale.x < 1.75f)
                gameObject.transform.localScale += new Vector3(0.25f,0,0);
            if (gameObject.transform.localScale.y < 1)
                gameObject.transform.localScale += new Vector3(0, 0.2f, 0);
        }
        public void ResetSize()
        {
            gameObject.transform.localScale = startingSize;
        }
    }
}
