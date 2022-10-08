using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    public List<GameObject> randomObstacles;

    protected int listLength;


    static float lastPoint;

    [SerializeField] float distance;
    [SerializeField] float minValue, maxValue;


    // Start is called before the first frame update
    void Start()
    {
        lastPoint = 0f;
        distance = 25f;
        minValue = -10f;
        maxValue = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        
        listLength = randomObstacles.Count;


    }

    protected void StartRandom(List<GameObject> obstacles, string type)
    {
        if(type == "Vertical")
        {
            for (int i = 0; i < obstacles.Count; i++)
            {
                obstacles[i].transform.position = new Vector3(obstacles[i].transform.position.x, Random.Range(minValue, maxValue),
                    obstacles[i].transform.position.z);
            }
        }
        else if (type == "Horizontal")
        {
            for (int i = 0; i < obstacles.Count; i++)
            {
                obstacles[i].transform.position = new Vector3(Random.Range(minValue, maxValue), obstacles[i].transform.position.y,
                    lastPoint + distance);
                Debug.Log(lastPoint);
                lastPoint += distance;
            }
        }
        

    }

    protected void ObstacleList(List<GameObject> obstacles)
    {
        if (PlayerManager.planeTouch)
        {
            obstacles[0].SetActive(false);
            randomObstacles.Add(obstacles[0]);
            obstacles.Remove(obstacles[0]);

            PlayerManager.planeTouch = false;
        }
    }


    protected void RandomObstacle(List<GameObject> obstacles)
    {
        int randomIndex;

        for (int i = listLength - 1; i >= 0; i--)
        {
            lastPoint = obstacles[obstacles.Count - 1].transform.position.z;

            randomIndex = Random.Range(0, i);
            randomObstacles[randomIndex].transform.position = new Vector3(randomObstacles[randomIndex].transform.position.x,
                randomObstacles[randomIndex].transform.position.y, lastPoint + distance);
            randomObstacles[randomIndex].SetActive(true);
            obstacles.Add(randomObstacles[randomIndex]);
            randomObstacles.Remove(randomObstacles[randomIndex]);
        }
        

        Points.instance.level++;
    }

    

}
