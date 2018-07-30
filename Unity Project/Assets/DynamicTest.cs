using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicTest : MonoBehaviour
{

    private void Start()
    {
        dynamic d = 100;
        d += 6;
        d += ", one hundred and six.";
        Debug.Log($"Value of d is {d}");
        // Output: Value of d is 106, one hundred and six.


        d = JObject.Parse("{number:1000, str:'string', array: [1,2,3,4,5,6]}");

        Debug.Log($"d.number: {d.number}");
 
    }

}
