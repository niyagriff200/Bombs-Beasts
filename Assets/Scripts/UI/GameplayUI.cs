
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Updates score, health bar, and lives icons during gameplay
public class GameplayUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public Image healthBar;
    public GameObject lifeIconPrefab;
    public Transform livesContainer;

    private GameObject[] lifeIcons;

    private void Start()
    {
        PlayerHealth health = GameManager.Instance.CurrentLevelData.Players[0].Pawn.Health as PlayerHealth;
        if (health != null)
        {
            InitializeLives(health.GetCurrentLives());
            UpdateLives(health.GetCurrentLives());
        }
    }

    private void Update()
    {
        scoreText.text = "Score: " + GameManager.Instance.Score.ToString("0000");

        Health health = GameManager.Instance.CurrentLevelData.Players[0].Pawn.Health;
        healthBar.fillAmount = health.GetHealthPercent();
    }

    public void InitializeLives(int totalLives)
    {
        
        // Clear existing icons
        foreach (Transform child in livesContainer)
        {
            Destroy(child.gameObject);
        }

        // Spawn icons based on totalLives
        lifeIcons = new GameObject[totalLives];
        for (int i = 0; i < totalLives; i++)
        {
            GameObject icon = Instantiate(lifeIconPrefab, livesContainer);

            lifeIcons[i] = icon;
            Debug.Log("Initialized lives");
        }

    }

    public void UpdateLives(int currentLives)
    {
        // Toggle icons based on currentLives

        if (lifeIcons == null || lifeIcons.Length == 0)
        {
            Debug.LogWarning("Life icons array is null or empty.");
            return;
        }

        for (int i = 0; i < lifeIcons.Length; i++)
        {
            lifeIcons[i].SetActive(i < currentLives);
        }
    }
}