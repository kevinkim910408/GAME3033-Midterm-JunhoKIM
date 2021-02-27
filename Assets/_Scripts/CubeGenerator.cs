using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    [SerializeField] GameObject cubePrefab = null;

    [SerializeField] int width = 5;
    [SerializeField] int height = 5;

    private void Start()
    {
        for(int i = 0; i < width; ++i)
        {
            for(int j = 0; j < height; ++j)
            {
                Instantiate(cubePrefab, new Vector3(i,0,j), Quaternion.identity);
                
            }
        }
    }

}
