using UnityEngine;

namespace SavingScripts
{
    public class CheckPoint : MonoBehaviour
    {
        public string playerTag = "Player"; 
        public GameManager2D gameManager2D;
        private void OnTriggerEnter2D(Collider2D other) {
            // Check if the object that entered the trigger is the player
            if (other.CompareTag(playerTag)) {
                SaveGame(); // Call your save game function
                gameObject.SetActive(false); 
            }
        }
        private void SaveGame() {
            gameManager2D.SavePlayer();
        }
    }
}
