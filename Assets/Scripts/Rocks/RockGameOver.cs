using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockGameOver : MonoBehaviour
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

        posX = Random.Range(-23f, 23f);
        posY = Random.Range(-30f, -20f);
        posZ = Random.Range(14f, 20f);
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
        transform.Translate(Vector3.up * transformSpeed, Space.World);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 20f)
        {
            scale = Random.Range(1f, 3f);
            transform.localScale = new Vector3(scale, scale, scale);

            posX = Random.Range(-23f, 23f);
            posY = Random.Range(-30f, -20f);
            posZ = Random.Range(14f, 20f);
            transform.position = new Vector3(posX, posY, posZ);

            rotateDir.x = Random.Range(0f, 1f);
            rotateDir.y = Random.Range(0f, 1f);
            rotateDir.z = Random.Range(0f, 1f);
            rotateSpeed = Random.Range(minRotateSpeed, maxRotateSpeed);
        }
    }
}
