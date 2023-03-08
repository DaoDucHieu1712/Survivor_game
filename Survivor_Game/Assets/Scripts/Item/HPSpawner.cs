using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPSpawner : MonoBehaviour
{


    public GameObject hp;
    TimerOther timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<TimerOther>();
        timer.alarmTime = 2;
        timer.StartTime();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.isFinish)
        {
            Spawn();
        }
        timer.StartTime();
    }

    public void Spawn()
    {
        Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));
        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        float right = topRight.x;
        float left = bottomLeft.x;
        float top = topRight.y;
        float bot = bottomLeft.y;
        Vector3 pos = new Vector3(Random.Range(right, left), Random.Range(top, bot), 0);
        Instantiate(hp, pos, Quaternion.identity);
    }
}
