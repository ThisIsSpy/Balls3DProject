using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShootingSystem;

namespace Core
{
    public class InputListener : MonoBehaviour
    {
        private GunController controller;
        private bool inputAllowed;
        private KeyCode shootKey;

        public void Construct(GunController controller, KeyCode shootKey)
        {
            this.controller = controller;
            this.shootKey = shootKey;
        }
        private void Update()
        {
            if(inputAllowed)
                ListenForShootInput();
        }
        private void ListenForShootInput()
        {
            if (Input.GetKeyDown(shootKey))
            {
                controller.InvokeShoot();
            }
        }
        public void ToggleInput(bool toggle)
        {
            inputAllowed = toggle;
        }
    }
}