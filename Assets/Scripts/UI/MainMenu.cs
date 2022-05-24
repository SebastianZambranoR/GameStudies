using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
   
    public void EscenaJuego()
    {
        SceneManager.LoadScene("Escena Principal");
    }

    public void SalirDelJuego()
    {
        Application.Quit();
    }

}
