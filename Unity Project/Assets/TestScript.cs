using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
//using System.Threading.Tasks;
using UnityEngine;
using Newtonsoft.Json;
using System.Net.Http;
using static System.Math;
using Newtonsoft.Json.Linq;

public class TestScript : MonoBehaviour {

    // Auto implemented property initializer 4.x only!
    // public int MyIntProperty { get; } = 5;

    private readonly int[] scores = { 80, 20, 45, 15, 38, 60 };

	// Use this for initialization  
	 void Start ()
    {
        Action<string> anonymousFunction = n => {
            string s = n + " World";
            Debug.Log(s);
        };

        anonymousFunction("hello?");

        var scoresOver20 =
            scores.Where(s => s > 20);

        int highScore = scoresOver20.Max();

        var scoresOver10 =
            from score in scores
            where score > 10
            select score;

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
        Debug.Log(y + " working");

        int? z = null;
        int zz = z ?? 1;
        Debug.Log("Nullable type" + zz);

        TestParamsKeyword(1, 2, 3);
        //ShowCallerInfo();

        Debug.Log($"Thread: {Thread.CurrentThread.ManagedThreadId}");
       // var _ = Task.Run(TaskDemoAsync);

        Debug.Log($"Done with Async Demo at {Time.time}");
        Debug.Log($"Thread: {Thread.CurrentThread.ManagedThreadId}");
        UsingStaticDemo();
        gameObject.transform.Translate(10, 10, 10);

        DoAsyncStuff();
    }

    private async void DoAsyncStuff()
    {
        string result = await HttpClientTest();
        Debug.Log(result);
        TestAsyncStuff(result);
    }

    private void TestAsyncStuff(string json)
    {
         var pokemon = JsonConvert.DeserializeObject<Pokemon>(json);

    }

    class Pokemon
    {
        public string Name { get; set; }
        //[JsonExtensionData]
        //private IDictionary<string, JToken> additionalData;
    }



    private async Task<string> HttpClientTest()
    {
        HttpClient Client = new HttpClient();
        // Enter a pokedex number to find the pokemon with that ID <= 802
       return await Client.GetStringAsync("http://pokeapi.co/api/v2/pokemon/35/");
        
    }

    private void UsingStaticDemo()
    {
        Debug.Log($"Using static {Abs(Round(PI))}");
    }

    private async Task TaskDemoAsync()
    {
        Debug.Log($"Thread: {Thread.CurrentThread.ManagedThreadId}");
        Thread.Sleep(1000);
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

    private void TestParamsKeyword(params int[] nums)
    {
        foreach (var item in nums)
        {
            Debug.Log("parms working " + item);
        }
    }

    //private async Task MyTaskAsync()
    //{

    //}

    //public static void ShowCallerInfo([CallerMemberName]
    //  string callerName = null, [CallerFilePath] string
    //  callerFilePath = null, [CallerLineNumber] int callerLine = -1)
    //{
    //    Debug.Log("Caller Name: " + callerName);
    //    Debug.Log("Caller FilePath: " + callerFilePath);
    //    Debug.Log("Caller Line number: " + callerLine);
    //}


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

// Primary constructory, doesn't work in 3.5 or 4.x
//public class PriceBreak(int min)
//    {
//    }
