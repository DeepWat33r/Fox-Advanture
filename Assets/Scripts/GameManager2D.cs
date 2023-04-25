using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2D : MonoBehaviour
{
    [SerializeField] private PlayerMovement2D playerMovement;
    public void GameEnd()
    {
        Debug.Log("GameEnd code");
        //playerMovement.enabled = false;
    }
}
