using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Vida")]
    public int maxHealth = 100;
    public int currentHealth;

    [Header("Respawn")]
    public Transform respawnPoint;

    [Header("Invencibilidad")]
    public float invincibilityTime = 1f;
    private bool isInvincible = false;

    void Start()
    {
        currentHealth = maxHealth;

        if (respawnPoint == null)
        {
            respawnPoint = GameObject.Find("RespawnPoint")?.transform;
        }
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible) return;

        currentHealth -= damage;

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

        
        if (respawnPoint != null)
        {
            transform.position = respawnPoint.position;
        }

      
        StartCoroutine(Invincibility());
    }

    System.Collections.IEnumerator Invincibility()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibilityTime);
        isInvincible = false;
    }
}
