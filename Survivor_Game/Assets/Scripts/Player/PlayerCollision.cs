using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    PlayerInfomation pl;
    Evil evil;
    FlowerProperti flower;
    BatProperty bat;


    private void Start()
    {
        pl = FindObjectOfType<PlayerInfomation>();
        evil = FindObjectOfType<Evil>();
        flower = FindObjectOfType<FlowerProperti>();
        bat = FindObjectOfType<BatProperty>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bat"))
        {
            pl.Hp -= bat.Damage;
        }

        if (collision.gameObject.CompareTag("FlowerAmount"))
        {
            pl.Hp -= evil.AttackDamage;
        }

        if (collision.gameObject.CompareTag("EvilAmount"))
        {
            pl.Hp -= flower.Damage;
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
