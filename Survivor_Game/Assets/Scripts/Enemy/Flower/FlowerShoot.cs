using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlowerShoot : MonoBehaviour
{
	// Start is called before the first frame update
	[SerializeField]
	public GameObject bulletPrefab;
	public float fireRate = 2.5f;
	public float bulletSpeed = 5f;
	public float bulletLifetime = 2f;
	private GameObject player;
	float playerLevel;


	public float dame = 5;
	public float hp = 20;

	private float bulletSpeedIncrease = 0.2f;

		

	private Transform target;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		target = GameObject.FindGameObjectWithTag("Player").transform;
		InvokeRepeating("FireBullet", 0f, fireRate);
		
	}

	void Update()
	{
		target = GameObject.FindGameObjectWithTag("Player").transform;
		 playerLevel = player.GetComponent<PlayerInfomation>().lv;
	}


	void FireBullet()
	{
		GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
		Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
		Vector2 bulletDirection = (target.position - transform.position).normalized;
		float angle = Mathf.Atan2(bulletDirection.y, bulletDirection.x) * Mathf.Rad2Deg;
		bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		bulletSpeed = bulletSpeedIncrease * playerLevel + bulletSpeed;
		bulletRigidbody.velocity = bullet.transform.right * bulletSpeed;
		Destroy(bullet, bulletLifetime);

	}
}
