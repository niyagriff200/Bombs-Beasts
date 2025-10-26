using UnityEngine;

public class BombOnCollisionResponse : OnCollisionResponse
{
    private BombPawn bombPawn;

    protected override void Start()
    {
        base.Start();
        bombPawn = GetComponent<BombPawn>();

        if (bombPawn == null)
        {
            Debug.LogWarning("BombOnCollisionResponse attached to an object without BombPawn!");
        }
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == gameObject.layer)
            return;

        if (bombPawn != null &&
            (collision.gameObject.GetComponent<Ground>() != null ||
             collision.gameObject.GetComponent<PlayerPawn>() != null ||
             collision.gameObject.GetComponent<PlayerProjectile>() != null))
        {
            bombPawn.Explode();
        }
    }
}
