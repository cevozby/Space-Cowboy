using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPropellerX : MonoBehaviour
{
    float spinInput = 360f; //Full rotate
    float spinForSecond = 10f; //Set for how many times per second to spin

    void Start()
    {
        
    }



    void Update()
    {
        //Spin to propeller
        transform.Rotate(Vector3.forward * spinInput * spinForSecond * Time.deltaTime);
    }
}
