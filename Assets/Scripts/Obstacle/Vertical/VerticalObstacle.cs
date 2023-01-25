using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalObstacle : ObstacleSpawn
{
    public List<GameObject> verticalObstacles = new List<GameObject>();
    string type = "Vertical";

    //[SerializeField] List<Collider> pointCollision;

    //Collider pointCollide;

    void OnEnable()
    {
        StartRandom(verticalObstacles, type);
    }

    private void Start()
    {
        //pointCollide = verticalObstacles[0].GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        ObstacleList(verticalObstacles);
        //listLength = randomObstacles.Count;
        //if (listLength == 5 && Points.instance.level < 3)
        //   {
        //      RandomObstacle(verticalObstacles);
        //   }
        
    }
}
