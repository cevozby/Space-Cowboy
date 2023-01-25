using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornRotate : MonoBehaviour
{
    [SerializeField] float minSpeed, maxSpeed;
    float rotateSpeed;
    int turn;

    private void OnEnable()
    {
        rotateSpeed = Random.Range(minSpeed, maxSpeed);
        if (Random.Range(0f, 1f) >= 0.5f) turn = 1;
        else turn = -1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(Vector3.up * turn * rotateSpeed);
    }
}
