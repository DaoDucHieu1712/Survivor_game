using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatColiision : MonoBehaviour
{
    public float damage;
    public float pushForce = 10f; // Lực đẩy

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("Player"))
        {
            Rigidbody2D playerRigidbody = other.GetComponent<Rigidbody2D>();
            Rigidbody2D player = other.gameObject.GetComponent<Rigidbody2D>();
            Vector2 pushDirection = playerRigidbody.transform.position - transform.position; // Xác định hướng đẩy
            pushDirection.Normalize();
            if (player != null)
            {
                playerRigidbody.AddForce(pushDirection * pushForce, ForceMode2D.Impulse); // Đẩy player
                StartCoroutine(StopPlayer(player));
            }
        }


        // Trừ điểm máu của player
        PlayerInfomation player1 = other.gameObject.GetComponent<PlayerInfomation>();
        if (player1.currentHealth > 0)
        {
            float playerLevel = player1.GetComponent<PlayerInfomation>().lv;
            damage = 10f - 0.3f * playerLevel;
            player1.TakeDamage(damage);
        }
    }

    IEnumerator StopPlayer(Rigidbody2D playerRb)
    {
        yield return new WaitForSeconds(0.1f); // Đợi 0.5 giây trước khi dừng player
        playerRb.velocity = Vector3.zero; // Dừng player
    }
}