using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected virtual void Start()
    {
        if (GameManager.Instance != null)
        {
            Destroy(gameObject, GameManager.Instance.DefaultProjectileLifetime);
        }
        else
        {
            Destroy(gameObject, 5f); // fallback duration
        }
    }
}
