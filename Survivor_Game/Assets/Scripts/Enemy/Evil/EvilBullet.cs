using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilBullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            Debug.Log("Hit");
            PlayerInfomation player = collision.gameObject.GetComponent<PlayerInfomation>();
            EvilProperty evil = collision.gameObject.GetComponent<EvilProperty>();
            if (player.currentHealth > 0)
            {
                player.TakeDamage(4);
            }
            Destroy(gameObject);

        }
    }
}
