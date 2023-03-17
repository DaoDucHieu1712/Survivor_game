

using System;

using UnityEngine;

using static UnityEngine.EventSystems.EventTrigger;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class TriggerBullet : MonoBehaviour {

    private FlowerProperti Flower;
    private EvilProperty Evil;
    private BatProperty Bat;
    private PlayerInfomation player;

    public void Start()
    {
        Flower = FindObjectOfType<FlowerProperti>();
        Evil = FindObjectOfType<EvilProperty>();
        Bat = FindObjectOfType<BatProperty>();
        player = FindObjectOfType<PlayerInfomation>();

    }
    public bool IsEnemy(Collider2D collision)
    {
        if(collision.gameObject.tag == "Flower" || collision.gameObject.tag == "Evil" || collision.gameObject.tag == "Bat")
        {
            return true;
        }
        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string enemyTag = collision.gameObject.tag;
        float damePlayer = player.dame;
        string tag = gameObject.tag;
        Debug.Log(tag);
        if (IsEnemy(collision) == true)
        {
            switch (tag)
            {
                case "DanThuong":
                    HandlerDanThuong(damePlayer, enemyTag);
                    break;
                case "DanNo":
                    HandlerDanNo(damePlayer, enemyTag);
                    break;
                case "DanXuyen":
                    HandlerDanXuyen(damePlayer, enemyTag);
                    break;
                case "DanUltimate":
                    HandlerDanUltimate(damePlayer, enemyTag);
                    break;
            }
        }
    }

    private void HandlerDanUltimate(float dame, string enemy)
    {
        float zoom = 2.0f;
        Vector3 newScale = new Vector3(zoom, zoom, 1);
        transform.localScale = newScale;
        DameEnemy(dame, enemy);
        Destroy(gameObject, 2f);
    }

    private void HandlerDanXuyen(float dame, string enemy)
    {
        Debug.Log("HandlerDanXuyen");
        DameEnemy(dame, enemy);
        Destroy(gameObject, 2f);
    }

    private void HandlerDanThuong(float dame, string enemy)
    {
        DameEnemy(dame, enemy);
    }

    public void HandlerDanNo(float dame, string enemy)
    {

        float zoom = 2.0f;
        Vector3 newScale = new Vector3(zoom, zoom, 1);
        transform.localScale = newScale;

        DameEnemy(dame, enemy);
        Destroy(gameObject, 1f);
    }

    public void DameEnemy(float dame, string enemy)
    {
        switch (enemy)
        {
            case "Flower":
                Flower.TakeDamage(dame);
                break;
            case "Bat":
                Bat.TakeDamage(dame);
                break;
            case "Evil":
                Evil.TakeDamage(dame);
                break;
        }
    }

    
}


