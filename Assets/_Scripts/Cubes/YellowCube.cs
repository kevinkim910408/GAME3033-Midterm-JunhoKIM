using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowCube : Cube
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rend.material = mat;
        }
    }
}