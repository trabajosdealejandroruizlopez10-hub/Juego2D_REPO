using UnityEngine;

public class DamageHitbox : MonoBehaviour
{
    public int damage = 1;
    public string[] targetTags = new string[] { "Enemy", "Player" }; // varios tags posibles

    private void OnTriggerEnter2D(Collider2D other)
    {
        bool isTarget = false;

        // Recorremos todos los tags permitidos
        foreach (string tag in targetTags)
        {
            if (other.CompareTag(tag))
            {
                isTarget = true;
                break;
            }
        }

        if (!isTarget) return;

        Health health = other.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(damage);
        }
    }
}
