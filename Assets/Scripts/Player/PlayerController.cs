using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;

    Vector2 moveDir;

    [SerializeField] float boundMin, boundMax;

    Rigidbody playerRB;

    int levelCheck;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        levelCheck = Points.instance.level;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!PlayerManager.gameOver)
        {
            Movement();
        }
        
    }

    private void Update()
    {
        if (!PlayerManager.gameOver)
        {
            RotateBound();
            //PositionBound();
        }
        SpeedUp();
    }

    void Movement()
    {
        // get the user's vertical and horizontal input
        //verticalInput = Input.GetAxis("Vertical");
        //horizontalInput = Input.GetAxis("Horizontal");

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * speed);
        //playerRB.velocity = Vector3.forward * speed;

        // tilt the plane up/down based on up/down arrow keys
        //transform.Rotate(Vector3.right * rotationSpeed * moveDir.y);
        //transform.Rotate(Vector3.up * rotationSpeed * moveDir.x);
        //transform.Rotate(new Vector3(1, 1, 0) * rotationSpeed * moveDir);
        playerRB.angularVelocity = new Vector3(1, 1, 0) * rotationSpeed * moveDir;


    }

    void OnMovement(InputValue value)
    {
        //moveDir = value.Get<Vector2>();
        moveDir.x = value.Get<Vector2>().y;
        moveDir.y = value.Get<Vector2>().x;
    }

    void SpeedUp()
    {
        if(levelCheck != Points.instance.level && speed < 0.5f)
        {
            speed += 0.025f;
            levelCheck++;
        }
    }

    #region Boundies
    //void PositionBound()
    //{
    //    float horizontalBound = Mathf.Clamp(transform.position.x, boundMin, boundMax);
    //    float verticalBound = Mathf.Clamp(transform.position.y, boundMin, boundMax);

    //    transform.position = new Vector3(horizontalBound, verticalBound, transform.position.z);
    //}

    void RotateBound()
    {
        float verticalBound = transform.eulerAngles.x;
        float horizontalBound = transform.eulerAngles.y;
        if (verticalBound >= 45f && verticalBound <= 90f)
        {
            verticalBound = 44.9f;
        }
        else if(verticalBound <= 315f && verticalBound >= 245f)
        {
            verticalBound = 315.1f;
        }

        if (horizontalBound >= 45f && horizontalBound <= 90f)
        {
            horizontalBound = 44.9f;
        }
        else if (horizontalBound <= 315f && horizontalBound >= 245f)
        {
            horizontalBound = 315.1f;
        }

        transform.rotation = Quaternion.Euler(verticalBound, horizontalBound, 0f);

    }
    #endregion
}
