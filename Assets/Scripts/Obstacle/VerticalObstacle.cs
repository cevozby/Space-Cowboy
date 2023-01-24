using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalObstacle : ObstacleSpawn
{
    public List<GameObject> verticalObstacles = new List<GameObject>();
    string type = "Vertical";

    // Start is called before the first frame update
    void OnEnable()
    {
        StartRandom(verticalObstacles, type);
    }

    // Update is called once per frame
    void Update()
    {
        ObstacleList(verticalObstacles);
        listLength = randomObstacles.Count;
        if (listLength == 5 && Points.instance.level < 3)
           {
              RandomObstacle(verticalObstacles);
           }

    }
}
