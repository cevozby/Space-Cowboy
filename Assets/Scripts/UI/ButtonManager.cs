using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] Toggle joystick, dpad;

    public void PlayButton()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("StartScene");
        Time.timeScale = 1;
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

    public void JoystickButton(bool check)
    {
        Debug.Log(check);
        SetController.joystick = check;
        SetController.dpad = !check;
        dpad.isOn = !check;
    }

    public void DpadButton(bool check)
    {
        Debug.Log(check);
        SetController.dpad = check;
        SetController.joystick = !check;
        joystick.isOn = !check;
    }
}
