using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Statemachine{
    
    public interface IStatemachine
    {
        bool ChangeState<T>() where T : GameState;
        public void Update();
    }
    
}
