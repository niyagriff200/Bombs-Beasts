using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{

    [Header("Player Settings")]
    [SerializeField] private Transform playerSpawnPoint;
    public Transform PlayerSpawnPoint
    {
        get => playerSpawnPoint;
        set => playerSpawnPoint = value;
    }
    
    [SerializeField] private List<PlayerController> players;
    public List<PlayerController> Players
    {
        get => players;
        set => players = value;
    }

    [Header("Spawn Points")]
    [SerializeField] private List<Transform> flySpawnPoints;
    public List<Transform> FlySpawnPoints
    {
        get => flySpawnPoints;
        set => flySpawnPoints = value;    
    }

    [SerializeField] private List<Transform> zoomerSpawnPoints;
    public List<Transform> ZoomerSpawnPoints
    {
        get => zoomerSpawnPoints; 
        set => zoomerSpawnPoints = value;    
    }

    [SerializeField] private List<Transform> bombSpawnPoints;
    public List<Transform> BombSpawnPoint
    {
        get => bombSpawnPoints;
        set => bombSpawnPoints = value;
    }

    [SerializeField] private List<Transform> healthPickupSpawnPoints;
    public List<Transform> HealthPickupSpawnPoints
    {
        get => healthPickupSpawnPoints;
        set => healthPickupSpawnPoints = value;
    }


    [Header("Enemy Spawn Settings")]
    [SerializeField] private List<GameObject> activeEnemies = new List<GameObject>();
    public List<GameObject> ActiveEnemies
    {
        get => activeEnemies;
        set => activeEnemies = value;
    }

    [SerializeField][Range(0f, 1f)] private float flyEnemyChance;
    public float FlyEnemyChance
    { 
        get =>  flyEnemyChance;
        set => flyEnemyChance = value;
    }

    [SerializeField][Range(0f, 1f)] private float zoomerEnemyChance;
    public float ZoomerEnemyChance
    {
        get => zoomerEnemyChance;    
        set => zoomerEnemyChance = value;
    }

    [SerializeField] private float enemySpawnInterval;
    public float EnemySpawnInterval
    {
        get => enemySpawnInterval;
        set => enemySpawnInterval = value;
    }

    private float enemySpawnTimer;
    public float EnemySpawnTimer
    {
        get => enemySpawnTimer; 
        set => enemySpawnTimer = value;  
    }

    public enum EnemySpawnType
    {
        Bomb,
        Fly,
        Zoomer
    }

    [Header("Diamond Spawn Settings")]
    [SerializeField] private List<GameObject> activeDiamonds = new List<GameObject>();
    public List<GameObject> ActiveDiamonds
    {
        get => activeDiamonds;
        set => activeDiamonds = value;
    }

    [SerializeField] private List<Transform> diamondSpawnPoints;
    public List<Transform> DiamondSpawnPoints => diamondSpawnPoints;

    [SerializeField] private float diamondSpawnInterval;
    public float DiamondIntervalTimer
    {
        get => diamondSpawnInterval;
        set => diamondSpawnInterval = value;
    }

    private float diamondSpawnTimer;
    public float DiamondSpawnTimer
    {
        get => diamondSpawnTimer;
        set => diamondSpawnTimer = value;

    }

    [Header("Health Pickup Spawn Settings")]
    [SerializeField] private List<GameObject> activeHealthPickups = new List<GameObject>();
    public List<GameObject> ActiveHealthPickups
    {
        get => activeHealthPickups;
        set => activeHealthPickups = value;
    }

    [SerializeField] private float healSpawnInterval;
    public float HealSpawnInterval
    {
        get => healSpawnInterval;
        set => healSpawnInterval = value;
    }

    private float healSpawnTimer;
    public float HealSpawnTimer
    {
        get => healSpawnTimer;
        set => healSpawnTimer = value;
    }

}
