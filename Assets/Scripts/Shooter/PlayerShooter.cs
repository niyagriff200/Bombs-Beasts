using UnityEngine;

public class PlayerShooter : Shooter
{
    protected override void Start()
    {
        base.Start();
        projectilePrefab = GameManager.Instance.PlayerProjectilePrefab;
        fireRate = GameManager.Instance.PlayerShootRate;
    }

    public override void Shoot()
    {
        base.Shoot();
    }
}
