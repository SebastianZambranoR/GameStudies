using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
   
    public void EscenaJuego()
    {
        SceneManager.LoadScene("Escena Principal");
    }

    public void Escenamenu()
    {
        SceneManager.LoadScene("Menu Principal");
    }

    public void SalirDelJuego()
    {
        Application.Quit();
    }

}
