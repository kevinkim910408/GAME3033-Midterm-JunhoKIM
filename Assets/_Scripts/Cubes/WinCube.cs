using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCube : Cube
{
    CanvasUI canvasUI;


    private void Awake()
    {
        canvasUI = FindObjectOfType<CanvasUI>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rend.material = mat;
            canvasUI.WinCondition();
        }
    }
}
