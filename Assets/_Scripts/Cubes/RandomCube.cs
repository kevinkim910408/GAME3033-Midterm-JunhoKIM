using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCube : Cube
{
    private void Update()
    {
        rend.material = mat;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            float randomRange = Random.Range(0.1f, 0.6f);
            mat.color = new Color(0.2f, randomRange, randomRange);
        }
    }
}
