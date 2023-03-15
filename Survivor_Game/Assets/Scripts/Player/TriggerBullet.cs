

using System;

using UnityEngine;

using static UnityEngine.RuleTile.TilingRuleOutput;

public class TriggerBullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = gameObject.tag;
        Debug.Log(tag);
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

    private void HandlerDanUltimate()
    {
        throw new NotImplementedException();
    }

    private void HandlerDanXuyen()
    {
        Debug.Log("HandlerDanXuyen");
        Destroy(gameObject, 0.2f);
    }

    private void HandlerDanThuong()
    {
        throw new NotImplementedException();
    }

    public void HandlerDanNo()
    {
        float zoom = 3.0f;
        Vector3 newScale = new Vector3(zoom, zoom, 1);
        transform.localScale = newScale;
        Destroy(gameObject, 0.5f);
    }

    
}


