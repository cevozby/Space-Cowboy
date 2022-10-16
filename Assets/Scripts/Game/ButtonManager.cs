using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void MenuButton()
    {
        // When click the menu button, game'll stop. Menu is opening on Unity
        Time.timeScale = 0;
    }

    public void ResumeButton()
    {
        Time.timeScale = 1;
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
