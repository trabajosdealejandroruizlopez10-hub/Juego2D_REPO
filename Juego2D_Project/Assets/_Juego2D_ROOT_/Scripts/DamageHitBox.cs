using UnityEngine;

public class DamageHitbox : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] private string targetTag = "Enemy";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(targetTag))
        {
            Health health = collision.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }
}
