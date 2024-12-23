using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core{
    
    public class CoroutineMachine : MonoBehaviour
    {
        public void StartTheCoroutine(IEnumerator coroutine)
        {
            StartCoroutine(coroutine);
        }
    }
    
}
