using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShootingSystem;
using ShootingSystem.BulletSystem;
using ScoreSystem;
using TMPro;
using ShootingSystem.SO;
using TowerSystem.SO;
using TowerSystem;
using ObstacleSystem;
using SoundSystem.SO;
using StartingRoom;
using Statemachine;
using Statemachine.GameStates;
using Cinemachine;
using SoundSystem;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private GunParametersSO gunParameters;
        [SerializeField] private TowerPartCollectionSO partCollection;
        [SerializeField] private MusicListSO musicList;
        [SerializeField] private SFXListSO sfxList;
        [SerializeField] private TowerPartSpawner towerPartSpawner;
        [SerializeField] private int startingScore;
        [SerializeField] private InputListener inputListener;
        [SerializeField] private GameObject gun;
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private TextMeshPro scoreText;
        [SerializeField] private TextMeshPro highScoreText;
        [SerializeField] private TextMeshPro ammoCountText;
        [SerializeField] private TextMeshPro shootKeyHint;
        [SerializeField] private Lasers lasers;
        [SerializeField] private CoroutineMachine coroutineMachine;
        [SerializeField] private List<MovingLaser> movingLaserList;
        [SerializeField] private List<MovingLaserCart> movingLaserCartList;
        [SerializeField] private AudioSource musicPlayer;
        [SerializeField] private AudioSource sfxPlayer;
        [SerializeField] private GameStartDetector gameStartDetector;
        [SerializeField] private Material unhighlightMaterial;
        [SerializeField] private Material highlightMaterial;
        [SerializeField] private CinemachineDollyCart cameraCart;
        [SerializeField] private CinemachineDollyCart doorCart;
        [SerializeField] private GLaDOSCommentary commentary;
        [SerializeField] private StartGameButton startGameButton;
        [SerializeField] private KeyCode shootKey;
        private IStatemachine gameStatemachine;
        private GunModel gunModel;
        private GunView gunView;
        private GunController gunController;
        private ScoreModel scoreModel;
        private ScoreView scoreView;
        private ScoreController scoreController;
        private Transform shootingPoint;
        private BulletPool bulletPool;
        private TowerPartPool towerPartPool;
        private System.Random rnd;

        public IStatemachine GameStatemachine { get { return gameStatemachine; } }

        private void Start()
        {
            inputListener.ToggleInput(false);
            rnd = new();

            scoreModel = new(startingScore);
            gunModel = new(gunParameters.MaxShots, gunParameters.AbsoluteMaxShots, gunParameters.RechargeTime, scoreModel);
            bulletPool = new(gunModel);
            towerPartPool = new(partCollection);

            gunView = gun.GetComponent<GunView>();
            gunController = gun.GetComponent<GunController>();
            scoreView = scoreText.GetComponent<ScoreView>();
            scoreController = scoreText.GetComponent<ScoreController>();
            shootingPoint = GameObject.FindWithTag("ShootingPoint").GetComponent<Transform>();

            StartState startState = new(musicPlayer, musicList, rnd);
            MovingState movingState = new(commentary, scoreModel, gunModel, cameraCart, doorCart);
            GameplayState gameplayState = new(inputListener, musicPlayer, musicList, commentary, bulletPool, bulletPrefab, towerPartPool, partCollection, towerPartSpawner, scoreModel, rnd);
            FailState failState = new(musicPlayer, musicList, commentary, lasers, gunView, movingLaserList, movingLaserCartList, inputListener, startGameButton, towerPartPool, bulletPool, towerPartSpawner, cameraCart, doorCart);
            gameStatemachine = new GameStatemachine<GameState>(startState, movingState, gameplayState, failState);

            gunView.Construct(gunModel, bulletPool, shootingPoint, sfxPlayer, sfxList.ShootSound, sfxList.ShootEmptySound, sfxList.ReloadSound, ammoCountText);
            gunController.Construct(gunModel, gunView);
            scoreView.Construct(scoreModel, scoreText, highScoreText);
            scoreController.Construct(scoreModel, scoreView);
            inputListener.Construct(gunController, shootKey);
            gameStartDetector.Construct(gameStatemachine);
            lasers.Construct(scoreModel, coroutineMachine, sfxPlayer, sfxList.LaserWarningSound);
            commentary.Construct(sfxList.GLaDOSVO, sfxPlayer, rnd);
            startGameButton.Construct(sfxList.ButtonPress, sfxList.DoorOpen, sfxPlayer, unhighlightMaterial, highlightMaterial, gameStatemachine);
            shootKeyHint.text = $"{shootKey}";
            foreach (var mLaser in movingLaserList)
            {
                mLaser.Construct(scoreModel);
            }
            foreach (var cart in movingLaserCartList)
            {
                cart.Construct(scoreModel);
            }
            gameStatemachine.ChangeState<StartState>();
        }
    }
}