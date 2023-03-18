using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilController : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float desiredDistance = 5f;
    public float bulletSpeed = 3f;
    public float bulletLifetime = 2f;
    public GameObject EvilBullet;

    private GameObject player;
    private bool canShoot = false;
    private float shootTimer = 0f;
    private float shootDelay = 2f; // time between shots in seconds
    private float distanceTimer = 0.05f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        distanceTimer -= Time.deltaTime;
        if (distanceTimer <= 0)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance > desiredDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, movementSpeed * Time.deltaTime);
                canShoot = false;
            }
            else
            {
                canShoot = true;
            }
            distanceTimer = 0.05f;
        }

        if (canShoot)
        {
            shootTimer += Time.deltaTime;
            if (shootTimer >= shootDelay)
            {
                Shoot();
                shootTimer = 0f;
            }
        }
    }
    private void Shoot()
    {
        GameObject bullet = Instantiate(EvilBullet, transform.position, Quaternion.identity);
        Vector2 bulletDirection = (player.transform.position - transform.position).normalized;
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        float angle = Mathf.Atan2(bulletDirection.y, bulletDirection.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        bulletRigidbody.velocity = bullet.transform.right * bulletSpeed;
        Destroy(bullet, bulletLifetime);
    }
}
