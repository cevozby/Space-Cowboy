using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalObstacle : ObstacleSpawn
{
    public List<GameObject> verticalObstacles = new List<GameObject>();


    void OnEnable()
    {
        StartRandom(verticalObstacles);
    }

    // Update is called once per frame
    void Update()
    {
        ChangeObstacle(verticalObstacles);
    }
}
