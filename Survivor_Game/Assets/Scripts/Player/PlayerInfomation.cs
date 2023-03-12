using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfomation : MonoBehaviour
{
    float lv = 1;
    float hp = 50f;
    float dame = 10f;
    float exp = 0;
    float m_exp = 100;

    public delegate void LevelChangedEventHandler(float newLevel);
    public event LevelChangedEventHandler LevelChanged;

    public float Lv { get => lv;
        set {
            lv = value;
            if (LevelChanged != null)
            {
                LevelChanged(lv);
            }
        }  
    }
    public float Hp { get => hp; set => hp = value; }
    public float Dame { get => dame; set => dame = value; }
    public float Exp { get => exp; set => exp = value; }
    public float Exp1 { get => m_exp; set => m_exp = value; }

    public void Update()
    {   
        if (Exp >= Exp1)
        {
            Lv++;
            Exp1 = Exp1 * 1.2f;
            Dame = Dame * 1.2f;
        }
        if(Hp == 0)
        {
            //Game over
        }
    }

}
