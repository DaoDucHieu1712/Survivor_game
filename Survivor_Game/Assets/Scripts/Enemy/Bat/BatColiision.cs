using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatColiision : MonoBehaviour
{
    public int damage = 5;
    public float knockbackForce = 50f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Lấy component Rigidbody2D của bat
            Rigidbody2D batRigidbody = GetComponent<Rigidbody2D>();

            // Lấy component Rigidbody2D của player
            Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();

            // Tính toán hướng đẩy của bat khi bị va chạm
            Vector2 knockbackDirection = (batRigidbody.position - playerRigidbody.position).normalized;

            // Áp dụng lực đẩy cho bat
            batRigidbody.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);

            // Trừ điểm máu của player
            PlayerInfomation player = collision.gameObject.GetComponent<PlayerInfomation>();
            if (player.currentHealth > 0)
            {
                player.TakeDamage(damage);
            }
        }
    }
}
