using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPatrol : MonoBehaviour
{
    //ÖNEMLÝ!!! Bu kod 2D ve 3D ortam fark etmeksizin ikisinde de çalýþýr.
    //NPC'nin devriye gezeceði bütün noktalarýn transformlarý
    [SerializeField] List<Transform> points;
    //NPC'nin devriye hýzý
    [SerializeField] float speed;
    //NPC'nin gideceði noktanýn indeksi
    int index = 0;

    private void FixedUpdate()
    {
        //NPC'nin gideceði hedef
        //Kendi (þu anki) pozisyonu, gideceði posizyon, gitme hýzý
        transform.position = Vector3.MoveTowards(transform.position, points[index].position, speed);
        //NPC bir sonraki noktayla arasýnda 0.1m'den daha kýsa bir mesafe varsa
        if(Vector3.Distance(transform.position, points[index].position) <= 0.1f)
        {
            //Ýndeksi 1 arttýrýyoruz, karakter bir sonraki noktaya yöneliyor
            index++;
            //Ýndeks listenin son elemanýna eþit olduysa indeksi sýfýrlýyoruz
            //Böylece belirlediðimiz noktlar arasýnda sürekli devriye geziyor
            if (index == points.Count) index = 0;
        }
    }

}
