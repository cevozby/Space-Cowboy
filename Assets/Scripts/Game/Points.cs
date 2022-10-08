using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{
    public int points = 0;
    public int maxPoints = 0;
    public int level = 1;
    

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI lastScoreText;
    [SerializeField] TextMeshProUGUI maxScoreText;

    #region Singleton
    public static Points instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }
    #endregion

    void Start()
    {
        if (!PlayerManager.gameOver)
        {
            scoreText.text = points.ToString();
        }
        
    }

    private void Update()
    {
        if (!PlayerManager.gameOver)
        {
            scoreText.text = points.ToString();
        }
        else
        {
            PlayerPrefs.SetInt("Score", points);
            MaxScore();
            lastScoreText.text = "Score: " + PlayerPrefs.GetInt("Score");
            maxScoreText.text = "Score: " + PlayerPrefs.GetInt("MaxScore");
        }
    }

    void MaxScore()
    {
        if(points > PlayerPrefs.GetInt("MaxScore"))
        {
            PlayerPrefs.SetInt("MaxScore", points);
            maxPoints = PlayerPrefs.GetInt("MaxScore");
        }
    }

    
}
