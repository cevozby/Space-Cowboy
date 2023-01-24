using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObstacleSize : MonoBehaviour
{
    [SerializeField] Transform leftTransform, rightTransform;

    private void OnEnable()
    {
        RandomHole();
    }
    void RandomHole()
    {
        int leftScale = Random.Range(2, 26);
        int rightScale = 28 - leftScale;

        float leftDis = (float) leftScale / 2;
        float rightDis = (float) rightScale / 2;

        leftTransform.localScale = new Vector3(leftScale, leftTransform.localScale.y, leftTransform.localScale.z);
        rightTransform.localScale = new Vector3(rightScale, rightTransform.localScale.y, rightTransform.localScale.z);

        leftTransform.position = new Vector3(-20f + leftDis, leftTransform.position.y, leftTransform.position.z);
        rightTransform.position = new Vector3(20f - rightDis, rightTransform.position.y, rightTransform.position.z);


    }
}