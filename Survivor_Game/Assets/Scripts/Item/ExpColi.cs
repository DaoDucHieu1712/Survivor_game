using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpColi : MonoBehaviour
{
    PlayerInfomation pl;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Exp"))
        {
            pl = collision.gameObject.GetComponent<PlayerInfomation>();
            if (pl.currentHealth < pl.Hp)
            {
                pl.EatHP(15);
            }
            Destroy(collision.gameObject);
        }
    }
}
