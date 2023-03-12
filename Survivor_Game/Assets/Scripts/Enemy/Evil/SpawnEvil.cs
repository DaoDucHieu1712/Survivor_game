using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEvil : MonoBehaviour
{
    public GameObject evilPrefab;
    public PlayerInfomation playerInfo;
    public GameObject player;
    public float spawnDistance = 10f;
    public float baseQuantity = 2f;
    public float quantityPerLevel = 1.5f;

    void Start()
    {
        player.GetComponent<PlayerInfomation>().LevelChanged += SpawnEvilObject;
    }

    void SpawnEvilObject(float newLevel)
    {
        int quantity = Mathf.RoundToInt(baseQuantity + quantityPerLevel * newLevel);

        for (int i = 0; i < quantity; i++)
        {
            Vector3 spawnPosition = player.transform.position + player.transform.forward * spawnDistance;
            Instantiate(evilPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
