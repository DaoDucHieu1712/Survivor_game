using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilProperty : MonoBehaviour
{
    public int maxHealth = 30;
    public int currentHealth;

    public EvilHealthBar healthBar;

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
