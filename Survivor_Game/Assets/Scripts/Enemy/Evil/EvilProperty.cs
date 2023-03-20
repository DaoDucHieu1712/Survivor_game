using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvilProperty : MonoBehaviour
{
    // Start is called before the first frame update

    // Start is called before the first frame update

    public float maxHealth = 30;
    public float currentHealth;
    public float damage = 4;
    public EvilHealthBar healthBar;

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
        EvilSpawnController evilSpawnController = FindObjectOfType<EvilSpawnController>();
        if (evilSpawnController != null)
        {
            // Randomly select a prefab to spawn (1 in 3 chance for each type)

            float rand = Random.value;
            if (rand < 0.4f) // 40% chance to spawn hpPrefab
            {
                Instantiate(evilSpawnController.hpPrefab, transform.position, Quaternion.identity);
            }
            else if (rand < 0.8f) // 40% chance to spawn expPrefab
            {
                Instantiate(evilSpawnController.expPrefab, transform.position, Quaternion.identity);
            }
            else // 20% chance to spawn expuntilPrefab

            {
                Instantiate(evilSpawnController.expUntilPrefab, transform.position, Quaternion.identity);
            }
        }
    }

}
