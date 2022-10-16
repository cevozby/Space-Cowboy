using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMaterial : MonoBehaviour
{
    //[SerializeField] Material upMat;
    [SerializeField] Transform player;

    MaterialPropertyBlock block;

    Renderer renderer;

    float distance = 0f;
    float maxDistance = 25f;

    // Start is called before the first frame update
    void OnEnable()
    {
        distance = 0f;
        renderer = GetComponent<Renderer>();
        block = new MaterialPropertyBlock();
        
        block.SetColor("_Edge_Color", new Color(Random.value, Random.value, Random.value, 1f));
        block.SetFloat("_Edge_Width", Random.Range(0.05f, 0.015f));
        block.SetFloat("_Noise_Scale", Random.Range(20, 50));
        renderer.SetPropertyBlock(block);
    }

    private void OnDisable()
    {
        block.SetFloat("_Threshold", -0.1f);
        renderer.SetPropertyBlock(block);
    }

    // Update is called once per frame
    void Update()
    {
        
        distance = ((transform.position.z - player.position.z) - maxDistance) / (-1 * maxDistance);
        Debug.Log(distance);

        block.SetFloat("_Threshold", distance);
        renderer.SetPropertyBlock(block);
        //upMat.SetFloat("_Threshold", distance);
    }
}
