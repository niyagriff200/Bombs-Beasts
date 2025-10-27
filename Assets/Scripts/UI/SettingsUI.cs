using UnityEngine;

// Handles navigation from settings screen
public class SettingsUI : MonoBehaviour
{
    public void Audio()
    {
        GameManager.Instance?.ShowAudioSettings();
    }

    public void Controls()
    {
        GameManager.Instance?.ShowControlsScreen();
    }

    public void MainMenu()
    {
        GameManager.Instance?.ShowMainMenu();
    }
}