using Player;
using UnityEngine;

namespace Items
{
    public class CherryController : MonoBehaviour
    {
        public int healthIncrease = 1;

        public void OnTriggerEnter2D(Collider2D other)
        {
            PlayerController playerHealth = other.GetComponent<PlayerController>();

            if(playerHealth != null && !playerHealth.IsAtMaxHealth())
            {
                playerHealth.IncreaseHealth(healthIncrease);
                Destroy(this.gameObject);
            }
        }
    }
}

