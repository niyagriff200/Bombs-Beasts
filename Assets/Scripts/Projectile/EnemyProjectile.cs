using UnityEngine;

public class EnemyProjectile : Projectile
{
    private Vector3 moveDirection;
    private float moveSpeed;

    protected override void Start()
    {
        base.Start();

        moveSpeed = GameManager.Instance.DefaultProjectileSpeed;

        Transform player = GameManager.Instance.PlayerToFollow;
        if (player != null)
        {
            moveDirection = (player.position - transform.position).normalized;
            transform.rotation = Quaternion.FromToRotation(Vector3.up, moveDirection);
        }
        else
        {
            moveDirection = transform.up;
        }
    }

    private void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
