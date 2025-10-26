using UnityEngine;

public class ProjectileOnCollisionResponse : OnCollisionResponse
{
    protected override void Start()
    {
        // Pull damage value from GameManager for designer control
        damageAmount = GameManager.Instance.ProjectileDamage;
    }

    protected override void HandleDamage(GameObject other)
    {
        base.HandleDamage(other); // Use base damage logic
    }

    protected override void HandleEffects(GameObject other)
    {
       
    }

    protected override void HandleCleanup()
    {
        base.HandleCleanup(); // Destroy projectile after impact
    }
}