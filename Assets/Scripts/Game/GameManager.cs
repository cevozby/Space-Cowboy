using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject horizontal, vertical, square;
    [SerializeField] List<GameObject> levels;

    int level;

    bool isLevelUp;

    // Start is called before the first frame update
    void Start()
    {
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

        NextLevel();

        if (PlayerManager.gameOver)
        {
            SceneManager.LoadScene("GameOver");
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
            levels[level].SetActive(false);
            level++;
        }
        else if (isLevelUp && Points.instance.points % 20 == 1)
        {
            isLevelUp = false;
        }
    }

}
