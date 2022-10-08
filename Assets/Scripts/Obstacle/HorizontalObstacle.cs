using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalObstacle : ObstacleSpawn
{
    public List<GameObject> horizontalObstacles = new List<GameObject>();
    string type = "Horizontal";

    // Start is called before the first frame update
    void OnEnable()
    {
        StartRandom(horizontalObstacles, type);
    }

    // Update is called once per frame
    void Update()
    {
        ObstacleList(horizontalObstacles);
        listLength = randomObstacles.Count;

            if (listLength == 6)
            {
                RandomObstacle(horizontalObstacles);
            }

    }
}
