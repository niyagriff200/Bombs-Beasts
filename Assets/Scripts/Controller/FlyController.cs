using UnityEngine;

public class FlyController : Controller
{
    private FlyPawn pawn;
    private Transform playerTarget;
    private float nextDodgeTime;

    private void Start()
    {
        pawn = GetComponent<FlyPawn>();
        playerTarget = GameManager.Instance.PlayerToFollow;

        // Start timing for the first dodge
        nextDodgeTime = Time.time + GameManager.Instance.DodgeProjectileTime;
    }

    private void Update()
    {
        if (pawn == null || playerTarget == null)
        {
            return;
        }

        // If the fly is currently dodging, skip normal movement and shooting
        if (pawn.IsDodging)
        {
            pawn.UpdateDodge();
            return;
        }

        Vector3 direction = playerTarget.position - pawn.transform.position;
        float distance = direction.magnitude;
        direction.Normalize();

        // Follow or shoot depending on distance
        if (distance > GameManager.Instance.FlyStoppingDistance)
        {
            pawn.Move(direction);

        }
        else
        {
            pawn.Shoot();
        }

        // Handle dodge timing
        if (Time.time >= nextDodgeTime)
        {
            pawn.StartDodge();
            nextDodgeTime = Time.time + GameManager.Instance.DodgeProjectileTime;
        }
    }
}
