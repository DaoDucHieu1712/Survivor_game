using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowerProperti : MonoBehaviour
{
    // Start is called before the first frame update

    // Start is called before the first frame update

    private float maxHealth = 20;
    private float currentHealth;
    private float damage = 5;
    public HealthBar healthBar;

    public float MaxHealth { get => maxHealth; set => maxHealth = value; }
    public float CurrentHealth { get => currentHealth; set => currentHealth = value; }
    public float Damage { get => damage; set => damage = value; }

    // Start is called before the first frame update
    void Start()
	{
		CurrentHealth = MaxHealth;
		healthBar.SetMaxHealth(MaxHealth);
	}

	// Update is called once per frame
	void Update()
	{
	
	}

	public void TakeDamage(float damage)
	{
		CurrentHealth -= damage;

		healthBar.SetHealth(CurrentHealth);
		if (CurrentHealth <= 0)
		{
			Destroy(gameObject);
		}
	}
}
