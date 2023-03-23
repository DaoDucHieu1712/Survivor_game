using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSpawner : MonoBehaviour
{
    public GameObject prefab; // Prefab của object bat khi spawn ở bên phải màn 
    public float spawnInterval;
    private float timeSinceLastSpawn = 4f;
    private PlayerInfomation player; // Reference to the player object
    public GameObject hpPrefab;
    public GameObject expPrefab;
    void Start()
    {
        player = FindObjectOfType<PlayerInfomation>();
    }

    void Update()
    {
       
        // Get the current level of the player
        float playerLevel = player.Lv;
        float spawnInterval = 10f - playerLevel * 0.2f;
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= spawnInterval)
        {
            SetNewTargetPos();
            timeSinceLastSpawn = 0f;
        }
    }

    private void SetNewTargetPos()
    {
        Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));
        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        float right = topRight.x;
        float left = bottomLeft.x;
        float top = topRight.y;
        float bot = bottomLeft.y;

        // Spawn position for the bat


        // Instantiate the prefabTarget2 at spawnPos with rotation
        GameObject newPrefabTarget2;
        Vector3 spawnPos = new Vector3(Random.Range(right, left), Random.Range(top, bot), 0);
        if (spawnPos.x < Camera.main.transform.position.x) // Nếu vị trí spawn nằm bên trái màn hình
        {
            newPrefabTarget2 = Instantiate(prefab, spawnPos, Quaternion.Euler(0, 180, 0));
            
        }
        else // Nếu vị trí spawn nằm bên phải màn hình
        {
            newPrefabTarget2 = Instantiate(prefab, spawnPos, Quaternion.identity);
        }

    }
}