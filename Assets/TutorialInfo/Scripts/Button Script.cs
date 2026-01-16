using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class ButtonScript : MonoBehaviour
{
    public TMP_Text buttonText;
    AudioSource audioSource;
    public AudioClip sfx1;  // sound effect asset from sfx folder
    int sceneIndex;
    int sceneToOpen;
    int sceneNumber;

// Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (!PlayerPrefs.HasKey("previousScene" + sceneIndex))
        {
            PlayerPrefs.SetInt("previousScene" + sceneIndex, sceneIndex);
        }

        sceneToOpen = PlayerPrefs.GetInt("previousScene" + sceneIndex);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonMethod()
    {
        buttonText.text = "Clicked!";

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        print("The button is working.");

        FindFirstObjectByType<AudioManagerScript>().Play("Edited floop");
    }

    public void ChangeMusicVolume(float volume)
    {
        AudioManagerScript.instance.musicVolume = volume;
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Level 1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void GoToLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void GoToOptions()
    {
        SceneManager.LoadScene("Options");
    }

    public void GoToLevel1Game()
    {
        SceneManager.LoadScene("Level 1 Game");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void GoToTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void OnButtonClick()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneToOpen);
        PlayerPrefs.SetInt("previousScene" + sceneNumber, currentScene);
        SceneManager.LoadScene(sceneNumber);
    }

    public void LoadNextInBuild()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void PlaySoundEffect()
    {
        audioSource.PlayOneShot(sfx1, 0.7f); // play audio clip with volume 0.7
    }
    
}
