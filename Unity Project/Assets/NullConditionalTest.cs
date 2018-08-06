using System;
using UnityEngine;

public class NullConditionalTest : MonoBehaviour {
    private void Start ()
    {
        string s = null;
        Debug.Log($"s is null, but ?. saving us from getting an exception for trying s?.Length {s?.Length}");        
        Debug.Log(Truncate(s, 1));

        // GetComponent<AudioSource>()?.Play();
        // You'd think ?. would circumvent null component exceptions,
        // but using ?. on Unity serialized fields (including components) doesn't work
        // as expected in the editor. The line below will still give you a missing component exception in the editor
        // unless you have an AudioSource component added to the GameObject this script is on.
        // Find out more here: https://blogs.unity3d.com/2014/05/16/custom-operator-should-we-keep-it/

        // On the other handthe following code will not throw an exception, even if there is no GameObject named "nope".
        // That's because the variable go isn't serialized in the Unity editor.
        GameObject go = GameObject.Find("nope");
        go?.SetActive(false);
        /* shorter than:
            if (go != null)
                go.SetActive(false);
        */
    }

    /// <summary>
    /// Will return null if value is null, instead of causing an exception.
    /// </summary>
    public static string Truncate(string value, int length)
    {        
            return value?.Substring(0, Math.Min(value.Length, length));              
    }

    private string Test(Rigidbody rb)
    {
        return rb?.ToString();
    }
}
