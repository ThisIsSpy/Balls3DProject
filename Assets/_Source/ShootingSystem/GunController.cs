using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootingSystem
{
    public class GunController : MonoBehaviour
    {
        private GunView view;

        public void Construct(GunModel model, GunView view)
        {
            this.view = view;
            model.OnShotFired += InvokeUpdateText;
            InvokeUpdateText();
        }
        public void InvokeShoot()
        {
            view.Shoot();
        }
        public void InvokeUpdateText()
        {
            view.UpdateText();
        }
    }
}