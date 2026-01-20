using UnityEngine;

using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Vida")]
    public int maxHealth = 3;
    private int currentHealth;

    [Header("Opciones")]
    public bool isPlayer = false;
    public float deathAnimationDuration = 0.5f;

    [Header("UI")]
    public HealthBarUI healthBar;

    private Animator anim;
    private bool isDead = false;

    void Awake()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        if (isPlayer && healthBar != null)
            healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        if (isPlayer && healthBar != null)
            healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (isDead) return;
        isDead = true;

        if (!isPlayer)
        {
            if (anim != null)
                anim.SetTrigger("Die");

            Invoke(nameof(Deactivate), deathAnimationDuration);
        }
        else
        {
            Debug.Log("Player muerto (sin pantalla de Game Over)");
        }
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
        currentHealth = maxHealth;
        isDead = false;
    }

    public float CurrentHealthNormalized()
    {
        return (float)currentHealth / maxHealth;
    }
}

