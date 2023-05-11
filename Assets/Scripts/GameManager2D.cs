using System;
using System.Collections;
using System.Collections.Generic;
using SavingScripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager2D : MonoBehaviour
{
    [SerializeField]private PlayerController playerController;
    [SerializeField]private PlayerMovement2D playerMovement2D;
    public GameObject gameEndUI;
    public void GameEnd()
    {
        gameEndUI.SetActive(true);
        Time.timeScale = 0f;
        Destroy(playerMovement2D.gameObject);
        Debug.Log("GameEnd code");
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayerData(playerController, playerMovement2D, SceneName.GetSceneNameByBuildIndex(SceneManager.GetActiveScene().buildIndex));
    }

    public void LoadPlayer()
    {
        PlayerData playerData = SaveSystem.LoadPlayer(SceneName.GetSceneNameByBuildIndex(SceneManager.GetActiveScene().buildIndex));

        playerController.currentHealth = playerData.currentHealth;
        playerController.NumbersOfGems = playerData.gemsCollected;

        Vector3 position;
        position.x = playerData.position[0];
        position.y = playerData.position[1];
        position.z = playerData.position[2];
        playerMovement2D.transform.position = position;

    }
}
