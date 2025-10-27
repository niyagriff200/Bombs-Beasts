using UnityEngine;
using TMPro;

// Displays score, high score,
public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    private void Update()
    {
        if (GameManager.Instance != null)
        {
            scoreText.text = "Score: " + GameManager.Instance.Score.ToString("0000");
            highScoreText.text = "High Score: " + GameManager.Instance.HighScore.ToString("0000");
        }
    }

    public void PlayAgain()
    {
        GameManager.Instance?.ShowGameplay();
    }

    public void MainMenu()
    {
        GameManager.Instance?.ShowMainMenu();
    }
}