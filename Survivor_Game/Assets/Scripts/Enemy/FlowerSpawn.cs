using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowerSpawn : MonoBehaviour
{
	//// Start is called before the first frame update
	////public int maxHealth = 20;
	////public int curentHealth;
	////public Slider healthSlider;
	public GameObject prefabTarget;
	public float moveSpeed = 2f;
	private float timeSinceLastSpawn;

	private GameObject player; // Reference to the player object

	void Start()
	{
		// Find the player object using its tag
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
		// Get the current level of the player
		float playerLevel = player.GetComponent<PlayerInfomation>().level;
		Debug.Log("Level hien tại là" + playerLevel);
		float spawnInterval = 5f - playerLevel * 0.2f;
		Debug.Log("Time spawn la" + spawnInterval);
		timeSinceLastSpawn += Time.deltaTime;
		if (timeSinceLastSpawn >= spawnInterval)
		{
			SetNewTargetPos();
			timeSinceLastSpawn = 0f;
		}
	}

	private void SetNewTargetPos()
	{
		Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));
		Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
		float right = topRight.x;
		float left = bottomLeft.x;
		float top = topRight.y;
		float bot = bottomLeft.y;
		Vector3 targetPos = new Vector3(Random.Range(right, left), Random.Range(top, bot), 0);

		// Instantiate the prefabTarget at targetPos
		GameObject newPrefabTarget = Instantiate(prefabTarget, targetPos, Quaternion.identity);

		//Get the current level of the player
		float playerLevel = player.GetComponent<PlayerInfomation>().level;

		// Increase the health of the new target based on the player level
		float targetHealth = 20 + playerLevel * 3;
		newPrefabTarget.GetComponent<FlowerProperti>().MaxHealth = targetHealth;
		newPrefabTarget.GetComponent<FlowerProperti>().CurrentHealth = targetHealth;

		Debug.Log("Level cua player" + playerLevel);
		Debug.Log("Mac heo " + newPrefabTarget.GetComponent<FlowerProperti>().MaxHealth);
		Debug.Log("Suc khoe" + newPrefabTarget.GetComponent<FlowerProperti>().CurrentHealth);
	

		// Increase the damage of the new target based on the player level
		float targetDamage = 2 + playerLevel;
		newPrefabTarget.GetComponent<FlowerProperti>().Damage = targetDamage;

		// Calculate the spawn interval based on the player level


		// Start a coroutine to move the prefabTarget towards the player after 3 seconds
		StartCoroutine(MoveToPlayer(newPrefabTarget));

		// Fire a bullet from the newPrefabTarget towards the player's position
	}



	private IEnumerator MoveToPlayer(GameObject target)
	{
		yield return new WaitForSeconds(3f); // Wait for 3 seconds

		Vector3 prevPlayerPos = player.transform.position;
		bool isMovingToPlayer = true;

		while (true)
		{
			Vector3 currPlayerPos = player.transform.position;

			// Check if the target object has been destroyed before accessing its position
			if (target == null)
			{
				break;
			}

			float distToPlayer = Vector3.Distance(target.transform.position, currPlayerPos);

			if (isMovingToPlayer)
			{
				// If the target is moving towards the player, check if it has reached the desired distance
				if (distToPlayer <= 4f)
				{
					// Stop moving and freeze in the current position
					target.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
					isMovingToPlayer = false;
					yield return new WaitForSeconds(3f); // Wait for 3 seconds before moving again
				}
				else
				{
					// Set the velocity of the prefabTarget Rigidbody to move towards the player
					Vector3 dirToPlayer = (currPlayerPos - target.transform.position).normalized;
					target.GetComponent<Rigidbody2D>().velocity = dirToPlayer * moveSpeed;
				}
			}
			else
			{
				// If the target is frozen, check if the player has moved more than 2 units away from its previous position
				float distMoved = Vector3.Distance(prevPlayerPos, currPlayerPos);
				if (distMoved >= 3f)
				{
					// Calculate the direction towards the player's new position
					Vector3 dirToPlayer = (currPlayerPos - target.transform.position).normalized;
					isMovingToPlayer = true;
				}
			}

			yield return null;
		}
	}


}
