using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Player;
using SavingScripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndController : MonoBehaviour
{
    public Canvas canvas;
    public int[] levelStars;
    private int _levelIndex;
    private bool _isPlayer = false;
    
    public PlayerController player;
    [SerializeField]private int[] gemsForStars;

    public void Start()
    {
        _levelIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _isPlayer)
        {
            int currentStars = PlayerPrefs.GetInt(SceneManager.GetActiveScene().name); 
            if (currentStars < GetStars())
            {
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, GetStars());
            }
            if(SceneManager.GetActiveScene().buildIndex < SceneManager.GetActiveScene().buildIndex + 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            // Otherwise, load the first scene
            else
            {
                SceneManager.LoadScene(0);
            }
            SaveSystem.ResetPlayerData(SceneManager.GetActiveScene().name);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        canvas.gameObject.SetActive(true);
        _isPlayer = true;
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        canvas.gameObject.SetActive(false);
        _isPlayer = false;
    }

    private int GetStars()
    {
        int stars = 0;
        for (int i = 0; i < gemsForStars.Length; i++)
        {
            if (gemsForStars[i] <= player.NumbersOfGems)
            {
                stars++;
            }
        }

        return stars;
    }
}
