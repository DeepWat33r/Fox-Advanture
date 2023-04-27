using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2D : MonoBehaviour
{
    public GameObject gameEndUI;
    public void GameEnd()
    {
        gameEndUI.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("GameEnd code");
    }
}
