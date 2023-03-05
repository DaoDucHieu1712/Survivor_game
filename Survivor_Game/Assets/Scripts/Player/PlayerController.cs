using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Model;

using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject prefabBullet;
   
    public float speed = 10f;

    public float bulletSpeed = 10f;
    public float spawnDelay = 1f;
    private float nextSpawnTime;



    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       

        if (Time.time >= nextSpawnTime)
        {
            GameObject bullet = Instantiate(prefabBullet, transform.position, transform.rotation);
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();

            bulletRigidbody.AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);
            nextSpawnTime = Time.time + spawnDelay;
        }
    }
}
