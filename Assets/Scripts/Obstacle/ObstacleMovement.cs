using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] bool vertical, horizontal, both;

    [SerializeField] float minSpeed, maxSpeed;
    
    float speed;

    [SerializeField] float minBound, maxBound;

    Vector3 upPoint, downPoint;
    Vector3 rightPoint, leftPoint;

    Vector3 target;

    private void OnEnable()
    {
        
        speed = Random.Range(minSpeed, maxSpeed);
        if (both)
        {
            vertical = false;
            horizontal = false;
            int random = Random.Range(0, 2);
            switch (random)
            {
                case 0:
                    vertical = true;
                    break;
                case 1:
                    horizontal = true;
                    break;
                default:
                    break;
            }
        }

        if (vertical)
        {
            upPoint = new Vector3(transform.position.x, maxBound, transform.position.z);
            downPoint = new Vector3(transform.position.x, minBound, transform.position.z);
            target = SetRandomly(upPoint, downPoint);
        }
        else if (horizontal)
        {
            rightPoint = new Vector3(maxBound, transform.position.y, transform.position.z);
            leftPoint = new Vector3(minBound, transform.position.y, transform.position.z);
            target = SetRandomly(rightPoint, leftPoint);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (vertical) VerticalMovement();
        else if (horizontal) HorizontalMovement();
    }

    void VerticalMovement()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, target, speed);
        if (Vector3.Distance(transform.position, upPoint) <= 0.1f) target = downPoint;
        else if (Vector3.Distance(transform.position, downPoint) <= 0.1f) target = upPoint;
    }

    void HorizontalMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed);
        if (Vector3.Distance(transform.position, rightPoint) <= 0.1f) target = leftPoint;
        else if (Vector3.Distance(transform.position, leftPoint) <= 0.1f) target = rightPoint;
    }

    Vector3 SetRandomly(Vector3 first, Vector3 second)
    {
        Vector3 newTarget = Vector3.zero;
        int random = Random.Range(0, 2);
        switch (random)
        {
            case 0:
                newTarget = first;
                break;
            case 1:
                newTarget = second;

                break;
            default:
                break;
        }
        //Debug.Log(newTarget);
        return newTarget;
    }

}
