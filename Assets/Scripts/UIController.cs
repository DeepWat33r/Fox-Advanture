using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gemScore;
    // [SerializeField] public Slider health;

    public void UpdateGemScore(PlayerController playerController)
    {
        gemScore.text = playerController.NumbersOfGems.ToString();
    }
}