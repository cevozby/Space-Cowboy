using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetHorizontalPosition : MonoBehaviour
{
    [SerializeField] float minValue, maxValue;

    private void OnEnable()
    {
        transform.position = new Vector3(Random.Range(minValue, maxValue), transform.position.y,  transform.position.z);
    }
}
