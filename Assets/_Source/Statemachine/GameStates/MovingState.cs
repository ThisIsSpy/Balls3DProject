using Cinemachine;
using Core;
using ScoreSystem;
using ShootingSystem;
using SoundSystem;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

namespace Statemachine.GameStates{
    
    public class MovingState : GameState
    {
        private readonly GLaDOSCommentary commentary;
        private readonly ScoreModel scoreModel;
        private readonly GunModel gunModel;
        private readonly CinemachineDollyCart cameraCart;
        private readonly CinemachineDollyCart doorCart;

        public MovingState(GLaDOSCommentary commentary, ScoreModel scoreModel, GunModel gunModel, CinemachineDollyCart cameraCart, CinemachineDollyCart doorCart)
        {
            this.commentary = commentary;
            this.scoreModel = scoreModel;
            this.gunModel = gunModel;
            this.cameraCart = cameraCart;
            this.doorCart = doorCart;
        }

        public override void Enter()
        {
            commentary.IntroductionQuote();
            scoreModel.ResetScore();
            gunModel.ResetGun();
            cameraCart.m_Speed = -0.725f;
            doorCart.m_Speed = 0.6f;
        }
    }
    
}
