using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] protected Material mat;

    // components
    protected MeshRenderer rend;



    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
    }
}
