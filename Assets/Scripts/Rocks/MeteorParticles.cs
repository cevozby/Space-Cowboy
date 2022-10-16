using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorParticles : MonoBehaviour
{
    [SerializeField] float force;
    float x, y, z;

    Rigidbody rockRB;

    float scale;


    private void OnEnable()
    {
        rockRB = GetComponent<Rigidbody>();
        scale = Random.Range(0.3f, 1f);
        transform.localScale = new Vector3(scale, scale, scale);

        x = Random.Range(-1f, 1f);
        y = Random.Range(0.25f, 1f);
        z = Random.Range(-1f, 1f);

        rockRB.AddForce(new Vector3(x, y, z) * force, ForceMode.Impulse);
    }
}
