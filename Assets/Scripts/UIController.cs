using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    private TextMeshProUGUI GemScore;

    // Start is called before the first frame update
    void Start()
    {
        GemScore = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateGemScore(PlayerController _playerController)
    {
        GemScore.text = _playerController.NumbersOfGems.ToString();
    }
}