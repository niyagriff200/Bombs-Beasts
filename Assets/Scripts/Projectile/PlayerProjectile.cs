using UnityEngine;

public class PlayerProjectile : Projectile
{
    private Vector3 moveDirection;
    private float moveSpeed;

    protected override void Start()
    {
        base.Start(); // handles lifetime destruction

        // Get speed from GameManager
        moveSpeed = GameManager.Instance.DefaultProjectileSpeed;

        // Get mouse position in world space
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f; // Keep in 2D plane

        // Calculate normalized direction from projectile to mouse
        moveDirection = (mousePos - transform.position).normalized;
    }

    private void Update()
    {
        // Move in that direction
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
