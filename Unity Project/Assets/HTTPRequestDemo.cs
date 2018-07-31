using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class HttpRequestDemo : MonoBehaviour
{
    [SerializeField]
    private Text outputText, errorMessageText;

    [SerializeField]
    private InputField input;

    [SerializeField]
    private GameObject errorMessagePanel;

    [SerializeField]
    private Button submitButton;

    [SerializeField]
    private AudioSource applause, ambience;

    [SerializeField]
    private ParticleSystem confetti;

    HttpClient client;

    private void Awake()
    {
        HideErrorMessage();
        client = new HttpClient();
        client.BaseAddress = new Uri("http://pokeapi.co/api/v2/pokemon/");
    }

    public async void SubmitButtonPressed()
    {
        const string questionMarks = "???";
        HideErrorMessage();
        submitButton.interactable = false;
        outputText.text = questionMarks;
        if (ValidateEntryText(input.text))
        {
            try
            {
                outputText.text = $"Number {input.text}...";
                dynamic result = JsonConvert.DeserializeObject(
                    await GetJsonForEntryNumber(int.Parse(input.text)));
                input.text = string.Empty;
                var capitalizedName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase((string)result.name);
                outputText.text += $"\nYou got {capitalizedName}!";
                confetti.Play();
                applause.Play();
                ambience.Stop();
                await Task.Delay(TimeSpan.FromSeconds(applause.clip.length));
                outputText.text = questionMarks;
                ambience.Play();
            }
            catch (Exception e)
            {
                ShowErrorMessage($"Something went wrong, please try again later!\n" +
                    $"Error: {e.Message}");
            }
        }
        else
        {
            ShowErrorMessage("Invalid entry!");
        }
        submitButton.interactable = true;
    }

    private bool ValidateEntryText(string entryText)
    {
        const int minValidEntry = 1;
        const int maxValidEntry = 802;
        int entryNumber;
        bool isValidEntry = false;

        if (int.TryParse(entryText, out entryNumber))
        {
            isValidEntry = entryNumber >= minValidEntry && entryNumber <= maxValidEntry;
        }

        return isValidEntry;
    }

    private void ShowErrorMessage(string message)
    {
        errorMessageText.text = message;
        errorMessagePanel.SetActive(true);
    }

    private void HideErrorMessage()
    {
        errorMessagePanel.SetActive(false);
    }

    private async Task<string> GetJsonForEntryNumber(int entryNumber)
    {
            var result = await client.GetStringAsync($"{entryNumber}/");
            Debug.Log($"JSON: {result}");
            return result;        
    }
}

