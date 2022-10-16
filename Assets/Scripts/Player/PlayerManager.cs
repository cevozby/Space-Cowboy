using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;

    public static bool planeTouch = false;

    [SerializeField] ParticleSystem explosion;
    [SerializeField] GameObject meteor;
    [SerializeField] GameObject rocks;

    bool meteorCheck;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        meteorCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        MeteorControl();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Point"))
        {
            Points.instance.points++;
            planeTouch = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            StartCoroutine(GameOver());
        }

        if (collision.gameObject.CompareTag("Meteor"))
        {
            StartCoroutine(MeteorOver());
        }
    }

    void MeteorControl()
    {
        //if((transform.position.x >= Mathf.Abs(15f) || transform.position.y >= Mathf.Abs(15f)) && !meteorCheck)
        //{
        //    meteorCheck = true;
        //    meteor.SetActive(true);
        //}
        if (transform.position.x >= 15f && !meteorCheck)
        {
            meteorCheck = true;
            meteor.transform.position = new Vector3(transform.position.x + 20f, transform.position.y + 20f, transform.position.z + 20f);
            meteor.SetActive(true);
        }
        else if (transform.position.x <= -15f && !meteorCheck)
        {
            meteorCheck = true;
            meteor.transform.position = new Vector3(transform.position.x - 20f, transform.position.y + 20f, transform.position.z + 20f);
            meteor.SetActive(true);
        }
        else if (transform.position.y >= Mathf.Abs(15f) && !meteorCheck)
        {
            meteorCheck = true;
            meteor.transform.position = new Vector3(transform.position.x, transform.position.y + 20f, transform.position.z + 20f);
            meteor.SetActive(true);
        }

    }

    IEnumerator GameOver()
    {
        explosion.Play();
        yield return new WaitForSeconds(1);
        //gameOver = true;
    }

    IEnumerator MeteorOver()
    {
        Destroy(meteor);
        explosion.Play();
        rocks.transform.position = new Vector3(transform.position.x, transform.position.y + 4.25f, transform.position.z);
        rocks.SetActive(true);
        yield return new WaitForSeconds(1);
        //gameOver = true;
    }

}
