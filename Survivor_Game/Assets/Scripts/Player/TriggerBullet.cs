

using UnityEngine;

public class TriggerBullet : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(gameObject.tag);
    }
}


