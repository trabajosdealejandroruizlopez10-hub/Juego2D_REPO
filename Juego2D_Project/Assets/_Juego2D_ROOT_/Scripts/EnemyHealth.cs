using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    [Header("Vida")]
    public int maxHealth = 50;
    private int currentHealth;

    [Header("Parpadeo al recibir daño")]
    public float flashDuration = 0.6f;   
    public float flashInterval = 0.1f;   

    [Header("Drop al morir")]
    public GameObject guindilla;         

    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private Coroutine flashCoroutine;

    void Start()
    {
        currentHealth = maxHealth;

        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;

        
        if (guindilla != null)
            guindilla.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        
        if (flashCoroutine != null)
            StopCoroutine(flashCoroutine);

        flashCoroutine = StartCoroutine(FlashRed());

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    IEnumerator FlashRed()
    {
        float timer = 0f;

        while (timer < flashDuration)
        {
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(flashInterval);

            spriteRenderer.color = originalColor;
            yield return new WaitForSeconds(flashInterval);

            timer += flashInterval * 2f;
        }

        spriteRenderer.color = originalColor;
    }

    void Die()
    {
        
        if (guindilla != null)
        {
            guindilla.transform.SetParent(null); 
            guindilla.SetActive(true);
        }

        Destroy(gameObject);
    }
}



