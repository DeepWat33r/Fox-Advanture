using Player;
using TMPro;
using UnityEngine;

namespace UI
{
    internal class UIController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI gemScore;
        // [SerializeField] public Slider health;

        public void UpdateGemScore(PlayerController playerController)
        {
            gemScore.text = playerController.NumbersOfGems.ToString();
        }
    }
}