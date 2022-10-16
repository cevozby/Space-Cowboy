using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float speed, width, hight;

    float timeCounter = 0;

    [SerializeField] Transform helper;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        timeCounter += Time.fixedDeltaTime * speed;
        helper.position = new Vector3(Mathf.Cos(timeCounter) * -width, Mathf.Sin(timeCounter) * hight, 0);

    }

    private void LateUpdate()
    {
        
        transform.LookAt(helper);
    }
}
