using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackCube : Cube
{
    private void Update()
    {
        rend.material = mat;
    }
}
