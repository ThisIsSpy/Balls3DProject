using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using TMPro;
using UnityEngine;

namespace ScoreSystem{
    
    public class ScoreView : MonoBehaviour
    {
        private ScoreModel model;
        private TextMeshPro scoreText;
        private TextMeshPro highScoreText;

        public void Construct(ScoreModel model, TextMeshPro scoreText, TextMeshPro highScoreText)
        {
            this.model = model;
            this.scoreText = scoreText;
            this.highScoreText = highScoreText;
        }
        public void UpdateText()
        {
            scoreText.text = $"{model.Score}";
            highScoreText.text = $"{model.HighScore}";
        }
    }
    
}
