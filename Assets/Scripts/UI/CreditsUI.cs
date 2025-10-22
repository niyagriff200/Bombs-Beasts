using UnityEngine;

public class CreditsUI : MonoBehaviour
{
    public void MainMenu()
    {
        //check if the GameManager is null
        //if not null ShowMainMenu
        GameManager.Instance?.ShowMainMenu();
    }
}
