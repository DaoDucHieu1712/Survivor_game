using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evil : MonoBehaviour
{
    public GameObject evilPrefab;
    public float speed = 10f;
    public float range = 4f;
    private float changeTargetTime = 1f;
    private float timer;

    private float screenLeft;
    private float screenRight;
    private float screenTop;
    private float screenBottom;

    private GameObject targetEvil;
    private void Start()
    {
        float screenZ = -Camera.main.transform.position.z;
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        Vector3 lowerLeftCornerScreen = new Vector3(0, 0, screenZ);
        Vector3 upperRightCornerScreen = new Vector3(screenWidth, screenHeight, screenZ);
        Vector3 lowerLeftCornerWorld = Camera.main.ScreenToWorldPoint(lowerLeftCornerScreen);
        Vector3 upperRightCornerWorld = Camera.main.ScreenToWorldPoint(upperRightCornerScreen);
        screenLeft = lowerLeftCornerWorld.x;
        screenRight = upperRightCornerWorld.x;
        screenTop = upperRightCornerWorld.y;
        screenBottom = lowerLeftCornerWorld.y;

        // Instantiate target circle
        targetEvil = Instantiate(evilPrefab, GetRandomTargetPosition(), Quaternion.identity);
        timer = changeTargetTime;
    }

    private void Update()
    {
        // Move towards target position
        transform.position = Vector2.MoveTowards(transform.position, targetEvil.transform.position, speed * Time.deltaTime);

        // If target circle is reached, set a new target circle after a delay
        if (Vector2.Distance(transform.position, targetEvil.transform.position) < 0.1f)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                Destroy(targetEvil);
                targetEvil = Instantiate(evilPrefab, GetRandomTargetPosition(), Quaternion.identity);
                timer = changeTargetTime;
            }
        }
    }

    private Vector2 GetRandomTargetPosition()
    {
        // Get a random position within the bounds of the screen
        float x = Random.Range(screenLeft + range, screenRight - range);
        float y = Random.Range(screenBottom + range, screenTop - range);
        return new Vector2(x, y);
    }
}
