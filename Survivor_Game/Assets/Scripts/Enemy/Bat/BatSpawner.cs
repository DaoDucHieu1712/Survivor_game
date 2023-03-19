using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefabTarget;
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
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
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
        int numberOfBats = 3;


        // Spawn position for the first bat
        Vector3 spawnPos = new Vector3(Random.Range(right, left), Random.Range(top, bot), 0);

        for (int i = 0; i < numberOfBats; i++)
        {
            // Spawn rotation
            Quaternion spawnRotation = Quaternion.identity;
            if (spawnPos.x > 0)
            {
                spawnRotation = Quaternion.Euler(0, 180, 0);
            }

            // Instantiate the prefabTarget at spawnPos with rotation
            GameObject newPrefabTarget = Instantiate(prefabTarget, spawnPos, spawnRotation);

            //Get the current level of the player
            float playerLevel = player.GetComponent<PlayerInfomation>().lv;

            // Start a coroutine to move the prefabTarget towards the player after 3 seconds
            StartCoroutine(MoveToPlayer(newPrefabTarget));
        }
    }



    private IEnumerator MoveToPlayer(GameObject target)
    {
        yield return new WaitForSeconds(3f); // Wait for 3 seconds

        Vector3 prevPlayerPos = player.transform.position;
        bool isMovingToPlayer = true;

        while (true)
        {
            Vector3 currPlayerPos = player.transform.position;

            // Check if the target object has been destroyed before accessing its position
            if (target == null)
            {
                break;
            }

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
                    Vector3 dirToPlayer = (currPlayerPos - target.transform.position).normalized;
                    target.GetComponent<Rigidbody2D>().velocity = dirToPlayer * moveSpeed;
                }
            }
            else
            {
                // If the target is frozen, check if the player has moved more than 2 units away from its previous position
                float distMoved = Vector3.Distance(prevPlayerPos, currPlayerPos);
                if (distMoved >= 3f)
                {
                    // Calculate the direction towards the player's new position
                    Vector3 dirToPlayer = (currPlayerPos - target.transform.position).normalized;
                    isMovingToPlayer = true;
                }
            }

            yield return null;
        }
    }

}
