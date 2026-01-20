using UnityEngine;

public class Guindilla : MonoBehaviour
{
    public CollectibleSceneChange sceneChanger;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            sceneChanger.StartTransition();
            gameObject.SetActive(false); // desaparece la guindilla
        }
    }
}

