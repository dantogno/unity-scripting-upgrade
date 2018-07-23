using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullConditionalTest : MonoBehaviour {
    [SerializeField]
    string s;
    [SerializeField]
    Rigidbody rb;

    public GameObject myGameObject;

    // Use this for initialization
    void Start ()
    {
        s = null;
        if (s == null)
            Debug.Log($"S is null {s?.Length}");

        //rb?.AddForce(Vector3.forward);

        myGameObject?.SetActive(false);
        
        Debug.Log(Truncate(null, 1));

        var myRigidBody = GetComponent<Rigidbody>();

        //   GetComponent<AudioSource>()?.Play();

        GameObject go = GameObject.Find("nope");
        if (go != null)
            go.SetActive(false);

        go?.SetActive(false);
        
	}

    public static string Truncate(string value, int length)
    {        
            return value?.Substring(0, Math.Min(value.Length, length));              
    }

    private string Test(Rigidbody rb)
    {
        return rb?.ToString();
    }
}
