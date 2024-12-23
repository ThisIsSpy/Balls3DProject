using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScoreSystem.Observer
{
    public interface IObserver
    {
        public void UpdateObject(int score);
    }
}