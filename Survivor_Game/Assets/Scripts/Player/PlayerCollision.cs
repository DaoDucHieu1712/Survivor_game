using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    PlayerInfomation pl;

    private void OnTriggerEnter2D(Collider2D collision)
    {
    //    if (collision.gameObject.CompareTag("Hp"))
    //    {
    //        Debug.Log("An Hp");
    //        pl = collision.gameObject.GetComponent<PlayerInfomation>();
    //        if(pl.currentHealth < pl.hp)
    //        {
    //            pl.EatHP(10);
    //        }
    //        Destroy(collision.gameObject);
    //    }

	} 
}
