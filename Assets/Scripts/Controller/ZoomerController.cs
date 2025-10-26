using UnityEngine;

public class ZoomerController : Controller
{
    private float moveSpeed;
    private Vector2 moveDirection;

    private void Start()
    {
        moveSpeed = GameManager.Instance.ZoomerMoveSpeed;

        // Determine direction based on spawn
        // screen center is (x = 0)  so divide left/right
        if (transform.position.x < 0)
        {
            // Spawned on the left,  move right
            moveDirection = Vector2.right;
            transform.rotation = Quaternion.Euler(0, 180, 0); // flip horizontally
        }
        else
        {
            // Spawned on the right,  move left
            moveDirection = Vector2.left;
            transform.rotation = Quaternion.Euler(0, 0, 0); 
        }
    }

    private void Update()
    {
        // Move in chosen direction
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

        if (Mathf.Abs(transform.position.x) > 30f)
        {
            GameManager.Instance.RemoveEnemy(gameObject);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Example: damage player on contact
        PlayerPawn player = other.GetComponent<PlayerPawn>();
        if (player != null)
        {
            Destroy(gameObject); // Zoomer disappears on impact
        }
    }
}
