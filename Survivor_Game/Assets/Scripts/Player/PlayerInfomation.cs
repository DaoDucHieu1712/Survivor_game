using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfomation : MonoBehaviour
{
    float lv = 1;
    public int hp = 50;
    public int dame = 10;
    public float exp = 0;
    public float maxExp = 100;
	public int currentHealth;
	public HealthBar healthBar;

	public delegate void LevelChangedEventHandler(float newLevel);
    public event LevelChangedEventHandler LevelChanged;

    public float Lv { get => lv;
        set {
            lv = value;
            if (LevelChanged != null)
            {
                LevelChanged(lv);
            }
        }  
    }
    public float Hp { get => hp; set => hp = (int)value; }
    public float Dame { get => dame; set => dame = (int)value; }
    public float Exp { get => exp; set => exp = value; }
    public float MaxExp { get => maxExp; set => maxExp = value; }
	void Start()
	{
		currentHealth = hp;
		healthBar.SetMaxHealth(hp);
	}

	public void Update()
    {   
        if (Exp >= MaxExp)
        {
            Lv++;
            MaxExp = MaxExp * 1.2f;
            Dame = Dame * 1.2f;
        }
        if(Hp == 0)
        {
            //Game over
        }
    }

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);
		if (currentHealth <= 0)
		{
            Application.Quit();
		}
	}
    public void EatHP(int hp)
    {
        currentHealth += hp;
        healthBar.SetHealth(currentHealth);
    }

    public void EatExp(int exp)
    {
        exp += exp;
    }

}
