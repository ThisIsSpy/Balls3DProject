using Statemachine.GameStates;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Statemachine{
    
    public class GameStatemachine<T> : IStatemachine where T : GameState
    {
        private readonly Dictionary<Type, T> _states;
        private T _currentState;

        public GameStatemachine(StartState startState, MovingState movingState, GameplayState gameplayState, FailState failState)
        {
            _states = new()
            {
                {typeof(StartState),startState as T },
                {typeof(MovingState),movingState as T },
                {typeof(GameplayState),gameplayState as T },
                {typeof(FailState),failState as T }
            };
            InitStates();
        }
        public void Update()
        {
            _currentState?.Update();
        }
        private void InitStates()
        {
            foreach (var states in _states)
            {
                states.Value.InjectOwner(this);
            }
        }
        public bool ChangeState<T>() where T : GameState
        {
            if (_states.ContainsKey(typeof(T)))
            {
                _currentState?.Exit();
                _currentState = _states[typeof(T)];
                _currentState.Enter();
                return true;
            }
            return false;
        }
    }
    
}
