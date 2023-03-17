using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilProperty : MonoBehaviour
{
    private float maxHealth = 30;
    private float currentHealth;
    private float damage = 4;

    public float MaxHealth { get => maxHealth; set => maxHealth = value; }
    public float CurrentHealth { get => currentHealth; set => currentHealth = value; }
    public float Damage { get => damage; set => damage = value; }

    public EvilHealthBar healthBar;

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

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(CurrentHealth);
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        EvilSpawnController evilSpawn = FindObjectOfType<EvilSpawnController>();
        if (evilSpawn != null)
        {
            // Randomly select a prefab to spawn (1 in 3 chance for each type)


            float rand = Random.value;
            if (rand < 0.4f) // 40% chance to spawn hpPrefab
            {
                Instantiate(evilSpawn.hpPrefab, transform.position, Quaternion.identity);
            }
            else if (rand < 0.8f) // 40% chance to spawn expPrefab
            {
                Instantiate(evilSpawn.expPrefab, transform.position, Quaternion.identity);
            }
            else // 20% chance to spawn expuntilPrefab

            {
                Instantiate(evilSpawn.expUntilPrefab, transform.position, Quaternion.identity);
            }
        }
    }
}
