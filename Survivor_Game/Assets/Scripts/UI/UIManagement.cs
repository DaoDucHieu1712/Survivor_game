using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UIManagement : MonoBehaviour
{
    public Text scoreText;
    public Text lvText;
    public GameObject gameoverPanel;
    public Button Bullet1;
    public Button Bullet2;
    public Button Bullet3;
    public Button Bullet4;
    public Button MainMenu;

    private int scoreValue;
    // Start is called before the first frame update

    public void Start()
    {

        Bullet1.onClick.AddListener(ChangeSkill);
        Bullet2.onClick.AddListener(ChangeSkill);
        Bullet3.onClick.AddListener(ChangeSkill);
        Bullet4.onClick.AddListener(ChangeSkill);
        MainMenu.onClick.AddListener(MainMenuButton);
        scoreValue = 0;

    }

    private void ChangeSkill()
    {
        PlayerController playerController = FindObjectOfType<PlayerController>();
        string bullet = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        switch (bullet)
        {
            case "Bullet 1":
                playerController.ChangeWeapon(1);
                break;
            case "Bullet 2":
                playerController.ChangeWeapon(2);
                break;
            case "Bullet 3":
                playerController.ChangeWeapon(3);
                break;
            case "Bullet 4":
                playerController.ChangeWeapon(4);
                break;
        }
    }

    public void SetCoreText(string text)
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
            //scoreText.text = "Score: " + ScoreController.scoreValue;
            gameoverPanel.SetActive(isShow);
        }
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("SenceCuaHieu");
        Time.timeScale = 1;
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void IncreaseScore()
    {
        scoreText.text = "Score: " + ++scoreValue;
    }

    
}
