using Player;
using UnityEngine;

namespace Objects
{
    public class FallingTrap : MonoBehaviour
    {
        public void OnTriggerEnter2D(Collider2D other)
        {
            PlayerController playerHealth = other.GetComponent<PlayerController>();
        
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(playerHealth.maxHealth);
            }
        }
    }
}
