using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    //public List<GameObject> randomObstacles;

    public static bool isContinue;

    static float lastPoint;

    [SerializeField] float distance;


    // Start is called before the first frame update
    void Start()
    {
        lastPoint = 0f;
        distance = 25f;
    }

    // Update is called once per frame
    void Update()
    {
    }

    protected void StartRandom(List<GameObject> obstacles)
    {
        for (int i = 0; i < obstacles.Count; i++)
        {
            if(i == 0) obstacles[i].transform.position = new Vector3(obstacles[i].transform.position.x, obstacles[i].transform.position.y,
                lastPoint + distance);
            else obstacles[i].transform.position = new Vector3(obstacles[i].transform.position.x, obstacles[i].transform.position.y,
                obstacles[i - 1].transform.position.z + distance);
        }
        
    }

    protected void ChangeObstacle(List<GameObject> obstacles)
    {
        if (PlayerManager.planeTouch)
        {
            GameObject obstacle = obstacles[0];
            obstacle.SetActive(false);
            if (isContinue) SetForwardPosition(obstacle, obstacles[obstacles.Count - 1].transform);
            //else obstacle.SetActive(false);
            obstacles.RemoveAt(0);
            obstacles.Add(obstacle);

            PlayerManager.planeTouch = false;
        }
        
    }

    void SetForwardPosition(GameObject obstacle, Transform lastObstacle)
    {
        obstacle.transform.position = new Vector3(obstacle.transform.position.x, obstacle.transform.position.y,
                    lastObstacle.position.z  + distance);
        lastPoint = obstacle.transform.position.z;
        obstacle.SetActive(true);
    }


    //protected void RandomObstacle(List<GameObject> obstacles)
    //{
    //    int randomIndex;

    //    for (int i = listLength - 1; i >= 0; i--)
    //    {
    //        lastPoint = obstacles[obstacles.Count - 1].transform.position.z;
    //        Debug.Log("Random last point: " + lastPoint);
    //        randomIndex = Random.Range(0, i);
    //        randomObstacles[randomIndex].transform.position = new Vector3(randomObstacles[randomIndex].transform.position.x,
    //            randomObstacles[randomIndex].transform.position.y, lastPoint + distance);
    //        randomObstacles[randomIndex].SetActive(true);
    //        obstacles.Add(randomObstacles[randomIndex]);
    //        randomObstacles.RemoveAt(randomIndex);
    //    }
        

    //    Points.instance.level++;
    //}

    

}
