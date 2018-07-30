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
    public string AutoPropertyInitializer { get; } = $"{nameof(AutoPropertyInitializer)} working!";

    public string PlayerHealthUiText => $"Player Health: {Health}";

    public int TestExpressionBodyReadyOnlyProperty => scores[0];

    private readonly int[] scores = { 80, 20, 45, 15, 38, 60 };

    event Action MyEvent;

    public int Health { get; set; }


    private void TestExpressionBodyFunction() => Debug.Log("Expression body function");
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody != null)
            other.attachedRigidbody.AddForce(Vector3.forward * 100);
    }

    enum Difficulty { Easy, Medium, Hard };
    private void TestNameOf()
    {
        Debug.Log(nameof(Difficulty.Easy));
    }

    private void RecordHighScore(string playerName)
    {
        if (playerName == null) throw new ArgumentNullException(nameof(playerName));
    }

// Use this for initialization  
void Start ()
    {

        ShowCallerInfo();
        dynamic d = 100;

        if (d is int)
            Debug.Log($"Value of d: {d}");
        if (d is string)
            Debug.Log($"Value of d: {d}");

       // var myRigidbody = GetComponent<Rigidbody>();

        //myRigidbody?.AddForce(Vector3.forward * 100);

        MyEvent?.Invoke();


        Debug.Log(String.Format("Player health: {0}", Health));
        Debug.Log($"Player took damage, new player health: {TakeDamage(5)}");
        Debug.Log($"Player healed, new player health: {Heal(5)}");

        Debug.Log(AutoPropertyInitializer);
        TestExpressionBodyFunction();
        Debug.Log($"Expression body property accessor: {TestExpressionBodyReadyOnlyProperty}");
        Action<string> anonymousFunction = n => {
            string s = n + " World";
            Debug.Log(s);
        };
        int? nullInt = 5;
        Debug.Log($"{nullInt?.ToString()} Null int shouldn't print anything before this.");

        MyEvent += () => Debug.Log("Testing events!"); 
        MyEvent?.Invoke();
        

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
        Action<Base> baseAction = (target) => { Debug.Log(target.GetType().Name + " covariance / contravariance worked"); };
        Action<Derived> derivedAction = baseAction;
        derivedAction(new Derived());
        string x = null;
        string y = x ?? "null coalescing operator";
        Debug.Log(y + " working");

        int? z = null;
        int zz = z ?? 1;
        Debug.Log("Nullable type" + zz);

        TestParamsKeyword(1, 2, 3);

        Debug.Log($"Thread: {Thread.CurrentThread.ManagedThreadId}");
       // var _ = Task.Run(TaskDemoAsync);

        Debug.Log($"Done with Async Demo at {Time.time}");
        Debug.Log($"Thread: {Thread.CurrentThread.ManagedThreadId}");
        UsingStaticDemo();
        gameObject.transform.Translate(10, 10, 10);

        // DoAsyncStuff();

        ExceptionFilterTest();
    }

    private void ExceptionFilterTest()
    {
        bool testExceptionFilter = true;
        try
        {
            
            throw new Exception("Error!");
        }
        catch (Exception) when (testExceptionFilter)
        {

            Debug.Log("In filter");
        }
    }

    private async void DoAsyncStuff()
    {
        //string result = await HttpClientTest();
        //Debug.Log(result);
        //TestAsyncStuff(result);
    }

    private void TestAsyncStuff(string json)
    {
         var pokemon = JsonConvert.DeserializeObject<Pokemon>(json);

    }





    //private async Task<string> HttpClientTest()
    //{
    //   // HttpClient Client = new HttpClient();
    //   // // Enter a pokedex number to find the pokemon with that ID <= 802
    //   //return await Client.GetStringAsync("http://pokeapi.co/api/v2/pokemon/35/");
        
    //}

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

    private int TakeDamage(int amount)
    {
        return Health -= amount;
    }

    private int Heal(int amount) => Health += amount;

    //private async Task MyTaskAsync()
    //{

    //}

    public static void ShowCallerInfo([CallerMemberName]
      string callerName = null, [CallerFilePath] string
      callerFilePath = null, [CallerLineNumber] int callerLine = -1)
    {
        Debug.Log("Caller Name: " + callerName);
        Debug.Log("Caller FilePath: " + callerFilePath);
        Debug.Log("Caller Line number: " + callerLine);
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
public class Pokemon
{
    public string Name { get; set; }
    //[JsonExtensionData]
    //private IDictionary<string, JToken> additionalData;
}
// Primary constructory, doesn't work in 3.5 or 4.x
//public class PriceBreak(int min)
//    {
//    }
