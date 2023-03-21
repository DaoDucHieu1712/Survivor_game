using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMove : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 7f * Time.deltaTime);
    }
}
