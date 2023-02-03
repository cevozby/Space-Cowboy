using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetController : MonoBehaviour
{
    public static bool joystick, dpad;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Joystick: " + joystick + " D-Pad: " + dpad);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
