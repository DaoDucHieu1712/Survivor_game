using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfomation : MonoBehaviour
{

	//float lv = 1;
	//float hp = 50;
	//float dame = 10;
	//float exp = 0;
	//float maxExp = 100;

	public float dame = 10f;
	public float hp = 50f;
	public float exp = 10.825f;
	public int level = 1;
	public float currentHealth;

	public HealthBar healthBar;

	//public delegate void LevelChangedEventHandler(float newLevel);
 //   public event LevelChangedEventHandler LevelChanged;

    //public float Lv { get => lv;
    //    set {
    //        lv = value;
    //        if (LevelChanged != null)
    //        {
    //            LevelChanged(lv);
    //        }
    //    }  
    //}
    //public float Hp { get => hp; set => hp = value; }
    //public float Dame { get => dame; set => dame = value; }
    //public float Exp { get => exp; 
    //    set => exp = value; }
    //public float MaxExp { get => maxExp; set => maxExp = value; }
	void Start()
	{
		currentHealth = hp;
		healthBar.SetMaxHealth(hp);
	}



	public void IncreaseExp(float amount)
	{
		exp += amount;
		Debug.Log("Dame hien tai" + dame);
		
		Debug.Log("exp dang co" + exp);
		while (exp >= CalculateExpForNextLevel())
		{
			LevelUp();


		}
	}

	private void LevelUp()
	{
		level++;
		Debug.Log("Level up! New level: " + level);
		dame *= 1.2f;
		Debug.Log("dame up" + dame);
		currentHealth += 15f;
		healthBar.SetHealth(currentHealth);

		
	}

	private float CalculateExpForNextLevel()
	{
		return 10f * Mathf.Pow(1.05f, level);
	}

	//public void Update()
	//   {   
	//       if (Exp >= MaxExp)
	//       {
	//           Lv++;
	//           MaxExp = MaxExp * 1.8f;
	//           Dame = Dame * 1.4f;
  //              Hp = Hp * 1.3f;
	//       }
	//       if(Hp == 0)
	//       {
	//           //Game over
	//       }
	//   }

	public void TakeDamage(float damage)
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

    public void EatExp(int i)
    {
		exp += i;
    }

	
}
