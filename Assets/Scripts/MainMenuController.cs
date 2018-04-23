using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    public GameObject creditsButton, creditsText, backButton, playButton;

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowCredits()
    {
        playButton.SetActive(false);
        creditsButton.SetActive(false);

        creditsText.SetActive(true);
        backButton.SetActive(true);
    }

    public void HideCredits()
    {
        playButton.SetActive(true);
        creditsButton.SetActive(true);

        creditsText.SetActive(false);
        backButton.SetActive(false);
    }
}
