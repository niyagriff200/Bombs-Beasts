using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{

    [Header("Player Settings")]
    [SerializeField] private Transform playerSpawnPoint;
    public Transform PlayerSpawnPoint => playerSpawnPoint;
    
    [SerializeField] private List<PlayerController> players;
    public List<PlayerController> Players => players;


    [Header("Spawn Points")]
    [SerializeField] private List<Transform> flySpawnPoints;
    public List <Transform> FlySpawnPoints => flySpawnPoints;

    [SerializeField] private List<Transform> zoomerSpawnPoints;
    public List<Transform> ZoomerSpawnPoints => zoomerSpawnPoints;

    [SerializeField] private List<Transform> bombSpawnPoints;
    public List<Transform> BombSpawnPoints => bombSpawnPoints;

    [SerializeField] private List<Transform> healthPickupSpawnPoints;
    public List<Transform> HealthPickupSpawnPoints => healthPickupSpawnPoints;


    [Header("Enemy Spawn Settings")]
    [SerializeField] private List<GameObject> activeEnemies = new List<GameObject>();
    public List<GameObject> ActiveEnemies => activeEnemies;

    [SerializeField][Range(0f, 1f)] private float flyEnemyChance;
    public float FlyEnemyChance => flyEnemyChance;

    [SerializeField][Range(0f, 1f)] private float zoomerEnemyChance;
    public float ZoomerEnemyChance => zoomerEnemyChance;

    [SerializeField] private float enemySpawnInterval;
    public float EnemySpawnInterval => enemySpawnInterval;

    [HideInInspector] private float enemySpawnTimer;
    public float EnemySpawnTimer => enemySpawnTimer;

    [HideInInspector] private int intialEnemiesSpawned = 0;
    public float InitialEnemiesSpawned => intialEnemiesSpawned;


    [Header("Diamond Spawn Settings")]
    [SerializeField] private List<GameObject> activeDiamonds = new List<GameObject>();
    public List<GameObject> ActiveDiamonds => activeDiamonds;

    [SerializeField] private float diamondSpawnInterval;
    public float DiamondIntervalTimer => diamondSpawnInterval;

    private float diamondSpawnTimer;
    public float DiamondSpawnTimer => diamondSpawnTimer;



    [Header("Health Pickup Spawn Settings")]
    [SerializeField] private List<GameObject> activeHealthPickup = new List<GameObject>();
    public List<GameObject> ActiveHealthPickup => activeHealthPickup;

    [SerializeField] private float healSpawnInterval;
    public float HealSpawnInterval => healSpawnInterval;

    private float healSpawnTimer;
    public float HealSpawnTimer => healSpawnTimer;

    private List<GameObject> activeHealPickups = new List<GameObject>();
    public List<GameObject> ActiveHealPickups => activeHealPickups;

}
