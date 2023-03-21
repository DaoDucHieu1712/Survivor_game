using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatColiision : MonoBehaviour
{
    public float damage = 1f;
    private bool isPlayerInCollider = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInCollider = true;
            StartCoroutine(TakeDamageOverTime());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInCollider = false;
        }
    }

    private IEnumerator TakeDamageOverTime()
    {
        while (isPlayerInCollider)
        {
            yield return new WaitForSeconds(1f); // decrease health once per second
            PlayerInfomation player1 = FindObjectOfType<PlayerInfomation>();
            player1.TakeDamage(damage);
        }
    }

}