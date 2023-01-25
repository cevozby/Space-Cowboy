using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    public List<GameObject> randomObstacles;

    protected int listLength;

    public static bool isContinue;

    static float lastPoint;

    [SerializeField] float distance;
    [SerializeField] float minValue, maxValue;


    // Start is called before the first frame update
    void Start()
    {
        //isContinue = true;
        //Debug.Log("Start: " + isContinue);
        //lastPoint = -50f;
        distance = 25f;
        minValue = -10f;
        maxValue = 10f;
        //Debug.Log(lastPoint);
    }

    // Update is called once per frame
    void Update()
    {
        
        //listLength = randomObstacles.Count;


    }

    protected void StartRandom(List<GameObject> obstacles, string type)
    {
        if(type == "Vertical")
        {
            for (int i = 0; i < obstacles.Count; i++)
            {
                lastPoint += distance;
                //Debug.Log(lastPoint);
                obstacles[i].transform.position = new Vector3(obstacles[i].transform.position.x, Random.Range(minValue, maxValue),
                    lastPoint + distance);
            }
        }
        else if (type == "Horizontal")
        {
            for (int i = 0; i < obstacles.Count; i++)
            {
                lastPoint += distance;
                obstacles[i].transform.position = new Vector3(Random.Range(minValue, maxValue), obstacles[i].transform.position.y,
                    lastPoint + distance);
                //Debug.Log("Distance plus last point: " + (lastPoint + distance));
                
            }
        }
        

    }

    protected void ObstacleList(List<GameObject> obstacles)
    {
        if (PlayerManager.planeTouch)
        {
            //obstacles[0].SetActive(false);
            //randomObstacles.Add(obstacles[0]);
            //obstacles.Remove(obstacles[0]);
            Debug.Log("Function: " + isContinue);
            GameObject obstacle = obstacles[0];
            if (isContinue) VerticleRandom(obstacle);
            else obstacle.SetActive(false);
            obstacles.RemoveAt(0);
            obstacles.Add(obstacle);
            PlayerManager.planeTouch = false;
        }
        
    }

    void VerticleRandom(GameObject obstacle)
    {
        lastPoint += distance;
        //Debug.Log(lastPoint);
        obstacle.transform.position = new Vector3(obstacle.transform.position.x, Random.Range(minValue, maxValue),
                    lastPoint + distance);
    }

    void HorizontalRandom(GameObject obstacle)
    {
        lastPoint += distance;
        obstacle.transform.position = new Vector3(Random.Range(minValue, maxValue), obstacle.transform.position.x,
                    lastPoint + distance);
    }


    protected void RandomObstacle(List<GameObject> obstacles)
    {
        int randomIndex;

        for (int i = listLength - 1; i >= 0; i--)
        {
            lastPoint = obstacles[obstacles.Count - 1].transform.position.z;
            Debug.Log("Random last point: " + lastPoint);
            randomIndex = Random.Range(0, i);
            randomObstacles[randomIndex].transform.position = new Vector3(randomObstacles[randomIndex].transform.position.x,
                randomObstacles[randomIndex].transform.position.y, lastPoint + distance);
            randomObstacles[randomIndex].SetActive(true);
            obstacles.Add(randomObstacles[randomIndex]);
            randomObstacles.RemoveAt(randomIndex);
        }
        

        Points.instance.level++;
    }

    

}
