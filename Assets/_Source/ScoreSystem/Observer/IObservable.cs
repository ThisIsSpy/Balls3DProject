using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScoreSystem.Observer
{
    public interface IObservable
    {
        public void RegisterObserver(IObserver observer);
        public void UnregisterObserver(IObserver observer);
        public void Notify(int score);
    }
}
