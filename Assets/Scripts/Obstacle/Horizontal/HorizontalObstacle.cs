using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalObstacle : ObstacleSpawn
{
    public List<GameObject> horizontalObstacles = new List<GameObject>();

    // Start is called before the first frame update
    void OnEnable()
    {
        StartRandom(horizontalObstacles);
    }

    // Update is called once per frame
    void Update()
    {
        ChangeObstacle(horizontalObstacles);
    }
}
