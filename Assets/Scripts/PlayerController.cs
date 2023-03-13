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
    public float flashDuration = 2.0f; // duration of flashing in seconds
    public float flashSpeed = 10.0f; // speed of flashing


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
    

    public void TakeDamage(int damage, Vector2? repelDirection)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            // Handle player death here
            Debug.Log("Player has died!");
        }

        if (repelDirection != null)
        {
            Rigidbody2D rb = transform.parent.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(repelDirection.Value.normalized * repelForce, ForceMode2D.Impulse);
            }
        }

        // make the parent object flash
        StartCoroutine(FlashObject());
    }

    private IEnumerator FlashObject()
    {
        Renderer renderer = transform.parent.GetComponent<Renderer>();
        if (renderer != null)
        {
            // flash the object by changing its transparency
            float originalAlpha = 1;
            float targetAlpha = 0.5f; // set the target alpha value here
            float startTime = Time.time;
            while (Time.time < startTime + flashDuration)
            {
                float t = (Time.time - startTime) * flashSpeed;
                float alpha = Mathf.Lerp(originalAlpha, targetAlpha, Mathf.PingPong(t, 1));
                renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, alpha);
                yield return null;
            }
            // reset the transparency to its original value
            renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, originalAlpha);
        }
    }

}