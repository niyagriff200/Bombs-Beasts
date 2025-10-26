using UnityEngine;

public class DiamondPickup : MonoBehaviour
{
    private float scoreValue;

    private void Start()
    {
        scoreValue = GameManager.Instance.DiamondScore;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerPawn pawn = other.gameObject.GetComponent<PlayerPawn>();
        if (pawn != null)
        {
            AudioSource.PlayClipAtPoint(GameManager.Instance.ScoreClip, transform.position, 1f);
            GameManager.Instance.AddScore(scoreValue);
            GameManager.Instance.RemoveDiamonds(gameObject);
            Destroy(gameObject);
        }
    }
}
