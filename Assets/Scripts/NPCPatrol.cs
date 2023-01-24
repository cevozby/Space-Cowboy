using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPatrol : MonoBehaviour
{
    //�NEML�!!! Bu kod 2D ve 3D ortam fark etmeksizin ikisinde de �al���r.
    //NPC'nin devriye gezece�i b�t�n noktalar�n transformlar�
    [SerializeField] List<Transform> points;
    //NPC'nin devriye h�z�
    [SerializeField] float speed;
    //NPC'nin gidece�i noktan�n indeksi
    int index = 0;

    private void FixedUpdate()
    {
        //NPC'nin gidece�i hedef
        //Kendi (�u anki) pozisyonu, gidece�i posizyon, gitme h�z�
        transform.position = Vector3.MoveTowards(transform.position, points[index].position, speed);
        //NPC bir sonraki noktayla aras�nda 0.1m'den daha k�sa bir mesafe varsa
        if(Vector3.Distance(transform.position, points[index].position) <= 0.1f)
        {
            //�ndeksi 1 artt�r�yoruz, karakter bir sonraki noktaya y�neliyor
            index++;
            //�ndeks listenin son eleman�na e�it olduysa indeksi s�f�rl�yoruz
            //B�ylece belirledi�imiz noktlar aras�nda s�rekli devriye geziyor
            if (index == points.Count) index = 0;
        }
    }

}
