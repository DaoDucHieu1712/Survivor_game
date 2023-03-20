using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public static int scoreValue = 0;
    UIManagement ui;
    Text score;

    private void Start()
    {
        ui = FindObjectOfType<UIManagement>();
        score = ui.scoreText;
    }
    private void Update()
    {
        score.text = "Score: " + scoreValue;
    }

}
