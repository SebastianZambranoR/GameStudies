using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    [SerializeField] private GameObject finalPanel;

    [SerializeField] private Text finalText;
    // Start is called before the first frame update
    void Start()
    {
        EconomyManager.Instance.OnFinishGame += CalculateResult;
    }

    void CalculateResult()
    {
        int playerTotal = EconomyManager.Instance.GetPlayerTotal();

        if (playerTotal >= 100000)
        {
            finalPanel.SetActive(true);
            finalText.text = "¡Felicidades!, lo has logrado, te has convertido en un trader exitoso";
        }

        {
            finalPanel.SetActive(true);
            finalText.text = "Por desgracia, no se ha logrado la meta... Mejor suerte la proxima";
        }
    }

    public void BackToMain()
    {
        SceneManager.LoadScene("Menu Principal");
    }
}
