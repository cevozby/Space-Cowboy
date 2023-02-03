using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornObstacle : ObstacleSpawn
{
    public List<GameObject> thornObstacles = new List<GameObject>();

    // Start is called before the first frame update
    void OnEnable()
    {
        StartRandom(thornObstacles);
    }

    // Update is called once per frame
    void Update()
    {
        ChangeObstacle(thornObstacles);
    }
}
