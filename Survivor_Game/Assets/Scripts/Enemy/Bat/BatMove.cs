using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BatMove : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private PlayerInfomation player1; // 

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        player1 = FindObjectOfType<PlayerInfomation>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
}