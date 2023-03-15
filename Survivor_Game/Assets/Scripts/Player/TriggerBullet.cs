

using System;

using UnityEngine;

using static UnityEngine.RuleTile.TilingRuleOutput;

public class TriggerBullet : MonoBehaviour {

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
        string tag = gameObject.tag;
        Debug.Log(tag);
        if (IsEnemy(collision) == true)
        {
            switch (tag)
            {
                case "DanThuong":
                    HandlerDanThuong();
                    break;
                case "DanNo":
                    HandlerDanNo();
                    break;
                case "DanXuyen":
                    HandlerDanXuyen();
                    break;
                case "DanUltimate":
                    HandlerDanUltimate();
                    break;
            }
        }
    }

    private void HandlerDanUltimate()
    {
        throw new NotImplementedException();
    }

    private void HandlerDanXuyen()
    {
        Debug.Log("HandlerDanXuyen");
        Destroy(gameObject, 2f);
    }

    private void HandlerDanThuong()
    {
        throw new NotImplementedException();
    }

    public void HandlerDanNo()
    {
        Debug.Log("HandlerDanNo");

        float zoom = 2.0f;
        Vector3 newScale = new Vector3(zoom, zoom, 1);
        transform.localScale = newScale;
        Destroy(gameObject, 1f);
    }

    
}


