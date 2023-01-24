using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float speed, width, hight;
    //Zamana ba�l� de�i�en de�i�ken
    float timeCounter = 0;
    //Kameram�z� d�nd�rmemizi sa�layacak obje
    [SerializeField] Transform helper;

    void FixedUpdate()
    {
        
        timeCounter += Time.fixedDeltaTime * speed;
        //Helper cos ve sin eksenleri etraf�nda zamana ba�l� olarak yer de�i�tiriyor
        //Width ve hight ne kadar geni�li�e ve y�ksekli�e sahip olaca��n� belirliyor
        //Width'i -1 ile �arp�lmas�n�n nedeni soldan ba�lamas�d�r, e�er sa�dan ba�lamas�n� istiyorsan�z + yapabilirsiniz
        helper.position = new Vector3(Mathf.Cos(timeCounter) * -width, Mathf.Sin(timeCounter) * hight, 0);

    }

    private void LateUpdate()
    {
        //Kamera helper'a odaklanacak, b�ylece s�rekli onu takip ederek d�necek
        transform.LookAt(helper);
    }
}
