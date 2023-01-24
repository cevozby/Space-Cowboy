using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMaterial : MonoBehaviour
{
    [SerializeField] Transform player;

    MaterialPropertyBlock block;

    [SerializeField] List<Renderer> renderers;

    float maxDistance = 25f;
    float threshold;

    // Start is called before the first frame update
    void OnEnable()
    {
        //distance = 0f;
        threshold = 1f;
        block = new MaterialPropertyBlock();

        //block.SetColor("_Edge_Color", new Color(Random.value, Random.value, Random.value, 1f));
        //block.SetFloat("_Edge_Width", Random.Range(0.05f, 0.015f));
        //block.SetFloat("_Noise_Scale", Random.Range(20, 50));
        //block.SetColor("_Color", new Color(Random.value, Random.value, Random.value));
        block.SetFloat("_Alpha", 1);
        SetAlpha(block);
    }

    private void OnDisable()
    {
        block.SetFloat("_Alpha", 1);
        SetAlpha(block);
    }

    // Update is called once per frame
    void Update()
    {
        
        //distance = ((transform.position.z - player.position.z) - maxDistance) / (-1 * maxDistance);
        threshold = (transform.position.z - player.position.z) / maxDistance;
        threshold = Mathf.Clamp(threshold, 0.5f, 1f);

        block.SetFloat("_Alpha", threshold);
        SetAlpha(block);
    }

    void SetAlpha(MaterialPropertyBlock block)
    {
        foreach(Renderer renderer in renderers)
        {
            renderer.SetPropertyBlock(block);
        }
    }
}
