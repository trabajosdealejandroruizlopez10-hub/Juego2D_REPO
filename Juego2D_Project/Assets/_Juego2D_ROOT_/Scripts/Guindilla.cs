using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int value = 1;
    public string sceneToLoad;

    private bool collected = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !collected)
        {
            collected = true;

            // Ejemplo: sumar puntos
            // GameManager.instance.AddScore(value);

            // Cambiar de escena
            GameManager.instance.LoadScene(sceneToLoad);

            // Opcional si no cambias de escena inmediatamente
            // Destroy(gameObject);
        }
    }
}

