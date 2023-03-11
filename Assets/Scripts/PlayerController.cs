using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    public int NumbersOfGems { get; private set; }
    public int maxHealth = 5;
    public int currentHealth;
    public HealthBar healthBar;
    public float repelForce = 10f;
    private Rigidbody2D rb;

    public UnityEvent<PlayerController> onGemScored;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        rb = transform.parent.GetComponent<Rigidbody2D>(); // get reference to Rigidbody2D component from parent object
    }

    public void GemCollected()
    {
        NumbersOfGems++;
        onGemScored.Invoke(this);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (rb != null)
        {
            Vector2 repelDirection = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            repelDirection.Normalize();
            rb.AddForce(repelDirection * repelForce, ForceMode2D.Impulse);
        }
    }
}