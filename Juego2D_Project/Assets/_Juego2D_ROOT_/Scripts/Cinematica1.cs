using UnityEngine;
using UnityEngine.SceneManagement;  // Necesario para cambiar de escena

public class SceneController : MonoBehaviour
{
    public string nextSceneName = "TUTO_FUEGO";
    public float waitTime = 47f;

    void Start()
    {

        Invoke("ChangeScene", waitTime);
    }

    void ChangeScene()
    {
    
        SceneManager.LoadScene(nextSceneName);
    }
}