using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatProperty : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxHealth = 500f;
    public float currentHealth;
    public float damage = 5;
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
            ScoreController.scoreValue++;
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        FlowerSpawn flowerSpawn = FindObjectOfType<FlowerSpawn>();
        if (flowerSpawn != null)
        {
            // Randomly select a prefab to spawn (1 in 3 chance for each type)

            float rand = Random.value;
            if (rand < 0.3f) // 30% chance to spawn hpPrefab
            {
                Instantiate(flowerSpawn.hpPrefab, transform.position, Quaternion.identity);
            }
            else if (rand < 0.6f) // 60% chance to spawn expPrefab
            {
                Instantiate(flowerSpawn.expPrefab, transform.position, Quaternion.identity);
            }
            else // 10% chance to spawn expuntilPrefab

            {
                Instantiate(flowerSpawn.expUntilPrefab, transform.position, Quaternion.identity);
            }
        }
    }
}
