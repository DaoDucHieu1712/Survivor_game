using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatColiision : MonoBehaviour
{
    public float damage;
    public float pushForce = 10f; // Lực đẩy khi va chạm

    private void OnTriggerEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector2 pushDirection = collision.contacts[0].normal; // Hướng đẩy

            playerRigidbody.velocity = pushDirection * pushForce; // Đẩy player theo hướng va chạm
        
        // Trừ điểm máu của player
        PlayerInfomation player = collision.gameObject.GetComponent<PlayerInfomation>();
            if (player.currentHealth > 0)
            {
                float playerLevel = player.GetComponent<PlayerInfomation>().lv;
                damage = 10f - 0.3f * playerLevel;
                player.TakeDamage(damage);
            }
        }
    }
}
