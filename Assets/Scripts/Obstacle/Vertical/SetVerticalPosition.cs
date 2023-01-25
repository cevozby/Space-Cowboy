using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVerticalPosition : MonoBehaviour
{
    [SerializeField] float minValue, maxValue;

    private void OnEnable()
    {
        transform.position = new Vector3(transform.position.x, Random.Range(minValue, maxValue), transform.position.z);
    }
}
