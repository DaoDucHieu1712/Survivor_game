using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatColiision : MonoBehaviour
{
    public float damage;
    public float pushForce = 0.1f; // Lực đẩy

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("Player"))
        {
            Rigidbody2D playerRigidbody = other.GetComponent<Rigidbody2D>();
            Vector2 pushDirection = playerRigidbody.transform.position - transform.position; // Xác định hướng đẩy
            pushDirection.Normalize();
            playerRigidbody.AddForce(pushDirection * pushForce, ForceMode2D.Impulse); // Đẩy player
            StartCoroutine(StopPlayer(playerRigidbody));
        }


        //// Trừ điểm máu của player
        //PlayerInfomation player = other.gameObject.GetComponent<PlayerInfomation>();
        //if (player.currentHealth > 0)
        //{
        //    float playerLevel = player.GetComponent<PlayerInfomation>().lv;
        //    damage = 10f - 0.3f * playerLevel;
        //    player.TakeDamage(damage);
        //}
    }

    IEnumerator StopPlayer(Rigidbody2D playerRb)
    {
        yield return new WaitForSeconds(0.5f); // Đợi 0.5 giây trước khi dừng player
        playerRb.velocity = Vector3.zero; // Dừng player
    }
}
