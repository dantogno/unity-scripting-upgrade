﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallerInfoTest : MonoBehaviour
{

	private void Start ()
    {
        ShowCallerInfo("Something happened.");		
	}

    public void ShowCallerInfo(string message,
            [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
            [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
    {
        Debug.Log($"message: {message}");
        Debug.Log($"member name: {memberName}");
        Debug.Log($"source file path: {sourceFilePath}");
        Debug.Log($"source line number: {sourceLineNumber}");
    }

}