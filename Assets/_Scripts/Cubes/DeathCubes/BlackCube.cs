using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackCube : Cube
{
    CanvasUI canvasUI;

    private void Awake()
    {
        canvasUI = FindObjectOfType<CanvasUI>();
    }

    private void Update()
    {
        rend.material = mat;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DeathTime());
        }
    }

    IEnumerator DeathTime()
    {
        yield return new WaitForSeconds(3.0f);
        canvasUI.LoseCondition();
    }
}
