using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float speed, width, hight;
    //Zamana baðlý deðiþen deðiþken
    float timeCounter = 0;
    //Kameramýzý döndürmemizi saðlayacak obje
    [SerializeField] Transform helper;

    void FixedUpdate()
    {
        
        timeCounter += Time.fixedDeltaTime * speed;
        //Helper cos ve sin eksenleri etrafýnda zamana baðlý olarak yer deðiþtiriyor
        //Width ve hight ne kadar geniþliðe ve yüksekliðe sahip olacaðýný belirliyor
        //Width'i -1 ile çarpýlmasýnýn nedeni soldan baþlamasýdýr, eðer saðdan baþlamasýný istiyorsanýz + yapabilirsiniz
        helper.position = new Vector3(Mathf.Cos(timeCounter) * -width, Mathf.Sin(timeCounter) * hight, 0);

    }

    private void LateUpdate()
    {
        //Kamera helper'a odaklanacak, böylece sürekli onu takip ederek dönecek
        transform.LookAt(helper);
    }
}
