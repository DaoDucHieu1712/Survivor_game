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
        GameObject enemy = collision.gameObject;
        string tag = gameObject.tag;
        float damePlayer = player.dame;
        if (IsEnemy(collision) == true)
        {
            switch (tag)
            {
                case "DanThuong":
                    HandlerDanThuong(damePlayer, enemy);
                    break;
                case "DanNo":
                    HandlerDanNo(damePlayer, enemy);
                    break;
                case "DanXuyen":
                    HandlerDanXuyen(damePlayer, enemy);
                    break;
                case "DanUltimate":
                    HandlerDanUltimate(damePlayer, enemy);
                    break;
            }
        }
    }

    private void HandlerDanUltimate(float dame, GameObject enemy)
    {
        float zoom = 2.0f;
        Vector3 newScale = new Vector3(zoom, zoom, 1);
        transform.localScale = newScale;

        DameEnemy(dame, enemy);

        Destroy(gameObject, 2f);
    }

    private void HandlerDanXuyen(float dame, GameObject enemy)
    {
        Debug.Log("HandlerDanXuyen");

        DameEnemy(dame, enemy);

        Destroy(gameObject, 2f);
    }

    private void HandlerDanThuong(float dame, GameObject enemy)
    {
        DameEnemy(dame, enemy);
        Destroy(gameObject);
    }

    public void HandlerDanNo(float dame, GameObject enemy)
    {

        float zoom = 2.0f;
        Vector3 newScale = new Vector3(zoom, zoom, 1);
        transform.localScale = newScale;

        DameEnemy(dame, enemy);


        Destroy(gameObject, 0.2f);
    }

    public void DameEnemy(float dame, GameObject enemy)
    {
        switch (enemy.tag)
        {
            case "Flower":
                enemy.GetComponent<FlowerProperti>().TakeDamage(dame);
                break;
            case "Bat":
                enemy.GetComponent<BatProperty>().TakeDamage(dame);
                break;
            case "Evil":
                enemy.GetComponent<EvilProperty>().TakeDamage(dame);
                break;
        }
    }

    
}


