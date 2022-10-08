using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareObstacle : ObstacleSpawn
{
    public List<GameObject> squareObstacles = new List<GameObject>();
    string type = "Square";

    // Start is called before the first frame update
    void OnEnable()
    {
        StartRandom(squareObstacles, type);
    }

    // Update is called once per frame
    void Update()
    {
        ObstacleList(squareObstacles);
        listLength = randomObstacles.Count;

            if (listLength == 6)
            {
                RandomObstacle(squareObstacles);
            }

    }
}
