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

    public void ExitButton()
    {
        Application.Quit();
    }
}
