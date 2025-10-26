using UnityEngine;

public class PlayerHealth : Health
{
    // Tracks remaining lives for the player
    private int startingLives;
    private int currentLives;

    protected override void Start()
    {
        // Pull health and lives values from GameManager for designer control
        maxHealth = GameManager.Instance.PlayerMaxHealth;
        currentHealth = maxHealth;
        startingLives = GameManager.Instance.PlayerStartingLives;
        currentLives = startingLives;
    }

    // Returns current number of lives (used by UI and win/lose logic)
    public int GetCurrentLives()
    {
        return currentLives;
    }
    

    protected override void Die()
    {
        currentLives--;
        GameManager.Instance.GameplayUI.UpdateLives(currentLives); // Update UI display
        Debug.Log("Player Lives: " + currentLives);

        // If player still has lives, reset health and reposition
        if (currentLives > 0)
        {
            GameplayUI ui = FindFirstObjectByType<GameplayUI>();
            if (ui != null)
            {
                ui.UpdateLives(currentLives);
            }

            HealToFull(); // Restore health
            DeathRecenter recenter = GetComponent<DeathRecenter>();
            if (recenter != null)
            { 
                recenter.Die(); // Reset position instead of destroying
            }

            currentHealth = maxHealth; // Ensure health is restored
        }
        else
        {
            DeathDestroy destroy = GetComponent<DeathDestroy>();
            if (destroy != null)
            {
                destroy.Die(); //Destroy the player pawn
            }
        }
    }
}