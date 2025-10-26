using UnityEngine;

public class ZoomerOnCollisionResponse : OnCollisionResponse
{
    protected override void Start()
    {
        base.Start();
        damageAmount = GameManager.Instance.ZoomerDamageAmount;
    }

    protected override void HandleDamage(GameObject other)
    {
        base.HandleDamage(other);
    }
}
