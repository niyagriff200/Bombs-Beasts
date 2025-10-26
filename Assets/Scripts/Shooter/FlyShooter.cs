using UnityEngine;

public class FlyShooter : Shooter
{
    protected override void Start()
    {
        base.Start();
        projectilePrefab = GameManager.Instance.EnemyProjectilePrefab;
        fireRate = GameManager.Instance.FlyShootRate;
    }

    public override void Shoot()
    {
        base.Shoot();
    }
}
