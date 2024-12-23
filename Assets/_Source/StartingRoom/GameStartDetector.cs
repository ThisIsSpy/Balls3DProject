using Core;
using Statemachine;
using Statemachine.GameStates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StartingRoom{
    
    public class GameStartDetector : MonoBehaviour
    {
        private IStatemachine gameStatemachine;

        public void Construct(IStatemachine gameStatemachine)
        {
            this.gameStatemachine = gameStatemachine;
        }
        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out Camera cam))
            {
                gameStatemachine.ChangeState<GameplayState>();
            }
        }
    }
    
}
