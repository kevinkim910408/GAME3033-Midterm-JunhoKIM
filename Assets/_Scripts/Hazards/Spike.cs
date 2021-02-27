using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField]  Material mat;

    [SerializeField] Transform[] waypoints;
    [SerializeField] int currentIndex;
    [SerializeField] float patrolSpeed = 3.0f;


    // components
    MeshRenderer rend;
    CanvasUI canvasUI;

    // Start is called before the first frame update
    void Start()
    {
        currentIndex = 0;

        rend = GetComponent<MeshRenderer>();
        canvasUI = FindObjectOfType<CanvasUI>();

    }

    private void Update()
    {
        rend.material = mat;

        Patrol();
    }

    private void Patrol()
    {
        if(transform.position != waypoints[currentIndex].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentIndex].position, patrolSpeed * Time.deltaTime);
        }
        else
        {
            currentIndex = (currentIndex + 1) % waypoints.Length;
        }
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
