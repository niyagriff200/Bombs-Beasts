using UnityEngine;

public class PlayerController : Controller
{
    [SerializeField] private PlayerPawn pawn;
    public PlayerPawn Pawn
    {
        get { return pawn; }
        set 
        { 
            pawn = value;
            if (pawn == null)
                Debug.LogWarning("PlayerController.Pawn is being set to null!");
            else
                Debug.Log("PlayerController.Pawn assigned: " + pawn.name);
        }
    }


    private void Update()
    {
        if (pawn != null)
        {
            //Move to the left
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                pawn.Move(Vector3.left);
            }
            //Move to the right
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                pawn.Move(Vector3.right);
            }
            //Stop moving if no keys are pressed
            else
            {
                pawn.Move(Vector3.zero);
            }

            //Move up
            if (Input.GetKeyDown(KeyCode.Space))
            {
                pawn.Jump();
            }

            //Shoot
            if (Input.GetMouseButtonDown(0))
            {
                pawn.Shooter.Shoot();
            }
        }
    }
}