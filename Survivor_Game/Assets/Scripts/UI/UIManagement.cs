using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagement : MonoBehaviour
{
    public Text scoreText;
    public GameObject gameoverPanel;
    // Start is called before the first frame update

    public void SetScoreText(string text)
    {
        if (scoreText)
        {
            scoreText.text = text;
        }
    }

    public void ShowGameoverPanel(bool isShow)
    {
        if (gameoverPanel)
        {
            gameoverPanel.SetActive(isShow);
        }
    }

}
