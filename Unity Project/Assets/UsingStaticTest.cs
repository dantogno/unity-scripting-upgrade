using System.Collections;
using static UnityEngine.Mathf;
using UnityEngine;

public class UsingStaticTest : MonoBehaviour
{
	private void Start ()
    {        
        Debug.Log(RoundToInt(PI));
        // Output:
        // 3
    }
}
