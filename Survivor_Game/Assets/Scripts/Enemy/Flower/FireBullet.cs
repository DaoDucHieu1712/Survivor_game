using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
	[SerializeField]
	GameObject flowerBulletPrefab;

	[SerializeField]
	private int bulletsAmount = 10;
	private float angle = 0f;
	[SerializeField]
	private float startAngle = 0f, endAngle = 360f;
	public float involkTime = 1;

	// Start is called before the first frame update
	void Start()
	{
		InvokeRepeating("flowerShot", 0f, 3f);
	}

	public void flowerShot()
	{
		Fire();
	}

	public void Fire()
	{
		float angleStep = (endAngle - startAngle) / bulletsAmount;
		float angle = startAngle;

		for (int i = 0; i < bulletsAmount + 1; i++)
		{
			float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
			float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

			Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
			Vector2 bulDir = (bulMoveVector - transform.position).normalized;

			GameObject a = Instantiate(flowerBulletPrefab, transform.position, Quaternion.identity);
			a.GetComponent<BulletForFlower>().SetMoveDirection(bulDir);

			angle += angleStep;
		}
	}


	
}
