using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] protected Material mat;

    // components
    protected MeshRenderer rend;

    protected Animator animator;

    protected PlayerController playerController;

    // boolean
    protected bool hasGivenScore;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
        animator = GetComponent<Animator>();
        playerController = FindObjectOfType<PlayerController>();
        hasGivenScore = false;

    }
}
