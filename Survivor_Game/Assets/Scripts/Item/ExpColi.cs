using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpColi : MonoBehaviour
{
    PlayerInfomation pl;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name.Equals("Player"))
        {
			PlayerInfomation player = collision.gameObject.GetComponent<PlayerInfomation>();
			player.IncreaseExp(0.2f);
			Destroy(gameObject);
		}

       // if (collision.gameObject.CompareTag("Player"))
    //    {
       //     pl = collision.gameObject.GetComponent<PlayerInfomation>();
       //     pl.EatExp(3);
       //     Destroy(gameObject);
      //  }
    }
}
