using TMPro.Examples;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;

    [Header("Game States")]
    [SerializeField] private GameObject splashScreenState;
    public GameObject SplashScreenState => splashScreenState;

    [SerializeField] private GameObject mainMenuState;
    public GameObject MainMenuState => mainMenuState;

    [SerializeField] private GameObject gameplayState;
    public GameObject GameplayState => gameplayState;

    [SerializeField] private GameObject gameOverState;
    public GameObject GameOverState => gameOverState;

    [SerializeField] private GameObject settingsState;
    public GameObject SettingsState => settingsState;

    [SerializeField] private GameObject creditsState;
    public GameObject CreditsState => creditsState;

    [SerializeField] private GameObject controlsState;
    public GameObject ControlsState => controlsState;


    [Header("Level Data")]
    [SerializeField] private LevelData levelData;
    public LevelData LevelData => levelData;


    [Header("Prefabs")]
    [SerializeField] private GameObject playerPawnPrefab;
    public GameObject PlayerPawnPrefab => playerPawnPrefab;
    
    [SerializeField] private GameObject playerControllerPrefab;
    public GameObject PlayerControllerPrefab => playerControllerPrefab;

    [SerializeField] private GameObject flyEnemyPrefab;
    public GameObject FlyEnemyPrefab => flyEnemyPrefab;

    [SerializeField] private GameObject zoomerEnemyPrefab;
    public GameObject ZoomerEnemyPrefab => zoomerEnemyPrefab;
    
    [SerializeField] private GameObject bombEnemyPrefab;
    public GameObject BombEnemyPrefab => bombEnemyPrefab;
    
    [SerializeField] private GameObject defaultProjectilePrefab;
    public GameObject DefaultProjectilePrefab => defaultProjectilePrefab;
    
    [SerializeField] private GameObject playerProjectilePrefab;
    public GameObject PlayerProjectilePrefab => playerProjectilePrefab;

    [SerializeField] private GameObject enemyProjectilePrefab;
    public GameObject EnemyProjectilePrefab => enemyProjectilePrefab;

    [SerializeField] private GameObject healthPickupPrefab;
    public GameObject HealthPickupPrefab => healthPickupPrefab;

    [SerializeField] private GameObject diamondPrefab;
    public GameObject DiamondPrefab => diamondPrefab;


    [Header("Audio Clips")]
    [SerializeField] private AudioClip mainMenuBackgroundMusic;
    public AudioClip MainMenuBackgroundMusic => mainMenuBackgroundMusic;

    [SerializeField] private AudioClip gameplayBackgroundMusic;
    public AudioClip GameplayBackgroundMusic => gameplayBackgroundMusic;

    [SerializeField] private AudioClip scoreClip;
    public AudioClip ScoreClip => scoreClip;
    
    [SerializeField] private AudioClip healthPickupClip;
    public AudioClip HealthPickupClip => healthPickupClip;

    [SerializeField] private AudioClip playerDamageClip;
    public AudioClip PlayerDamageClip => playerDamageClip;

    [SerializeField] private AudioClip playerDeathClip;
    public AudioClip PlayerDeathClip => playerDeathClip;

    [SerializeField] private AudioClip bombExplosionClip;
    public AudioClip BombExplosionClip => bombExplosionClip;
    
    [SerializeField] private AudioClip flyEnemyDeathClip;
    public AudioClip FlyEnemyDeathClip => flyEnemyDeathClip;

    [SerializeField] private AudioClip zoomerWarningClip;
    public AudioClip ZoomerWarningClip => zoomerWarningClip;


    [Header("Player Settings")]
    [SerializeField] private float playerMaxHealth;
    public float PlayerMaxHealth => playerMaxHealth;

    [SerializeField] private float playerStartingLives;
    public float PlayerStartingLives => playerStartingLives;

    [SerializeField] private float playerShootRate;
    public float PlayerShootRate => playerShootRate;

    [SerializeField] private float playerMoveSpeed;
    public float PlayerMoveSpeed => playerMoveSpeed;

    [SerializeField] private float playerJumpHeight;
    public float PlayerJumpHeight => playerJumpHeight;


    [Header("Fly Enemy Settings")]
    [SerializeField] private float flyMaxHealth;
    public float FlyMaxHealth => flyMaxHealth;

    [SerializeField] private float flyShootRate;
    public float FlyShootRate => flyShootRate;

    [SerializeField] private float flyMoveSpeed;
    public float FlyMoveSpeed => flyMoveSpeed;


    [Header("Zoomer Enemy Settings")]
    [SerializeField] private float zoomerMoveSpeed;
    public float ZoomerMoveSpeed => zoomerMoveSpeed;


    [Header("Bomb Settings")]
    [SerializeField] private float bombMaxDamage;
    public float BombMaxDamage => bombMaxDamage;

    [SerializeField] private float bombMoveSpeed;
    public float BombMoveSpeed => bombMoveSpeed;


    [Header("Projectile Settings")]
    [SerializeField] private float defaultProjectileSpeed;
    public float DefaultProjectileSpeed => defaultProjectileSpeed;

    [SerializeField] private float defaultProjectileLifetime;
    public float DefaultProjectileLifetime => defaultProjectileLifetime;

    [Header("Health Pickup Settings")]
    [SerializeField] private float healAmount;
    public float HealAmount => healAmount;


    [Header("Score Value Settings")]
    [SerializeField] private float flyEnemyScore;
    public float FlyEnemyScore => flyEnemyScore;

    [SerializeField] private float bombEnemyScore;
    public float BombEnemyScore => bombEnemyScore;

    [SerializeField] private float zoomerEnemyScore;
    public float ZoomerEnemyScore => zoomerEnemyScore;

    [SerializeField] private float diamondScore;
    public float DiamondScore => diamondScore;

    [Header("Score Tracker")]
    [SerializeField] private float score;
    public float Score => score;

    [SerializeField] private float highScore;
    public float HighScore => highScore;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        ShowSplashScreen();
    }

    public void ShowSplashScreen()
    {
        splashScreenState.SetActive(true);
        mainMenuState.SetActive(false);
        gameplayState.SetActive(false);
        gameOverState.SetActive(false);
        creditsState.SetActive(false);
        controlsState.SetActive(false);
        settingsState.SetActive(false);
    }

    public void ShowMainMenu()
    {
        splashScreenState.SetActive(false);
        mainMenuState.SetActive(true);
        gameplayState.SetActive(false);
        gameOverState.SetActive(false);
        creditsState.SetActive(false);
        controlsState.SetActive(false);
        settingsState.SetActive(false);
    }

    public void ShowCreditsScreen()
    {
        splashScreenState.SetActive(false);
        mainMenuState.SetActive(false);
        gameplayState.SetActive(false);
        gameOverState.SetActive(false);
        creditsState.SetActive(true);
        controlsState.SetActive(false);
        settingsState.SetActive(false);
    }

    public void ShowControlsScreen()
    {
        splashScreenState.SetActive(false);
        mainMenuState.SetActive(false);
        gameplayState.SetActive(false);
        gameOverState.SetActive(false);
        creditsState.SetActive(false);
        controlsState.SetActive(true);
        settingsState.SetActive(false);
    }

    public void ShowSettingsScreen()
    {
        splashScreenState.SetActive(false);
        mainMenuState.SetActive(false);
        gameplayState.SetActive(false);
        gameOverState.SetActive(false);
        creditsState.SetActive(false);
        controlsState.SetActive(false);
        settingsState.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void SpawnRandomEnemy()
    {

    }
}
