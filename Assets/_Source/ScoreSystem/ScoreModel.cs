using ScoreSystem.Observer;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScoreSystem
{
    public class ScoreModel: IObserver
    {
        private int score;
        private int highScore;
        private readonly int startingScore;
        private float thousands;
        public event System.Action OnValueChanged;
        public event System.Action OnScore1000Reached;

        public int Score { get { return score; }
            set
            {
                if (value < 0)
                {
                    score = 0;
                }
                else
                {
                    score = value;
                }
                Thousands = Mathf.Floor((float)score / 1000);
            } 
        }
        public int HighScore { get { return highScore; } 
            private set 
            { 
                if(value < Score)
                {
                    highScore = Score;
                }
                else
                {
                    highScore = value;
                }
            } 
        }
        private float Thousands
        {
            get { return thousands; }
            set
            {
                if (value == thousands) return;
                thousands = value;
                OnScore1000Reached?.Invoke();
            }
        }
        public ScoreModel(int score)
        {
            Score = score;
            highScore = PlayerPrefs.GetInt("HighScore", 0);
            startingScore = score;
        }
        public void UpdateObject(int score)
        {
            Score += score;
            if (highScore<=Score)
            {
                highScore = Score;
                PlayerPrefs.SetInt("HighScore", highScore);
            }
            OnValueChanged?.Invoke();
        }
        public void ResetScore()
        {
            Score = startingScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            OnValueChanged?.Invoke();
        }
    }
    
}
