using UnityEngine;

public class BombHealth : Health
{
    protected override void Start()
    {
        // Pull max health from GameManager—designer-controlled
        maxHealth = GameManager.Instance.BombMaxHealth;
        currentHealth = maxHealth;
    }

    protected override void Die()
    {

        // Remove from activeEnemies and destroy bombs - use DeathTarget
        DeathTarget target = GetComponent<DeathTarget>();
        if (target != null)
        {
            AudioSource.PlayClipAtPoint(GameManager.Instance.BombExplosionClip, transform.position, 1f);
            target.Die(); // Handles removal and destruction
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Projectile>() != null)
        {
            // Award score
            GameManager.Instance.AddScore(GameManager.Instance.BombEnemyScore);
        }
    }
}
