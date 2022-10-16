using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
    [SerializeField] float minRotateSpeed, maxRotateSpeed;
    [SerializeField] float minTransformSpeed, maxTransformSpeed;

    float rotateSpeed, transformSpeed;
    Vector3 rotateDir;

    [SerializeField] float posX, posY, posZ;

    float scale;

    // Start is called before the first frame update
    void Start()
    {
        scale = Random.Range(1f, 3f);
        transform.localScale = new Vector3(scale, scale, scale);

        posX = Random.Range(-35f, 35f);
        posY = Random.Range(-20f, 20f);
        posZ = Random.Range(27f, 40f);
        transform.position = new Vector3(posX, posY, posZ);
        transformSpeed = Random.Range(minTransformSpeed, maxTransformSpeed);

        rotateDir.x = Random.Range(0f, 1f);
        rotateDir.y = Random.Range(0f, 1f);
        rotateDir.z = Random.Range(0f, 1f);
        rotateSpeed = Random.Range(minRotateSpeed, maxRotateSpeed);
    }

    private void FixedUpdate()
    {
        transform.Rotate(rotateDir * rotateSpeed);
        transform.Translate(Vector3.back * transformSpeed, Space.World);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z < -17f)
        {
            scale = Random.Range(1f, 3f);
            transform.localScale = new Vector3(scale, scale, scale);

            posX = Random.Range(-35f, 35f);
            posY = Random.Range(-20f, 20f);
            posZ = Random.Range(27f, 40f);
            transform.position = new Vector3(posX, posY, posZ);

            rotateDir.x = Random.Range(0f, 1f);
            rotateDir.y = Random.Range(0f, 1f);
            rotateDir.z = Random.Range(0f, 1f);
            rotateSpeed = Random.Range(minRotateSpeed, maxRotateSpeed);
        }
    }
}
