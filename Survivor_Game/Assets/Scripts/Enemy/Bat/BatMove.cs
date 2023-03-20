using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMove : MonoBehaviour
{
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        GameObject walkers = GameObject.FindGameObjectWithTag("Player");

        Vector2 closestWalkerDirection = Vector2.zero;
        float closestDistance = Mathf.Infinity;

        float distance = Vector2.Distance(transform.position, walkers.transform.position);
        if (distance < closestDistance && distance <= 10f)
        {
            closestDistance = distance;
            closestWalkerDirection = (walkers.transform.position - transform.position).normalized;
        }
        if (closestDistance <= 10f)
        {
            float angle = Mathf.Atan2(closestWalkerDirection.y, closestWalkerDirection.x) * Mathf.Rad2Deg - 90f;
            Quaternion lookRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 500f);
        }
    }
}
