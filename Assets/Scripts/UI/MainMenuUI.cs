using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public void StartButton()
    {
        if (GameManager.Instance != null)
        {
            //GameManager.Instance.ShowGameplay();
        }
    }

    public void SettingsButton()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ShowSettingsScreen();
        }
    }

    public void CreditsButton()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ShowCreditsScreen();
        }
    }

    public void ExitButton()
    {
        if (GameManager.Instance != null)
        {
            Debug.Log("You exited the game.");
            GameManager.Instance.QuitGame();
        }
    }
}
