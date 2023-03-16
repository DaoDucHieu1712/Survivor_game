using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilSpawnController : MonoBehaviour
{
    public GameObject evilPrefab;
    public float spawnDelay = 2f;

    private void Start()
    {
        InvokeRepeating("SpawnEvil", spawnDelay, spawnDelay);
    }

    private void SpawnEvil()
    {
        Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));
        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        float right = topRight.x;
        float left = bottomLeft.x;
        float top = topRight.y;
        float bot = bottomLeft.y;
        Vector3 targetPos = new Vector3(Random.Range(right, left), Random.Range(top, bot), 0);

        // Instantiate the prefabTarget at targetPos
        Instantiate(evilPrefab, targetPos, Quaternion.identity);
    }
}
