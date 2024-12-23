using Core;
using SoundSystem.SO;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Statemachine.GameStates
{
    
    public class StartState : GameState
    {
        private readonly AudioSource musicPlayer;
        private readonly MusicListSO musicList;
        private readonly System.Random rnd;

        public StartState(AudioSource musicPlayer, MusicListSO musicList, System.Random rnd)
        {
            this.musicPlayer = musicPlayer;
            this.musicList = musicList;
            this.rnd = rnd;
        }

        public override void Enter()
        {
            musicPlayer.clip = musicList.MenuMusicList[rnd.Next(0, musicList.MenuMusicList.Count)];
            musicPlayer.Play();
        }
    }
    
}
