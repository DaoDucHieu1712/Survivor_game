using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefabTarget;
    public float spawnInterval = 4f;
    private float timeSinceLastSpawn;
    void Start()
    {
        
    }

    // Update is called once per frame
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
       

    }
}
