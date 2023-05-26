using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

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
