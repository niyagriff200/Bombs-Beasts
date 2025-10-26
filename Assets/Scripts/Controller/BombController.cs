using UnityEngine;

public class BombController : Controller
{
    [SerializeField] private BombPawn pawn;
    public BombPawn Pawn
    {
        get { return pawn; }
        set { pawn = value; }
    }

    private void Update()
    {
        if (pawn != null)
        {
            // Constantly move down
            pawn.Move(Vector3.down);
        }
    }
}
