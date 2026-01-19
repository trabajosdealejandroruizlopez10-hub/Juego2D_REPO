using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 5;
    private int currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log(name + " recibió " + amount + " daño. Vida: " + currentHealth);

        if (currentHealth <= 0)
            Die();
    }

    private void Die()
    {
        Debug.Log(name + " ha muerto");
        Destroy(gameObject);
    }
}
