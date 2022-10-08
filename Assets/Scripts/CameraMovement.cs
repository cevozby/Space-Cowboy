using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float speed, width, hight;

    float timeCounter = 0;

    [SerializeField] Vector3 pointA, pointB;
    [SerializeField] List<Vector3> points;
    Vector3 target;

    [SerializeField] Transform helper;

    int i;

    // Start is called before the first frame update
    void Start()
    {
        i = 1;
        target = points[i];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //helper.position = Vector3.MoveTowards(helper.position, target, speed);
        //if(Vector3.Distance(helper.position, pointA) <= 0.1f)
        //{
        //    target = pointB;
        //}
        //else if (Vector3.Distance(helper.position, pointB) <= 0.1f)
        //{
        //    target = pointA;
        //}
        //if(Vector3.Distance(helper.position, points[i]) <= 0.1f)
        //{
        //    if(i < points.Count - 1)
        //    {
        //        i++;
        //    }
        //    else if( i == points.Count - 1)
        //    {
        //        i = 0;
        //    }
        //    target = points[i];
        //}
        timeCounter += Time.fixedDeltaTime * speed;
        helper.position = new Vector3(Mathf.Cos(timeCounter) * -width, Mathf.Sin(timeCounter) * hight, 0);

    }

    private void LateUpdate()
    {
        
        transform.LookAt(helper);
    }
}
