using UnityEngine;

public class PlayerPawn : Pawn
{
    private float moveSpeed;
    private float jumpHeight;

    private Rigidbody2D rb;
    private bool isGrounded;

    protected override void Start()
    {
        base.Start();
        moveSpeed = GameManager.Instance.PlayerMoveSpeed;
        jumpHeight = GameManager.Instance.PlayerJumpHeight;

        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("PlayerPawn is missing a Rigidbody2D component!");
        }
    }


    public override void Move(Vector3 moveVector)
    {
        rb.linearVelocity = new Vector2(moveVector.x * moveSpeed, rb.linearVelocity.y);
    }

    public void Jump()
    {
        // Only jump if grounded
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    public void Shoot()
    {
        Shooter.Shoot();
    }

    // Called when colliding with a ground object
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Ground>() != null)
        {
            isGrounded = true;
            ResetRotation();
        }
    }

    // Called when leaving a ground object collision
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Ground>() != null)
        {
            isGrounded = false;
        }
    }


    public void ResetRotation()
    {
        if (rb != null)
        {
            rb.rotation = 0f;
            rb.angularVelocity = 0f;
        }
        transform.rotation = Quaternion.identity;
    }

}
