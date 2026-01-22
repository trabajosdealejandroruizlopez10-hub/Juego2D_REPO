using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Config")]
    public int maxHealth = 5;
    public bool isPlayer = false;

    [Header("State")]
    public int currentHealth;

    private Vector3 startPosition;
    private Animator anim;
    private Rigidbody2D rb;

    private bool isDead = false;

    private void Awake()
    {
        currentHealth = maxHealth;
        startPosition = transform.position;

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        // Registrar enemigos en ResetManager
        if (!isPlayer)
        {
            if (ResetManager.Instance != null)
            {
                ResetManager.Instance.RegisterEnemy(this);
            }
            else
            {
                Debug.LogError("❌ No existe ResetManager en la escena");
            }
        }
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;

        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;

        // ENEMIGOS
        if (!isPlayer)
        {
            if (anim != null)
            {
                anim.SetTrigger("Die");
            }

            if (rb != null)
                rb.simulated = false;

            Invoke(nameof(DisableEnemy), 1.5f);
        }
        else
        {
            // PLAYER
            RespawnPlayer();
        }
    }

    void RespawnPlayer()
    {
        // Resetear enemigos
        if (ResetManager.Instance != null)
        {
            ResetManager.Instance.ResetLevel();
        }
        else
        {
            Debug.LogError("❌ No existe ResetManager en la escena");
        }

        // Mover al respawn
        if (RespawnManager.Instance != null)
        {
            transform.position = RespawnManager.Instance.GetRespawnPoint();
        }
        else
        {
            Debug.LogError("❌ No existe RespawnManager en la escena");
        }

        // Restaurar vida
        currentHealth = maxHealth;
        isDead = false;

        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    void DisableEnemy()
    {
        gameObject.SetActive(false);
    }

    // Llamado por ResetManager
    public void ResetEnemy()
    {
        gameObject.SetActive(true);

        transform.position = startPosition;
        currentHealth = maxHealth;
        isDead = false;

        if (rb != null)
        {
            rb.simulated = true;
            rb.linearVelocity = Vector2.zero;
        }

        if (anim != null)
        {
            anim.Rebind();
            anim.Update(0f);
        }
    }
}
