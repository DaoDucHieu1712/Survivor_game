using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public Transform target; // Object B
    public float speed = 10f; // movement speed of Object A

    private Vector3 direction;
    private Transform myTransform;
    void Start()
    {
        myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        float s = Input.GetAxis("Vertical") * 10f * Time.deltaTime;

        transform.Translate(0, s, 0);

        float steerAmount = Input.GetAxis("Horizontal") * 100f * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);

    }

}
