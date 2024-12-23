using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoundSystem.SO{
    [CreateAssetMenu(fileName = "SFXListSO", menuName = "SO/New SFX List SO", order = 5)]
    public class SFXListSO : ScriptableObject
    {
        [SerializeField] private AudioClip shootSound;
        [SerializeField] private AudioClip shootEmptySound;
        [SerializeField] private AudioClip reloadSound;
        [SerializeField] private AudioClip laserWarningSound;
        [SerializeField] private AudioClip buttonPress;
        [SerializeField] private AudioClip doorOpen;
        [SerializeField] private List<AudioClip> gladosVO;

        public AudioClip ShootSound { get { return shootSound; } }
        public AudioClip ShootEmptySound { get { return shootEmptySound; } }
        public AudioClip ReloadSound { get { return reloadSound; } }
        public AudioClip LaserWarningSound { get { return laserWarningSound; } }
        public AudioClip ButtonPress { get { return buttonPress; } }
        public AudioClip DoorOpen { get { return doorOpen; } }
        public List<AudioClip> GLaDOSVO { get { return gladosVO; } }
    }
    
}
