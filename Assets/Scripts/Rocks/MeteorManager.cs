using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorManager : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float speed;

    //private void OnEnable()
    //{
    //    transform.position = new Vector3(player.position.x, player.position.y + 20f, player.position.z + 20f);
    //}

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed);
    }
}
