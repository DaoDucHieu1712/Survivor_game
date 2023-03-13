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
<<<<<<< Updated upstream
=======

    void SetProperty(Weapon weapon)
    {
        prefabBullet = weapon.bullet;
        bulletSpeed = weapon.Speed;
        spawnDelay = weapon.SpawnDelay;
    }

    //public void ChangeWeapon(int skill)
    //{
    //    switch (skill)
    //    {
    //        case 1:
    //            Debug.Log("1");
    //            weapon = new Weapon(DanThuong, playerInfo.dame, 0.2f, 2f);
    //            SetProperty(weapon);
    //            break;
    //        case 2:
    //            Debug.Log("2");
    //            weapon = new Weapon(DanNo, playerInfo.dame, 1f, 1f);
    //            SetProperty(weapon);
    //            break;
    //        case 3:
    //            Debug.Log("3");
    //            weapon = new Weapon(DanXuyen, playerInfo.dame / 2, 0.5f, 3f);
    //            SetProperty(weapon);
    //            break;
    //        case 4:
    //            Debug.Log("4");
    //            weapon = new Weapon(DanUltimate, playerInfo.dame * 3, 1.5f, 4f);
    //            SetProperty(weapon);
    //            break;
    //    }
    //}
>>>>>>> Stashed changes
}
