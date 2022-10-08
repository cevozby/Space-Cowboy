using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject horizontal, vertical, square;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Points.instance.points == 20)
        {
            vertical.SetActive(false);
            horizontal.SetActive(true);
        }
        if (Points.instance.points == 40)
        {
            horizontal.SetActive(false);
            square.SetActive(true);
        }
    }
}
