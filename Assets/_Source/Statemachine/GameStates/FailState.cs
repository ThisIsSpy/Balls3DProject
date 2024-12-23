using Core;
using ObstacleSystem;
using ShootingSystem.BulletSystem;
using ShootingSystem;
using SoundSystem.SO;
using StartingRoom;
using System.Collections;
using System.Collections.Generic;
using TowerSystem;
using UnityEngine;
using SoundSystem;
using Cinemachine;

namespace Statemachine.GameStates
{
    
    public class FailState : GameState
    {
        private readonly AudioSource musicPlayer;
        private readonly MusicListSO musicList;
        private readonly GLaDOSCommentary commentary;
        private readonly Lasers lasers;
        private readonly GunView gunView;
        private readonly List<MovingLaser> movingLaserList;
        private readonly List<MovingLaserCart> movingLaserCartList;
        private readonly InputListener inputListener;
        private readonly StartGameButton startGameButton;
        private readonly TowerPartPool towerPartPool;
        private readonly BulletPool bulletPool;
        private readonly TowerPartSpawner towerPartSpawner;
        private readonly CinemachineDollyCart cameraCart;
        private readonly CinemachineDollyCart doorCart;

        public FailState(AudioSource musicPlayer, MusicListSO musicList, GLaDOSCommentary commentary, Lasers lasers, GunView gunView, List<MovingLaser> movingLaserList, 
            List<MovingLaserCart> movingLaserCartList, InputListener inputListener, StartGameButton startGameButton, TowerPartPool towerPartPool, BulletPool bulletPool, 
            TowerPartSpawner towerPartSpawner, CinemachineDollyCart cameraCart, CinemachineDollyCart doorCart)
        {
            this.musicPlayer = musicPlayer;
            this.musicList = musicList;
            this.commentary = commentary;
            this.lasers = lasers;
            this.gunView = gunView;
            this.movingLaserList = movingLaserList;
            this.movingLaserCartList = movingLaserCartList;
            this.inputListener = inputListener;
            this.startGameButton = startGameButton;
            this.towerPartPool = towerPartPool;
            this.bulletPool = bulletPool;
            this.towerPartSpawner = towerPartSpawner;
            this.cameraCart = cameraCart;
            this.doorCart = doorCart;
        }

        public override void Enter()
        {
            musicPlayer.Stop();
            musicPlayer.PlayOneShot(musicList.Separator);
            commentary.StopQuotes();
            lasers.ResetLasers();
            gunView.ResetGun();
            foreach (var mLaser in movingLaserList)
            {
                mLaser.ResetSize();
            }
            foreach (var cart in movingLaserCartList)
            {
                cart.ResetSpeed();
            }
            inputListener.ToggleInput(false);
            startGameButton.ReturnToStart();
            towerPartPool.ClearPool();
            bulletPool.ClearPool();
            towerPartSpawner.ResetSpawner();
            cameraCart.m_Speed = 2;
            doorCart.m_Speed = -0.88f;
            Owner.ChangeState<StartState>();
        }
    }
    
}
