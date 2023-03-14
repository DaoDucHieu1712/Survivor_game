using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evil : MonoBehaviour
{
    private float attackDamage = 4;
    private float attackRange = 3f;
    private float attackRate = 1f;
    private float attackCooldown = 0f;
    private float moveSpeed = 2f;
    public GameObject player;

    public float AttackDamage { get => attackDamage; set => attackDamage = value; }
    public float AttackRange { get => attackRange; set => attackRange = value; }
    public float AttackRate { get => attackRate; set => attackRate = value; }
    public float AttackCooldown { get => attackCooldown; set => attackCooldown = value; }
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        AttackCooldown -= Time.deltaTime;

        if (Vector3.Distance(transform.position, player.transform.position) > AttackRange)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.Translate(direction * MoveSpeed * Time.deltaTime);
        }
        if (Vector3.Distance(transform.position, player.transform.position) <= AttackRange)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (AttackCooldown <= 0f)
        {
            AttackCooldown = 1f;
        }
    }
}