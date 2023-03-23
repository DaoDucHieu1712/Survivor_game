using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerInfomation : MonoBehaviour
{

	public float dame = 10f;
	public float hp = 50f;
	public float exp;
	public float lv = 1;
	public float currentHealth;
	public float maxExp = 100;

    public HealthBar healthBar;

	UIManagement ui;
    bool isGameOver;

    public delegate void LevelChangedEventHandler(float newLevel);
	public event LevelChangedEventHandler LevelChanged;

	public float Lv
	{
		get => lv;
		set
		{
			lv = value;
			if (LevelChanged != null)
			{
				LevelChanged(lv);
			}
		}
	}
	public float Hp { get => hp; set => hp = value; }
	public float Dame { get => dame; set => dame = value; }
	public float Exp
	{
		get => exp;
		set => exp = value;
	}
	public float MaxExp { get => maxExp; set => maxExp = value; }
    public bool IsGameOver { get => isGameOver; set => isGameOver = value; }

    void Start()
	{
		ui = FindObjectOfType<UIManagement>();
		currentHealth = hp;
		healthBar.SetMaxHealth(hp);
        ui.Bullet1.interactable = false;
        ui.Bullet2.interactable = false;
        ui.Bullet3.interactable = false;
		ui.Bullet4.interactable = false;
    }

    public void Update()
	{
		if (Exp >= MaxExp)
		{
			Lv++;
			MaxExp = (float)(10 * Math.Pow(1.05, lv));
			Dame = Dame * 1.015f;
			Hp = Hp * 1.03f;
			healthBar.SetMaxHealth(Hp);
			Exp = 0;
		}
		ui.SetExpText(Math.Floor(Exp).ToString(), Math.Floor(MaxExp).ToString());
		ui.SetLevelText(Lv.ToString());
		if(Lv == 4)
		{
            ui.Bullet2.interactable = true;
            ui.Bullet3.interactable = true;
		}
		else if(Lv == 6){
            ui.Bullet4.interactable = true;
        }
    }

	public void TakeDamage(float damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);
		if (currentHealth <= 0)
		{
			Debug.Log("currentHealth");
			ui.ShowGameoverPanel();
			Time.timeScale = 0;
		}
	}
    public void EatHP(int hp)
    {
        currentHealth += hp;
        healthBar.SetHealth(currentHealth);
    }

	public void EatExp(int i)
	{
		Exp += i;
	}
}
