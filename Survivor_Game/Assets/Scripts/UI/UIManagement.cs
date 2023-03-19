using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    // Start is called before the first frame update

    public void Start()
    {
        Bullet1.onClick.AddListener(ChangeSkill);
        Bullet2.onClick.AddListener(ChangeSkill);
        Bullet3.onClick.AddListener(ChangeSkill);
        Bullet4.onClick.AddListener(ChangeSkill);

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
            gameoverPanel.SetActive(isShow);
        }
    }

}
