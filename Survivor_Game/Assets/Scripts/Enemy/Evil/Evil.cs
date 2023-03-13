using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evil : MonoBehaviour
{
    public int attackDamage = 4;
    public float attackRange = 3f;
    public float attackRate = 1f;
    public float attackCooldown = 0f;
    public float moveSpeed = 2f;
    public GameObject player;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        attackCooldown -= Time.deltaTime;

        if (Vector3.Distance(transform.position, player.transform.position) > attackRange)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
        if (Vector3.Distance(transform.position, player.transform.position) <= attackRange)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (attackCooldown <= 0f)
        {
            attackCooldown = 1f;
        }
    }
}