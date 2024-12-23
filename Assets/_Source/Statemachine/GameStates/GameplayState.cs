using Core;
using ScoreSystem;
using ShootingSystem.BulletSystem;
using SoundSystem;
using SoundSystem.SO;
using System.Collections;
using System.Collections.Generic;
using TowerSystem;
using TowerSystem.SO;
using Unity.VisualScripting;
using UnityEngine;

namespace Statemachine.GameStates
{
    
    public class GameplayState : GameState
    {
        private readonly InputListener inputListener;
        private readonly AudioSource musicPlayer;
        private readonly MusicListSO musicList;
        private readonly GLaDOSCommentary commentary;
        private readonly BulletPool bulletPool;
        private readonly Bullet bulletPrefab;
        private readonly TowerPartPool towerPartPool;
        private readonly TowerPartCollectionSO partCollection;
        private readonly TowerPartSpawner towerPartSpawner;
        private readonly ScoreModel scoreModel;
        private readonly System.Random rnd;

        public GameplayState(InputListener inputListener, AudioSource musicPlayer, MusicListSO musicList, GLaDOSCommentary commentary, BulletPool bulletPool, 
            Bullet bulletPrefab, TowerPartPool towerPartPool, TowerPartCollectionSO partCollection, 
            TowerPartSpawner towerPartSpawner, ScoreModel scoreModel, System.Random rnd)
        {
            this.inputListener = inputListener;
            this.musicPlayer = musicPlayer;
            this.musicList = musicList;
            this.commentary = commentary;
            this.bulletPool = bulletPool;
            this.bulletPrefab = bulletPrefab;
            this.towerPartPool = towerPartPool;
            this.partCollection = partCollection;
            this.towerPartSpawner = towerPartSpawner;
            this.scoreModel = scoreModel;
            this.rnd = rnd;
        }
        public override void Enter()
        {
            inputListener.ToggleInput(true);
            musicPlayer.Stop();
            musicPlayer.PlayOneShot(musicList.Separator);
            commentary.StartRandomQuotes();
            bulletPool.InitPool(bulletPrefab, Owner);
            towerPartPool.InitPool(partCollection);
            towerPartSpawner.Construct(towerPartPool, partCollection);
            foreach (var bullet in bulletPool.BulletQueue)
            {
                bullet.RegisterObserver(scoreModel);
            }
            musicPlayer.clip = musicList.GameMusicList[rnd.Next(0, musicList.GameMusicList.Count)];
            musicPlayer.Play();
        }
    }
    
}
