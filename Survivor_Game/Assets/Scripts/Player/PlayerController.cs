using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Model;

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject DanThuong;
    public GameObject DanNo;
    public GameObject DanXuyen;
    public GameObject DanUltimate;
    public AudioSource shotSound;


    Weapon weapon = null;

    private float bulletSpeed;
    private float spawnDelay;
    private float nextSpawnTime;
    PlayerInfomation playerInfo;

    GameObject prefabBullet;

    // Start is called before the first frame update
    void Start()
    {
        playerInfo = FindObjectOfType<PlayerInfomation>();
        ChangeWeapon(1);
        SetProperty(weapon);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            GameObject bullet = Instantiate(prefabBullet, transform.position, transform.rotation);
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
            shotSound.Play();
            bulletRigidbody.AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);
            nextSpawnTime = Time.time + spawnDelay;
        }
    }

    void SetProperty(Weapon weapon)
    {
        prefabBullet = weapon.bullet;
        bulletSpeed = weapon.Speed;
        spawnDelay = weapon.SpawnDelay;
    }

    public void ChangeWeapon(int bullet)
    {
        switch (bullet)
        {
            case 1:
                Debug.Log("1");
                weapon = new Weapon(DanThuong, playerInfo.dame, 1.2f, 10f);
                break;
            case 2:
                Debug.Log("2");
                weapon = new Weapon(DanNo, playerInfo.dame, 1f, 10f);
                break;
            case 3:
                Debug.Log("3");
                weapon = new Weapon(DanXuyen, playerInfo.dame / 5, 0.5f, 5f);
                break;
            case 4:
                Debug.Log("4");
                weapon = new Weapon(DanUltimate, playerInfo.dame * 3, 1.5f, 10f);
                break;
        }
        SetProperty(weapon);
    }


}
