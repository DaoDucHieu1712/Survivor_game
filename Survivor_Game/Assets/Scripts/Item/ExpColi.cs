using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpColi : MonoBehaviour
{
    PlayerInfomation pl;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            pl = collision.gameObject.GetComponent<PlayerInfomation>();
            pl.EatExp(3);
            Destroy(gameObject);
        }
    }
}
