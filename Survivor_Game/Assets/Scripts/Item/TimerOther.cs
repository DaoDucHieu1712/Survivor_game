using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerOther : MonoBehaviour
{
    public bool isRunning;
    public bool isFinish;
    public float elapseTime;
    public float alarmTime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        elapseTime += Time.deltaTime;
        if (elapseTime >= alarmTime)
        {
            isFinish = true;
        }
    }

    public void StartTime()
    {
        isRunning = true;
        isFinish = false;
        elapseTime = 0;
    }
}
