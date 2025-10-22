using UnityEngine;

public class ControlsUI : MonoBehaviour
{
   public void Settings()
    {
        //check if instance of GameManager is null
        //if not null ShowSettingsScreen
        GameManager.Instance?.ShowSettingsScreen();
    }
}
