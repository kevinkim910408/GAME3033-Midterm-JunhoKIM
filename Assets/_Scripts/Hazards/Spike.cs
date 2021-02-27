using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] protected Material mat;

    // components
    MeshRenderer rend;
    CanvasUI canvasUI;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
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
            Debug.Log("In");
        }
    }

    IEnumerator DeathTime()
    {
        yield return new WaitForSeconds(3.0f);
        canvasUI.LoseCondition();
    }
}
