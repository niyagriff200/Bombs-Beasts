using UnityEngine;

public class DiamondPickup : MonoBehaviour
{
    private float scoreValue;
    private float fallSpeed;
    private bool isFalling = true;

    private void Start()
    {
        scoreValue = GameManager.Instance.DiamondScore;
        fallSpeed = GameManager.Instance.DiamondFallSpeed;
    }

    private void Update()
    {
        if (isFalling)
        {
            transform.position += Vector3.down * fallSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the player touches it
        PlayerPawn pawn = other.GetComponent<PlayerPawn>();
        if (pawn != null)
        {
            AudioSource.PlayClipAtPoint(GameManager.Instance.ScoreClip, transform.position, 1f);
            GameManager.Instance.AddScore(scoreValue);
            GameManager.Instance.RemoveDiamonds(gameObject);
            Destroy(gameObject);
            return;
        }

        // If it lands on the ground, stop falling
        Ground ground = other.GetComponent<Ground>();
        if (ground != null)
        {
            isFalling = false;
        }
    }
}
