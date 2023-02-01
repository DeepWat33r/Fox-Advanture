using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gemScore;
    [SerializeField] public Slider health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateGemScore(PlayerController playerController)
    {
        gemScore.text = playerController.NumbersOfGems.ToString();
    }
    public void UpdateHealth(PlayerController playerController)
    {
        health.value = playerController.Health;
    }
}