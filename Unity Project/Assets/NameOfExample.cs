using System;
using UnityEngine;

public class NameOfExample : MonoBehaviour
{
    enum Difficulty { Easy, Medium, Hard };
    private void TestNameOf()
    {
        Debug.Log(nameof(Difficulty.Easy));
    }

    private void RecordHighScore(string playerName)
    {
        if (playerName == null) throw new ArgumentNullException(nameof(playerName));
    }
}
