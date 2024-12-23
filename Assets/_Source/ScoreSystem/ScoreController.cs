using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScoreSystem
{
    
    public class ScoreController : MonoBehaviour
    {
        private ScoreView view;

        public void Construct(ScoreModel model, ScoreView view)
        {
            this.view = view;
            model.OnValueChanged += InvokeUpdateText;
        }
        public void InvokeUpdateText()
        {
            view.UpdateText();
        }
    }
    
}
