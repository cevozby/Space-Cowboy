using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject horizontal, vertical, square;
    [SerializeField] List<GameObject> levels;

    [SerializeField] int levelPoint;

    int level;

    bool isLevelUp;

    // Start is called before the first frame update
    void Start()
    {
        ObstacleSpawn.isContinue = true;
        level = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if(Points.instance.points == 15)
        //{
        //    horizontal.SetActive(true);
        //}
        //if (Points.instance.points == 20)
        //{
        //    vertical.SetActive(false);
        //}
        //if (Points.instance.points == 30)
        //{
        //    horizontal.SetActive(false);
        //    square.SetActive(true);
        //}
        StopLevel();
        NextLevel();
        
        if (PlayerManager.gameOver)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    void StopLevel()
    {
        if(!isLevelUp && Points.instance.points == levelPoint / 2 + 1)
        {
            ObstacleSpawn.isContinue = false;
            Debug.Log("GameManager: " + ObstacleSpawn.isContinue);
        }
    }

    void NextLevel()
    {
        if(!isLevelUp && Points.instance.points % 20 == 15 && Points.instance.points != 0)
        {
            levels[level + 1].SetActive(true);
        }
        else if (!isLevelUp && Points.instance.points % 20 == 0 && Points.instance.points != 0)
        {
            isLevelUp = true;
            StartCoroutine(ClosedPreviousLevel());
        }
        else if (isLevelUp && Points.instance.points % 20 == 1)
        {
            isLevelUp = false;
        }
    }

    IEnumerator ClosedPreviousLevel()
    {
        yield return new WaitForSeconds(0.5f);
        ObstacleSpawn.isContinue = true;
        levels[level].SetActive(false);
        level++;
    }

}
