using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowerProperti : MonoBehaviour
{
    // Start is called before the first frame update

    // Start is called before the first frame update

    public float maxHealth = 20;
    private float currentHealth;
    public float damage = 5;
    public HealthBar healthBar;
    UIManagement uIManagement;
    public GameObject ani;


    public float MaxHealth { get => maxHealth; set => maxHealth = value; }
    public float CurrentHealth { get => currentHealth; set => currentHealth = value; }
    public float Damage { get => damage; set => damage = value; }

	

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
		FlowerSpawn flowerSpawn = FindObjectOfType<FlowerSpawn>();
		if (flowerSpawn != null)
		{
			// Randomly select a prefab to spawn (1 in 3 chance for each type)

			float rand = Random.value;
			if (rand < 0.2f) // 10% chance to spawn hpPrefab
			{
				Instantiate(flowerSpawn.hpPrefab, transform.position, Quaternion.identity);
			}
			else if (rand < 0.8f) // 80% chance to spawn expPrefab
			{
				Instantiate(flowerSpawn.expPrefab, transform.position, Quaternion.identity);
			}
			
            GameObject boom = Instantiate(ani, transform.position, Quaternion.identity);
            uIManagement.PlayeAudioBoom();
            Destroy(boom, 2f);
        }
	}

}
