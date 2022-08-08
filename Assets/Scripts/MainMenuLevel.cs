using UnityEngine;

public class MainMenuLevel : MonoBehaviour
{
     public GameObject settingsWindow;

    public void SettingsButton()
    {
        settingsWindow.SetActive(true);
    }

    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }
}
