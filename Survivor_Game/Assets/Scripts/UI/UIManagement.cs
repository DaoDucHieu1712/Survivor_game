using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Assets.Scripts.Model;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.U2D;
using UnityEngine.UI;


public class UIManagement : MonoBehaviour
{
    public Text scoreText;
    public Text lvText;
    public Text expText;
    public GameObject gameoverPanel;
    public Button Bullet1;
    public Button Bullet2;
    public Button Bullet3;
    public Button Bullet4;
    public Button MainMenu;
    public Button Replay;

    public Text txtCoolDown;
    public Text finalText;

    private int scoreValue;
    private int coolDown;
    private int check;

    public AudioSource audioShot;
    public AudioSource audioBoom;
    public AudioSource audioTheme;

    private PlayerController playerController;
    // Start is called before the first frame update


    public void PlayShot()
    {
        audioShot.Play();
    }

    public void PlayeAudioBoom()
    {
        audioBoom.Play();
    }

    public void Start()
    {

        playerController = FindObjectOfType<PlayerController>();
        Bullet1.onClick.AddListener(ChangeSkill);
        Bullet2.onClick.AddListener(ChangeSkill);
        Bullet3.onClick.AddListener(ChangeSkill);
        Bullet4.onClick.AddListener(ChangeSkill);
        Replay.onClick.AddListener(ReplayButton);
        MainMenu.onClick.AddListener(MainMenuButton);
        scoreValue = 0;
        audioTheme.Play();
    }

    private void ChangeSkill()
    {
        
        string bullet = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        switch (bullet)
        {
            case "Bullet 1":
                Bullet2.GetComponent<Button>().interactable = true;
                Bullet3.GetComponent<Button>().interactable = true;
                Bullet1.GetComponent<Button>().interactable = false;

                playerController.ChangeWeapon(1);
                break;
            case "Bullet 2":
                Bullet3.GetComponent<Button>().interactable = true;
                Bullet1.GetComponent<Button>().interactable = true;
                Bullet2.GetComponent<Button>().interactable = false;

                playerController.ChangeWeapon(2);
                break;
            case "Bullet 3":
                Bullet2.GetComponent<Button>().interactable = true;
                Bullet1.GetComponent<Button>().interactable = true;
                Bullet3.GetComponent<Button>().interactable = false;

                playerController.ChangeWeapon(3);
                break;
            case "Bullet 4":
                Bullet4.GetComponent<Button>().interactable = false;
                Bullet4.GetComponent<Image>().color = Color.red;   
                Bullet2.GetComponent<Button>().interactable = true;
                Bullet1.GetComponent<Button>().interactable = true;
                Bullet3.GetComponent<Button>().interactable = true;
                playerController.ChangeWeapon(4);
                check = 0;
                coolDown = 5;
                InvokeRepeating("RunCoolDown", 1f, 1f);
                break;
        }
    }

    public void RunCoolDown()
    {
        coolDown--;
        txtCoolDown.text = coolDown.ToString();
        if (coolDown == 0 && check == 0)
        {
            Bullet1.GetComponent<Button>().interactable = false;
            playerController.ChangeWeapon(1);
            Bullet4.GetComponent<Image>().color = Color.white;
            check++;
            coolDown = 15;
        }
        if(coolDown == 0 && check == 1)
        {
            Bullet4.GetComponent<Button>().interactable = true;
            Bullet4.GetComponent<Image>().color = Color.red;
            txtCoolDown.text = "4";
            CancelInvoke();
        }
    }


    public void SetCoreText(string text)
    {
        if (scoreText)
        {
            scoreText.text = text;
        }
    }

    public void SetLevelText(string text)
    {
        if (lvText)
        {
            lvText.text = $"Level : {text}";
        }
    }

    public void SetExpText(string text, string maxExp)
    {   
        if (expText)
        {
            expText.text = $"Exp : {text} / {maxExp}";
        }
    }

    public void ShowGameoverPanel()
    {
        if (gameoverPanel)
        {
            //scoreText.text = "Score: " + ScoreController.scoreValue;
            finalText.text = "Score: " +  scoreValue;
            gameoverPanel.SetActive(true);
        }
    }

    public void ReplayButton()
    {
        SceneManager.LoadScene("SenceCuaHieu");
        Time.timeScale = 1;
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MenuScenes");
    }

    public void IncreaseScore()
    {
        scoreValue = scoreValue + 1;
        scoreText.text = "Score: " + scoreValue;
    }
}