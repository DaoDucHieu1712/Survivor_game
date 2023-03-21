using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefabLeft; // Prefab của object bat khi spawn ở bên trái màn hình
    public GameObject prefabRight; // Prefab của object bat khi spawn ở bên phải màn 
    public float speed = 5.0f;
    public float moveSpeed = 10f;
    public float spawnInterval;
    private float timeSinceLastSpawn = 4f;
    private GameObject player; // Reference to the player object
    public GameObject hpPrefab;
    public GameObject expPrefab;
    public GameObject expUntilPrefab;
    void Start()
    {
        // Find the player object using its tag
        
    }

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        // Get the current level of the player
        float playerLevel = player.GetComponent<PlayerInfomation>().lv;
        spawnInterval = 5f - playerLevel * 0.2f;
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
        Vector3 spawnPos = new Vector3(Random.Range(right, left), Random.Range(top, bot), 0);

        // Instantiate the prefabTarget2 at spawnPos with rotation
        GameObject newPrefabTarget2;
        if (spawnPos.x < 0) // Nếu vị trí spawn nằm bên trái màn hình
        {
            newPrefabTarget2 = Instantiate(prefabLeft, spawnPos, Quaternion.identity);
        }
        else // Nếu vị trí spawn nằm bên phải màn hình
        {
            newPrefabTarget2 = Instantiate(prefabRight, spawnPos, Quaternion.identity);
        }
    }



}
