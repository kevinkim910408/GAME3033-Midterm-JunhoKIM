using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCube : Cube
{


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !hasGivenScore)
        {
            hasGivenScore = true;
            playerController.currentScore += 10;
            rend.material = mat;


            StartCoroutine(DropCube());
        }
    }

    IEnumerator DropCube()
    {
        animator.SetBool("isBlue", true);
        yield return new WaitForSeconds(3.0f);
        Destroy(gameObject);
    }
}
