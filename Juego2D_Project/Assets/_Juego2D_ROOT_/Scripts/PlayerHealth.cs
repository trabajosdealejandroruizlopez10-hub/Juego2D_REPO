using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    [Header("Vida")]
    public int maxHealth = 100;
    public int currentHealth;

    [Header("Respawn")]
    public Transform respawnPoint;

    [Header("Invencibilidad")]
    public float invincibilityTime = 1f;
    public float blinkInterval = 0.1f;
    private bool isInvincible = false;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    void Start()
    {
        currentHealth = maxHealth;

        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        if (respawnPoint == null)
        {
            GameObject rp = GameObject.Find("RespawnPoint");
            if (rp != null)
                respawnPoint = rp.transform;
        }
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible) return;

        currentHealth -= damage;
        Debug.Log("Vida actual: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(Invincibility());
        }
    }

    void Die()
    {
        Respawn();
    }

    void Respawn()
    {
        
        currentHealth = maxHealth;

        
        if (rb != null)
            rb.linearVelocity = Vector2.zero;

        
        if (respawnPoint != null)
            transform.position = respawnPoint.position;

        
        StartCoroutine(Invincibility());
    }

    IEnumerator Invincibility()
    {
        isInvincible = true;

        float timer = 0f;

        while (timer < invincibilityTime)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(blinkInterval);
            timer += blinkInterval;
        }

        spriteRenderer.enabled = true;
        isInvincible = false;
    }
}
