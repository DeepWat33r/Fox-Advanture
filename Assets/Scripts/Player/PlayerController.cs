using System.Collections;
using UI;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]private GameManager2D gameManager2D;
        public int NumbersOfGems { get;  set; }
        public int maxHealth = 5;
        public int currentHealth;
        public HealthBar healthBar;
        public float repelForce = 10f;
        private Rigidbody2D _rb;
    
        public float flashDuration = 2.0f; // duration of flashing in seconds
        public float flashSpeed = 10.0f; // speed of flashing
        public bool playerFlash = false;

        public UnityEvent<PlayerController> onGemScored;

        private void Start()
        {
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
            _rb = transform.parent.GetComponent<Rigidbody2D>();
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
                gameManager2D.GameEnd();
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
        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);

            if (currentHealth <= 0)
            {
                // Handle player death here
                Debug.Log("Player has died!");
                gameManager2D.GameEnd();
            }
        }
        public void IncreaseHealth(int amount)
        {
            if(currentHealth < maxHealth)
            {
                currentHealth += amount;
                healthBar.SetHealth(currentHealth);
                if(currentHealth > maxHealth)
                {
                    currentHealth = maxHealth;
                }
            }
        }

        public bool IsAtMaxHealth()
        {
            return currentHealth == maxHealth;
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
                    playerFlash = true;
                    float t = (Time.time - startTime) * flashSpeed;
                    float alpha = Mathf.Lerp(originalAlpha, targetAlpha, Mathf.PingPong(t, 1));
                    renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, alpha);
                    yield return null;
                }

                playerFlash = false;
                // reset the transparency to its original value
                renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, originalAlpha);
            }
        }

    }
}