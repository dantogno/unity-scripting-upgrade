using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SyntaxTree.VisualStudio.Bridge;
//using Newtonsoft.Json;
//using System.Net.http

public class TestScript : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        OptionalArgument();
        Dynamic();
        NamedArgument(message: " working");

        string str = "Extension Method";
        Debug.Log(str.ExtensionMethod());

        // covariance & contravariance
        Action<Base> b = (target) => { Debug.Log(target.GetType().Name + " covariance / contravariance worked"); };
       // Action<Derived> d = b;
       // d(new Derived());
        string x = null;
        string y = x ?? "null coalescing operator";
        int? z = null;
        int zz = z ?? 1;
        Debug.Log("Nullable type" + zz);
    }

    private void NamedArgument(string message)
    {
        Debug.Log("named argument" + message);
    }

    private void OptionalArgument(string message = "optional argument working.")
    {
        Debug.Log(message);
    }

    private void Dynamic()
    {
        //dynamic dyn = "dynamic working";
        //Debug.Log(dyn);
    }


}

public static class ExtensionTest
{
    public static string ExtensionMethod(this string str)
    {
        return str + " is working";
    }
}

public class Base { }
public class Derived : Base { }
