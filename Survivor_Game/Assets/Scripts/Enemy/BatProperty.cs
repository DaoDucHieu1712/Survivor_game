using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatProperty : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth = 20;
    public int currentHealth;
    public int damage = 5;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
