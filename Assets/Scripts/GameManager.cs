using System.Collections.Generic;
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
    [SerializeField] private LevelData currentlevelData;
    public LevelData CurrentLevelData
    {
        get { return currentlevelData; }
        set { currentlevelData = value; }
    }

    [Header("GameplayUI GUI")]
    [SerializeField] private GameplayUI gameplayUI;
    public GameplayUI GameplayUI => gameplayUI;

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

    [SerializeField] private AudioClip shootClip;
    public AudioClip ShootClip => shootClip;

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

    [SerializeField] private int playerStartingLives;
    public int PlayerStartingLives => playerStartingLives;

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

    private Transform playerToFollow;
    public Transform PlayerToFollow => playerToFollow;

    [SerializeField] private float dodgeProjectileTime; //Dodge a projectile every certain number of seconds...
    public float DodgeProjectileTime => dodgeProjectileTime;

    [SerializeField] private float dodgeSpeedMultiplier;
    public float DodgeSpeedMultiplier => dodgeSpeedMultiplier;

    [SerializeField] private float flyStoppingDistance;
    public float FlyStoppingDistance => flyStoppingDistance;


    [Header("Zoomer Enemy Settings")]
    [SerializeField] private float zoomerMoveSpeed;
    public float ZoomerMoveSpeed => zoomerMoveSpeed;

    [SerializeField] private float zoomerDamageAmount;
    public float ZoomerDamageAmount => zoomerDamageAmount;


    [Header("Bomb Settings")]
    [SerializeField] private float bombMaxDamage;
    public float BombMaxDamage => bombMaxDamage;

    [SerializeField][Range(0f, 1f)] private float bombDamageFalloffPercentage; // Based on distance from bomb (i.e., if close more damage, if far less )
    public float BombDamageFalloffPercentage => bombDamageFalloffPercentage;

    [SerializeField] private float bombExplosionRadius;
    public float BombExplosionRadius => bombExplosionRadius;


    [SerializeField] private float bombMoveSpeed;
    public float BombMoveSpeed => bombMoveSpeed;

    [SerializeField] private float bombMaxHealth;
    public float BombMaxHealth => bombMaxHealth;


    [Header("Projectile Settings")]
    [SerializeField] private float defaultProjectileSpeed;
    public float DefaultProjectileSpeed => defaultProjectileSpeed;

    [SerializeField] private float defaultProjectileLifetime;
    public float DefaultProjectileLifetime => defaultProjectileLifetime;

    [SerializeField] private float projectileDamage;
    public float ProjectileDamage => projectileDamage;

    [Header("Health Pickup Settings")]
    [SerializeField] private float healAmount;
    public float HealAmount => healAmount;


    [Header("Score Value Settings")]
    [SerializeField] private float flyEnemyScore;
    public float FlyEnemyScore
    {
        get => flyEnemyScore;
        set => flyEnemyScore = value;
    }

    [SerializeField] private float bombEnemyScore;
    public float BombEnemyScore => bombEnemyScore;

    [SerializeField] private float diamondScore;
    public float DiamondScore => diamondScore;

    [Header("Score Tracker")]
    [SerializeField] private float score;
    public float Score
    {
        get => score;
        set => score = value;
    }

    [SerializeField] private float highScore;
    public float HighScore
    {
        get => highScore;
        set => highScore = value;
    }


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

    private void Start()
    {
        HighScore = PlayerPrefs.GetFloat("HighScore", 0f);
        AudioManager musicManager = Object.FindFirstObjectByType<AudioManager>();
        musicManager.PlayMenuMusic();
    }

    private void Update()
    {
        if (GameplayState.activeInHierarchy)
        {
            StartGameplay();
        }

        if (IsPlayerAlive())
        {
            // If the controller is alive, *then* check if its pawn is null (destroyed)
            if (CurrentLevelData.Players[0].Pawn == null)
            {
                ShowGameOver();
            }
        }
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

    public void ShowGameplay()
    {
        splashScreenState.SetActive(false);
        mainMenuState.SetActive(false);
        gameplayState.SetActive(true);
        gameOverState.SetActive(false);
        creditsState.SetActive(false);
        controlsState.SetActive(false);
        settingsState.SetActive(false);


        CurrentLevelData.Players = new List<PlayerController>();
        CurrentLevelData.EnemySpawnTimer = 0f;
        CurrentLevelData.HealSpawnTimer = 0f;
        Score = 0f;

        SpawnPlayer();

        AudioManager musicManager = Object.FindFirstObjectByType<AudioManager>();
        musicManager.PlayGameplayMusic();

        if (CurrentLevelData.Players.Count > 0)
        {
            PlayerController playerController = CurrentLevelData.Players[0];
            if (playerController != null)
            {
                PlayerPawn playerPawn = playerController.Pawn;
                if (playerPawn != null)
                {
                    Health baseHealth = playerPawn.Health;
                    if (baseHealth == null)
                    {
                        baseHealth = playerPawn.GetComponent<PlayerHealth>();
                        if (baseHealth != null)
                        {
                            playerPawn.Health = baseHealth;
                        }
                    }

                    PlayerHealth health = baseHealth as PlayerHealth;
                    if (health != null)
                    {

                        gameplayUI.InitializeLives(health.GetCurrentLives());
                        gameplayUI.UpdateLives(health.GetCurrentLives());
                    }
                }
            }

        }
    }

    public void ShowGameOver()
    {
        splashScreenState.SetActive(false);
        mainMenuState.SetActive(false);
        gameplayState.SetActive(false);
        gameOverState.SetActive(true);
        creditsState.SetActive(false);
        controlsState.SetActive(false);
        settingsState.SetActive(false);

        foreach (GameObject enemy in CurrentLevelData.ActiveEnemies)
        {
            if (enemy != null)
            {
                Destroy(enemy);
            }
        }
        CurrentLevelData.ActiveEnemies.Clear();

        // Destroy players (controller + pawn)
        foreach (PlayerController controller in CurrentLevelData.Players)
        {
            if (controller != null)
            {
                // Destroy the pawn GameObject if present
                if (controller.Pawn != null)
                {
                    Destroy(controller.Pawn.gameObject);
                }

                // Destroy the controller object
                Destroy(controller.gameObject);
            }
        }
        CurrentLevelData.Players.Clear();

        // Destroy heal pickups that were tracked
        foreach (GameObject pickup in CurrentLevelData.ActiveHealthPickups)
        {
            if (pickup != null)
            {
                Destroy(pickup);
            }
        }
        CurrentLevelData.ActiveHealthPickups.Clear();

        AudioManager musicManager = Object.FindFirstObjectByType<AudioManager>();
        musicManager.PlayMenuMusic();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public bool IsPlayerAlive()
    {
        return CurrentLevelData.Players.Count > 0 && CurrentLevelData.Players[0] != null; 
    }

    private void StartGameplay()
    {
        if (IsPlayerAlive())
        {
            CurrentLevelData.EnemySpawnTimer += Time.deltaTime;
            if (CurrentLevelData.EnemySpawnTimer >= CurrentLevelData.EnemySpawnInterval)
            {
                SpawnEnemy();
                CurrentLevelData.EnemySpawnTimer = 0f;
            }

            CurrentLevelData.HealSpawnTimer += Time.deltaTime;
            if (CurrentLevelData.HealSpawnTimer >= CurrentLevelData.HealSpawnInterval)
            {
                SpawnHealPickup();
                CurrentLevelData.HealSpawnTimer = 0f;
            }
        }
        
    }

    private void SpawnPlayer()
    {
        Vector3 spawnPosition = CurrentLevelData.PlayerSpawnPoint.position;
        Quaternion spawnRotation = CurrentLevelData.PlayerSpawnPoint.rotation;

        GameObject controllerPrefab = Instantiate(PlayerControllerPrefab, spawnPosition, spawnRotation);
        PlayerController controller = controllerPrefab.GetComponent<PlayerController>();
        CurrentLevelData.Players.Add(controller);

        GameObject playerPrefab = Instantiate(PlayerPawnPrefab, spawnPosition, spawnRotation);
        PlayerPawn pawn = playerPrefab.GetComponent<PlayerPawn>();

        if (pawn != null)
        {
            controller.Pawn = pawn;
            playerToFollow = pawn.transform;
        }
    }

    public void SpawnDiamonds()
    {
        if (CurrentLevelData.DiamondSpawnPoints.Count == 0)
        {
            return;
        }
        Transform spawnPoint = CurrentLevelData.DiamondSpawnPoints[Random.Range(0, CurrentLevelData.DiamondSpawnPoints.Count)];

        GameObject diamond = Instantiate(DiamondPrefab, spawnPoint.position, spawnPoint.rotation);
        CurrentLevelData.ActiveDiamonds.Add(diamond);
    }

    public void RemoveDiamonds(GameObject diamonds)
    {
        if (CurrentLevelData.ActiveDiamonds.Contains(diamonds)) CurrentLevelData.ActiveDiamonds.Remove(diamonds);
    }

    private GameObject GetRandomEnemy()
    {
        float roll = Random.Range(0f, 1f);

        if (roll < CurrentLevelData.FlyEnemyChance )
        {
            return FlyEnemyPrefab;
        }
        else if (roll < CurrentLevelData.ZoomerEnemyChance)
        {
            return ZoomerEnemyPrefab;
        }
        else
        {
            return BombEnemyPrefab;
        }
    }

    private LevelData.EnemySpawnType GetEnemyType(GameObject enemy)
    {
        if (enemy == FlyEnemyPrefab) return LevelData.EnemySpawnType.Fly;
        if (enemy == ZoomerEnemyPrefab) return LevelData.EnemySpawnType.Zoomer;
        if (enemy == BombEnemyPrefab) return LevelData.EnemySpawnType.Bomb;

        // Default 
        return LevelData.EnemySpawnType.Bomb;
    }

    private Vector3 GetRandomSpawnPoint(LevelData.EnemySpawnType spawnType)
    {
        List<Transform> spawnList = null;

        switch (spawnType)
        {
            case LevelData.EnemySpawnType.Fly:
                spawnList = CurrentLevelData.FlySpawnPoints;
                break;
            case LevelData.EnemySpawnType.Zoomer:
                spawnList = CurrentLevelData.ZoomerSpawnPoints;
                break;
            case LevelData.EnemySpawnType.Bomb:
                spawnList = CurrentLevelData.BombSpawnPoint;
                break;
        }

        if (spawnList != null && spawnList.Count > 0)
        {
            int index = Random.Range(0, spawnList.Count);
            return spawnList[index].position;
        }

        //  spawn at origin of the world if there are no valid spawn points
        return Vector3.zero;
    }

    private void SpawnEnemy()
    {
        GameObject enemyToSpawn = GetRandomEnemy();
        LevelData.EnemySpawnType spawnType = GetEnemyType(enemyToSpawn);
        Vector3 spawnPoint = GetRandomSpawnPoint(spawnType);

        if (enemyToSpawn != null)
        {
            GameObject newEnemy = Instantiate(enemyToSpawn, spawnPoint, Quaternion.identity);
            CurrentLevelData.ActiveEnemies.Add(newEnemy);
        }
    }


    public void RemoveEnemy(GameObject enemy)
    {
        if (CurrentLevelData.ActiveEnemies.Contains(enemy)) CurrentLevelData.ActiveEnemies.Remove(enemy);
    }

    public void SpawnHealPickup()
    {
        if (CurrentLevelData.HealthPickupSpawnPoints.Count == 0)
        {
            return;
        }
        Transform spawnPoint = CurrentLevelData.HealthPickupSpawnPoints[Random.Range(0, CurrentLevelData.HealthPickupSpawnPoints.Count)];

        GameObject pickup = Instantiate(HealthPickupPrefab, spawnPoint.position, spawnPoint.rotation);
        CurrentLevelData.ActiveHealthPickups.Add(pickup);
    }

    public void RemoveHealthPickup(GameObject healPack)
    {
        if (CurrentLevelData.ActiveHealthPickups.Contains(healPack)) CurrentLevelData.ActiveHealthPickups.Remove(healPack);
    }

    public void AddScore(float amount)
    {
        score += amount;

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetFloat("TopScore", highScore);
            PlayerPrefs.Save();
        }
    }
}
