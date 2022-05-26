using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewsDisplay : Singleton<NewsDisplay>
{
    [SerializeField] private GameObject newsPanel;

    [SerializeField] private Text newsText;

    public void SetText(string text)
    {
        newsText.text = text;
        ShowNews();
    }

    public void ShowNews()
    {
        newsPanel.SetActive(true);
    }

    public void CloseWindow()
    {
        newsPanel.SetActive(false);
    }
}
