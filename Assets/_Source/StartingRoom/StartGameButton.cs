using Cinemachine;
using SoundSystem;
using Statemachine;
using Statemachine.GameStates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StartingRoom{
    
    public class StartGameButton : MonoBehaviour
    {
        private AudioClip buttonClick;
        private AudioClip doorOpen;
        private AudioSource sfxSource;
        private Material unhighlightMaterial;
        private Material highlightMaterial;
        private MeshRenderer meshRenderer;
        private IStatemachine gameStatemachine;
        private bool wasClicked;

        public void Construct(AudioClip buttonClick, AudioClip doorOpen, AudioSource sfxSource, Material unhighlightMaterial, Material highlightMaterial, IStatemachine gameStatemachine)
        {
            this.buttonClick = buttonClick;
            this.doorOpen = doorOpen;
            this.sfxSource = sfxSource;
            this.unhighlightMaterial = unhighlightMaterial;
            this.highlightMaterial = highlightMaterial;
            this.gameStatemachine = gameStatemachine;
            meshRenderer = GetComponent<MeshRenderer>();
            wasClicked = false;
        }

        private void OnMouseEnter()
        {
            if (!wasClicked)
                meshRenderer.material = highlightMaterial;
        }
        private void OnMouseExit()
        {
            if (!wasClicked)
                meshRenderer.material = unhighlightMaterial;
        }
        private void OnMouseDown()
        {
            if(!wasClicked)
            {
                sfxSource.PlayOneShot(buttonClick);
                meshRenderer.material = highlightMaterial;
                wasClicked = true;
                sfxSource.PlayOneShot(doorOpen);
                gameStatemachine.ChangeState<MovingState>();
            }
        }
        public void ReturnToStart()
        {
            wasClicked = false;
            meshRenderer.material = unhighlightMaterial;
        }
    }
    
}
