using System;
using System.Collections;
using System.Collections.Generic;
using Audio;
using SavingScripts;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public string soundName;
    public void Awake()
    {
        //FindObjectOfType<AudioManager>().PlaySound(soundName);
    }

    public void PlayGame(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        SaveSystem.LoadPlayer(SceneManager.GetSceneByBuildIndex(sceneIndex).name);
    }

    public void QuitGame()
    {
        Debug.Log("Game Quit!");
        Application.Quit();
    }
}
