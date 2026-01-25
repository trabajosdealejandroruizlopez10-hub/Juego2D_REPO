using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene("CinematicaInicial");  
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void MostrarControles()
    {
        
        SceneManager.LoadScene("Controles"); 
    }

    public void SalirControles()
    {
        
        SceneManager.LoadScene("SCN_Main_Menu"); 
    }
}