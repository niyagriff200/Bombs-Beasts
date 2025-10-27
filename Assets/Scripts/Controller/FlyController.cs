using UnityEngine;

public class FlyController : Controller
{
    private FlyPawn pawn;
    private Transform playerTarget;


    private void Start()
    {
        pawn = GetComponent<FlyPawn>();
        playerTarget = GameManager.Instance.PlayerToFollow;
    }

    private void Update()
    {
        if (pawn == null || playerTarget == null)
        {
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
    }
}
