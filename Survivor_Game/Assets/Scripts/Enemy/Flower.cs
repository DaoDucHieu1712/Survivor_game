using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flower : MonoBehaviour
{
	//// Start is called before the first frame update
	////public int maxHealth = 20;
	////public int curentHealth;
	////public Slider healthSlider;



	//public GameObject circlePrefab;
	//public float speed = 1f;
	//public float range = 5f;
	//private float changeTargetTime = 1f;
	//private float timer;

	//private float screenLeft;
	//private float screenRight;
	//private float screenTop;
	//private float screenBottom;

	//private GameObject targetCircle;

	//private void Start()
	//{
	//	//curentHealth = maxHealth;
	//	//healthSlider.maxValue = maxHealth;
	//	//healthSlider.value = curentHealth;
	//	// Save screen edges in world coordinates
	//	float screenZ = -Camera.main.transform.position.z;
	//	float screenWidth = Screen.width;
	//	float screenHeight = Screen.height;
	//	Vector3 lowerLeftCornerScreen = new Vector3(0, 0, screenZ);
	//	Vector3 upperRightCornerScreen = new Vector3(screenWidth, screenHeight, screenZ);
	//	Vector3 lowerLeftCornerWorld = Camera.main.ScreenToWorldPoint(lowerLeftCornerScreen);
	//	Vector3 upperRightCornerWorld = Camera.main.ScreenToWorldPoint(upperRightCornerScreen);
	//	screenLeft = lowerLeftCornerWorld.x;
	//	screenRight = upperRightCornerWorld.x;
	//	screenTop = upperRightCornerWorld.y;
	//	screenBottom = lowerLeftCornerWorld.y;

	//	// Instantiate target circle
	//	targetCircle = Instantiate(circlePrefab, GetRandomTargetPosition(), Quaternion.identity);
	//	timer = changeTargetTime;
	//}

	//private void Update()
	//{
	//	// Move towards target position
	//	transform.position = Vector2.MoveTowards(transform.position, targetCircle.transform.position, speed * Time.deltaTime);

	//	// If target circle is reached, set a new target circle after a delay
	//	if (Vector2.Distance(transform.position, targetCircle.transform.position) < 0.1f)
	//	{
	//		timer -= Time.deltaTime;
	//		if (timer <= 0f)
	//		{
	//			Destroy(targetCircle);
	//			targetCircle = Instantiate(circlePrefab, GetRandomTargetPosition(), Quaternion.identity);
	//			timer = changeTargetTime;
	//		}
	//	}
	//}

	//private Vector2 GetRandomTargetPosition()
	//{
	//	// Get a random position within the bounds of the screen
	//	float x = Random.Range(screenLeft + range, screenRight - range);
	//	float y = Random.Range(screenBottom + range, screenTop - range);
	//	return new Vector2(x, y);
	//}

	//private void OnDrawGizmosSelected()
	//{
	//	// Draw a circle gizmo to visualize the range
	//	Gizmos.color = Color.white;
	//	Gizmos.DrawWireSphere(transform.position, range);
	//}

	// Start is called before the first frame update
	public int attackDamage = 5;
	public float attackRange = 2f;
	public float attackRate = 1f;
	public float attackCooldown = 0f;
	public float moveSpeed = 2f;
	public GameObject player;
	void Start()
	{
		player = GameObject.FindWithTag("Player");
	}

	// Update is called once per frame
	void Update()
	{
		attackCooldown -= Time.deltaTime;

		if (Vector3.Distance(transform.position, player.transform.position) > attackRange)
		{
			Vector3 direction = (player.transform.position - transform.position).normalized;
			transform.Translate(direction * moveSpeed * Time.deltaTime);
		}
		if (Vector3.Distance(transform.position, player.transform.position) <= attackRange)
		{
			Attack();
		}
	}

	private void Attack()
	{
		if (attackCooldown <= 0f)
		{
			//player.GetComponent<Pla>
			attackCooldown = 1f;

		}
	}



}
