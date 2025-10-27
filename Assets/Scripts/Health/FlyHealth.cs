using UnityEngine;

public class FlyHealth : Health
{

    protected override void Start()
    {
        // Pull max health from GameManager—designer-controlled
        maxHealth = GameManager.Instance.FlyMaxHealth;
        currentHealth = maxHealth;
    }

    protected override void Die()
    {
        // Award score for Fly kill
        GameManager.Instance.AddScore(GameManager.Instance.FlyEnemyScore);

        // Remove from activeEnemies and destroy—Fly use DeathTarget
        DeathTarget target = GetComponent<DeathTarget>();
        if (target != null)
        {
            AudioSource.PlayClipAtPoint(GameManager.Instance.FlyEnemyDeathClip, transform.position, 1f);
            target.Die(); // Handles removal and destruction
        }
    }
}
