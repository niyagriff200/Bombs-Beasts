using UnityEngine;

public class BombPawn : Pawn
{
    private float moveSpeed;
    private bool hasExploded;
    private float explosionRadius;
    private float maxDamage;
    private float damageFalloff;

    [SerializeField] private GameObject explosionRadiusUIPrefab;
    [SerializeField] private float warningDuration = 1.0f;

    private GameObject explosionRadiusInstance;
    private float explodeTimer;
    private bool isExplodingSoon;

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

    public void PrepareToExplode()
    {
        if (hasExploded || isExplodingSoon)
        {
            return;
        }

        isExplodingSoon = true;
        explodeTimer = 0f;

        if (explosionRadiusUIPrefab != null)
        {
            explosionRadiusInstance = Instantiate(explosionRadiusUIPrefab, transform.position, Quaternion.identity);
            explosionRadiusInstance.transform.localScale = new Vector3(explosionRadius * 2f, explosionRadius * 2f, 1f);
            explosionRadiusInstance.transform.SetParent(transform, true);

        }
    }

    private void Update()
    {
        // Regular update
        if (isExplodingSoon)
        {
            explodeTimer += Time.deltaTime;

            if (explodeTimer >= warningDuration)
            {
                Explode();
            }
        }
    }

    public void Explode()
    {
        // Show explosion radius
        GameObject radiusVisual = Instantiate(GameManager.Instance.ExplosionRadiusPrefab, transform.position, Quaternion.identity);
        ExplosionRadiusUI radiusUI = radiusVisual.GetComponent<ExplosionRadiusUI>();
        radiusUI.Initialize(explosionRadius);


        if (hasExploded)
        {
            return;
        }

        hasExploded = true;

        if (explosionRadiusInstance != null)
        {
            Destroy(explosionRadiusInstance);
        }

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
