using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorManager : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float speed;

    [SerializeField] float sideDis, forwardDis, upDis;
    [SerializeField] float rightBound, upBound;

    private void OnEnable()
    {
        transform.position = SetMeteorPos();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed);
    }

    Vector3 SetMeteorPos()
    {
        Vector3 meteorPos = Vector3.zero;
        if(player.transform.position.x >= rightBound)
        {
            meteorPos = new Vector3(player.position.x + sideDis, player.position.y + upDis, player.position.z + forwardDis);
        }
        else if (player.transform.position.x <= -rightBound)
        {
            meteorPos = new Vector3(player.position.x - sideDis, player.position.y + upDis, player.position.z + forwardDis);
        }
        else if (Mathf.Abs(player.transform.position.y) >= upBound)
        {
            meteorPos = new Vector3(player.position.x, player.position.y + upDis, player.position.z - forwardDis);
        }
        return meteorPos;
    }
}
