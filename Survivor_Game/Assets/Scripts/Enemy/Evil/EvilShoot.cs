using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilShoot : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public GameObject bulletPrefab;
    public float evilRate = 1f;
    public float bulletSpeed = 10f;
    public float bulletLifetime = 2f;

    public float dame = 4;
    public float hp = 30;



    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("EvilBullet", 0f, evilRate);
    }

    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void EvilBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        Vector2 bulletDirection = (target.position - transform.position).normalized;
        float angle = Mathf.Atan2(bulletDirection.y, bulletDirection.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        bulletRigidbody.velocity = bullet.transform.right * bulletSpeed;
        Destroy(bullet, bulletLifetime);

    }
}
