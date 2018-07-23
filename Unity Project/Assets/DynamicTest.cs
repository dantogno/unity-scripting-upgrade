using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicTest : MonoBehaviour
{

    private void Start()
    {
        dynamic dyn = 100;

       dyn += 6;

        Debug.Log($"Value of dyn: {dyn}");
    }

}
