﻿using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;

public class JSONTest : MonoBehaviour {

	// Use this for initialization
	private async void Start ()
    {
        var pokemon = 
            JsonConvert.DeserializeObject<Pokemon>(await GetJsonFromURL("http://pokeapi.co/api/v2/pokemon/35/"));

        Debug.Log($"You got: {pokemon.Name}");
    }

    private async Task<string> GetJsonFromURL(string url)
    {
        string result = await Activator.CreateInstance<HttpClient>()
            .GetStringAsync(url);

        Debug.Log($"JSON: {result}");

        return result;
    }
	
}