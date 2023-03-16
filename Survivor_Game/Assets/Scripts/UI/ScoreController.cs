using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    float score = 5;
    UIManagement ui;
    PlayerInfomation pl;
    public float Score { get => score; set => score = value; }
    void Start()
    {
        ui = FindObjectOfType<UIManagement>();
        pl = FindObjectOfType<PlayerInfomation>();
    }

    public void IncrementScore()
    {
        Score += pl.Lv * 4;
        ui.SetScoreText("Score: " + Score);
    }
}
