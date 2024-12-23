using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoundSystem.SO{

    [CreateAssetMenu(fileName = "MusicListSO", menuName = "SO/New Music List SO", order = 4)]
    public class MusicListSO : ScriptableObject
    {
        [SerializeField] private List<AudioClip> menuMusicList;
        [SerializeField] private List<AudioClip> gameMusicList;
        [SerializeField] private AudioClip separator;

        public List<AudioClip> MenuMusicList { get { return menuMusicList; } }
        public List<AudioClip> GameMusicList { get { return gameMusicList; } }
        public AudioClip Separator { get { return separator; } }
    }
    
}
