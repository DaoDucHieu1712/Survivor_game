using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerBullet : MonoBehaviour
{
    // Start is called before the first frame update
    //float moveSpeed = 7f;
    //Rigidbody2D rb;
    //Vector2 moveDirection;

    //Mover target;
    //void Start()
    //{
    //    rb = GetComponent<Rigidbody2D>();
    //    target = GameObject.FindObjectOfType<Mover>();
    //    moveDirection = (target.transform.position - transform.position).normalized;
    //    rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
    //    Destroy(gameObject, 3f);
    //}

	// Update is called once per frame
	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.gameObject.name.Equals("Player"))
        {
            Debug.Log("Hit");
			PlayerInfomation player = collision.gameObject.GetComponent<PlayerInfomation>();
			FlowerProperti flower = collision.gameObject.GetComponent<FlowerProperti>();
			
			
				player.TakeDamage(5);
			
			Destroy(gameObject);

        }
	}
}
