using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfomation : MonoBehaviour
{
    float lv = 1;
    int hp = 50;
    int dame = 10;
    float exp = 0;
    float m_exp = 100;
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
    public float Exp1 { get => m_exp; set => m_exp = value; }
	void Start()
	{
		currentHealth = hp;
		healthBar.SetMaxHealth(hp);
	}

	public void Update()
    {   
        if (Exp >= Exp1)
        {
            Lv++;
            Exp1 = Exp1 * 1.2f;
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

}
