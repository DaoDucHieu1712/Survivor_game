using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    GameObject player;
    PlayerInfomation pl;


    private void Start()
    {
        pl = GetComponent<PlayerInfomation>();

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
                flower.TakeDamage(2);
            }
        }

        if (collision.gameObject.CompareTag("Evil"))
        {
            EvilProperty evil = collision.gameObject.GetComponent<EvilProperty>();
            if (evil != null)
            {
                evil.TakeDamage(3); 
            }
        }

        //if (collision.gameObject.CompareTag("FlowerAmount"))
        //{

        //}

        //if (collision.gameObject.CompareTag("EvilAmount"))
        //{

        //}

        //if (collision.gameObject.CompareTag("Exp"))
        //{
        //    pl.Exp += 2;
        //}

        //if (collision.gameObject.CompareTag("HP"))
        //{
        //    pl.Hp += 1;
        //}
    } 
}
