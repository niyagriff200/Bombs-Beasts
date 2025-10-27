
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    private float healAmount;
    private void Start()
    {
        LevelData levelData = FindFirstObjectByType<LevelData>();
        if (levelData != null)
        {
            healAmount = GameManager.Instance.HealAmount;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            AudioSource.PlayClipAtPoint(GameManager.Instance.HealthPickupClip, transform.position, 1f);
            playerHealth.Heal(healAmount);
            GameManager.Instance.RemoveHealthPickup(gameObject);
            Destroy(gameObject);
        }
    }
}
