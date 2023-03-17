using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerBullet : MonoBehaviour
{
	

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.name.Equals("Player"))
		{
			Debug.Log("Hit");
			PlayerInfomation player = collision.gameObject.GetComponent<PlayerInfomation>();
			FlowerProperti flower = collision.gameObject.GetComponent<FlowerProperti>();

			if (player.currentHealth > 0)
			{
				player.TakeDamage(flower.Damage);
			}

			Destroy(gameObject);

		}
	}
}
