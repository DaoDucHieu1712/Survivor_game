using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{

    float score = 0;
    UIManagement ui;
    PlayerInfomation pl;

    public float Score { get => score; set => score = value; }
    // Start is called before the first frame update
    void Start()
    {
        ui = FindObjectOfType<UIManagement>();
        pl = FindObjectOfType<PlayerInfomation>();
    }

    // Update is called once per frame
    public void IncrementScore()
    {
        Score += pl.level * 4;
        ui.SetCoreText("Score : " + Score);
    }
}
