using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
		//if (collision.gameObject.CompareTag("Bat"))
		//{

		//}

		if (collision.gameObject.CompareTag("Flower"))
		{
			FlowerProperti flower = collision.gameObject.GetComponent<FlowerProperti>();
			if (flower != null)
			{
				flower.TakeDamage(flower.Damage);
			}
		}
	}
}
