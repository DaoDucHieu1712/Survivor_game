using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpColi : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            Debug.Log("eatHp");
            PlayerInfomation player = collision.gameObject.GetComponent<PlayerInfomation>();
            FlowerProperti flower = collision.gameObject.GetComponent<FlowerProperti>();

            if (player.currentHealth < player.Hp)
            {
                player.EatHP(10);
            }

            Destroy(gameObject);

        }
    }
}
