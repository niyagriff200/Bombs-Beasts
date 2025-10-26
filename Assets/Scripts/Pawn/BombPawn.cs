using UnityEngine;

public class BombPawn : Pawn
{
    private float moveSpeed;
    private bool hasExploded;
    private float explosionRadius;
    private float maxDamage;
    private float damageFalloff;

    protected override void Start()
    {
        base.Start();
        moveSpeed = GameManager.Instance.BombMoveSpeed;
        explosionRadius = GameManager.Instance.BombExplosionRadius;
        maxDamage = GameManager.Instance.BombMaxDamage;
        damageFalloff = GameManager.Instance.BombDamageFalloffPercentage;
    }

    public override void Move(Vector3 moveVector)
    {
        transform.position += moveVector * moveSpeed * Time.deltaTime;
    }

    // Called externally by BombOnCollisionResponse
    public void Explode()
    {
        if (hasExploded)
            return;

        hasExploded = true;

        Health[] allHealthObjects = FindObjectsByType<Health>(FindObjectsSortMode.None);
        foreach (Health target in allHealthObjects)
        {
            float distance = Vector2.Distance(transform.position, target.transform.position);

            if (distance <= explosionRadius)
            {
                float distancePercent = distance / explosionRadius;
                float falloffMultiplier = Mathf.Lerp(1f, damageFalloff, distancePercent);
                float damage = maxDamage * falloffMultiplier;

                target.TakeDamage(damage);
            }
        }

       DeathTarget deathTarget = GetComponent<DeathTarget>();
        if (deathTarget != null)
        {
            deathTarget.Die();
        }
    }
}
