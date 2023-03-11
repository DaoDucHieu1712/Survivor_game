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
        if (collision.gameObject.CompareTag("Bat"))
        {
            
        }

        if (collision.gameObject.CompareTag("Flower"))
        {
            
        }

        if (collision.gameObject.CompareTag("Evil"))
        {
            
        }

        if (collision.gameObject.CompareTag("FlowerAmount"))
        {
            
        }

        if (collision.gameObject.CompareTag("EvilAmount"))
        {
            
        }

        if (collision.gameObject.CompareTag("Exp"))
        {
            pl.Exp += 2;
        }

        if (collision.gameObject.CompareTag("HP"))
        {
            pl.Hp += 1;
        }
    }
}
