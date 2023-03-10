using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEvil : MonoBehaviour
{
    //public GameObject evilPrefab;
    //public PlayerInfomation playerInfo;
    //public GameObject player;
    //public float spawnDistance = 10f;
    //public float baseQuantity = 2f;
    //public float quantityPerLevel = 1.5f;

    //void Start()
    //{
    //    player.GetComponent<PlayerInfomation>().LevelChanged += SpawnEvilObject;
    //}

    //void SpawnEvilObject(float newLevel)
    //{
    //    int quantity = Mathf.RoundToInt(baseQuantity + quantityPerLevel * newLevel);

    //    for (int i = 0; i < quantity; i++)
    //    {
    //        Vector3 spawnPosition = player.transform.position + player.transform.forward * spawnDistance;
    //        Instantiate(evilPrefab, spawnPosition, Quaternion.identity);
    //    }
    //}
    public GameObject prefabTarget;
    public float spawnInterval = 2f;
    public float moveSpeed = 10f;
    private float timeSinceLastSpawn;

    private GameObject player; // Reference to the player object

    void Start()
    {
        // Find the player object using its tag
        player = GameObject.FindGameObjectWithTag("Player");

    }

    void Update()
    {
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
        Vector3 targetPos = new Vector3(Random.Range(right, left), Random.Range(top, bot), 0);

        // Instantiate the prefabTarget at targetPos
        GameObject newPrefabTarget = Instantiate(prefabTarget, targetPos, Quaternion.identity);


        // Start a coroutine to move the prefabTarget towards the player after 3 seconds
        StartCoroutine(MoveToPlayer(newPrefabTarget));

        // Fire a bullet from the newPrefabTarget towards the player's position

    }

    private IEnumerator MoveToPlayer(GameObject target)
    {
        yield return new WaitForSeconds(2f); // Wait for 2 seconds

        Vector3 prevPlayerPos = player.transform.position;
        Vector3 dirToPlayer = (prevPlayerPos - target.transform.position).normalized;
        bool isMovingToPlayer = true;

        while (true)
        {
            if (target == null) break; // Check if the target GameObject has been destroyed

            Vector3 currPlayerPos = player.transform.position;
            float distToPlayer = Vector3.Distance(target.transform.position, currPlayerPos);

            if (isMovingToPlayer)
            {
                // If the target is moving towards the player, check if it has reached the desired distance
                if (distToPlayer <= 4f)
                {
                    // Stop moving and freeze in the current position
                    target.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                    isMovingToPlayer = false;
                    yield return new WaitForSeconds(3f); // Wait for 3 seconds before moving again
                }
                else
                {
                    // Set the velocity of the prefabTarget Rigidbody to move towards the player
                    target.GetComponent<Rigidbody2D>().velocity = dirToPlayer * moveSpeed;
                }
            }
            else
            {
                // If the target is frozen, check if the player has moved more than 2 units away from its previous position
                float distMoved = Vector3.Distance(prevPlayerPos, currPlayerPos);
                if (distMoved >= 4f)
                {
                    // Calculate the direction towards the player's new position
                    dirToPlayer = (currPlayerPos - target.transform.position).normalized;
                    isMovingToPlayer = true;
                }
            }

            yield return null;
        }
    }

}
