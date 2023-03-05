using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfomation : MonoBehaviour
{
    public float lv;
    public float hp = 50f;
    public float dame = 10f;
    float exp = 0;
    float m_exp = 100;

    public void Update()
    {   
        if (exp >= m_exp)
        {
            lv++;
            m_exp = m_exp * 1.2f;
            dame = dame * 1.2f;
        }
        if(hp == 0)
        {
            //Game over
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
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
}
