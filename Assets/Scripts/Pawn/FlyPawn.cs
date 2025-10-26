using UnityEngine;

public class FlyPawn : Pawn
{
    private float moveSpeed;
    private float dodgeSpeedMultiplier;
    private float dodgeDuration; // how long the dodge lasts
    private float dodgeTimer;
    private Vector3 dodgeDirection;
    private bool isDodging;
    private Rigidbody2D rb;

    public bool IsDodging
    {
        get { return isDodging; }
    }

    protected override void Start()
    {
        base.Start();
        moveSpeed = GameManager.Instance.FlyMoveSpeed;
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("FlyPawn is missing a Rigidbody2D component!");
        }
    }

    public override void Move(Vector3 moveVector)
    {
        transform.position += moveVector * moveSpeed * Time.deltaTime;
        ResetRotation();
    }

    public void Shoot()
    {
        Shooter.Shoot();
    }

    public void StartDodge()
    {
        if (isDodging)
        {
            return; // Prevent overlapping dodges
        }

        // Randomly pick a left or right direction
        float randomValue = Random.value;
        if (randomValue > 0.5f)
        {
            dodgeDirection = transform.right;
        }
        else
        {
            dodgeDirection = -transform.right;
        }

        isDodging = true;
        dodgeTimer = dodgeDuration;
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

    public void UpdateDodge()
    {
        if (!isDodging)
        {
            return;
        }

        // Slide sideways
        transform.position += dodgeDirection * moveSpeed * dodgeSpeedMultiplier * Time.deltaTime;

        dodgeTimer -= Time.deltaTime;
        if (dodgeTimer <= 0f)
        {
            isDodging = false;
        }
    }
}
