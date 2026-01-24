using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene("TUTO_FUEGO");  
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void MostrarControles()
    {
        // Aquí puedes mostrar un panel o abrir otra escena con los controles
        Debug.Log("Controles");
    }
}