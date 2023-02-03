using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareObstacle : ObstacleSpawn
{
    public List<GameObject> squareObstacles = new List<GameObject>();

    // Start is called before the first frame update
    void OnEnable()
    {
        StartRandom(squareObstacles);
    }

    // Update is called once per frame
    void Update()
    {
        ChangeObstacle(squareObstacles);
    }
}
