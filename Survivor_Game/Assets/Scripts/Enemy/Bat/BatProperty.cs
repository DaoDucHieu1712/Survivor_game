using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatProperty : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxHealth = 50f;
    public float currentHealth;
    public float damage = 5;
    public HealthBar healthBar;
    public GameObject ani;

    public float MaxHealth { get => maxHealth; set => maxHealth = value; }
    public float CurrentHealth { get => currentHealth; set => currentHealth = value; }
    public float Damage { get => damage; set => damage = value; }
    UIManagement uIManagement;

    // Start is called before the first frame update
    void Start()
    {
        uIManagement = FindObjectOfType<UIManagement>();
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
            //ScoreController.scoreValue++;
            uIManagement.IncreaseScore();
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        BatSpawner batSpawner = FindObjectOfType<BatSpawner>();
        if (batSpawner != null)
        {
            // Randomly select a prefab to spawn (1 in 3 chance for each type)

            float rand = Random.value;
            if (rand < 0.1f) // 10% chance to spawn hpPrefab
            {
                Instantiate(batSpawner.hpPrefab, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(batSpawner.expPrefab, transform.position, Quaternion.identity);
            }
            GameObject boom = Instantiate(ani, transform.position, Quaternion.identity);
            uIManagement.PlayeAudioBoom();
            Destroy(boom, 2f);
        }
    }
}
