using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public float hp;
    public float dame;
    float exp;
    float explvUp = 10;
    float lv;
    public GameObject bat;
    public GameObject flower;
    public GameObject evil;

    public float Exp { get => exp; set => exp = value; }
    public float ExpLvUp { get => explvUp; set => explvUp = value; }
    public float Lv { get => lv; set => lv = value; }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bat"))
        {
            hp = hp - 1;
        }

        if (collision.gameObject.CompareTag("Flower"))
        {
            hp = hp - 1;
        }

        if (collision.gameObject.CompareTag("Evil"))
        {
            hp = hp - 1;
        }

        if (collision.gameObject.CompareTag("FlowerAmount"))
        {
            hp = hp - 1;
        }

        if (collision.gameObject.CompareTag("EvilAmount"))
        {
            hp = hp - 1;
        }

        if (collision.gameObject.CompareTag("Exp"))
        {
            exp = exp + 1;
        }

        if (collision.gameObject.CompareTag("HP"))
        {
            hp = hp + 1;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        explvUp = (float)(explvUp * (lv * 1.2 / lv));
    }
}
