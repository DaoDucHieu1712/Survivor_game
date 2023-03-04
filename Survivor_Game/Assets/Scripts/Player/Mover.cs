using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public Transform target; // Object B
    public float speed = 10f; // movement speed of Object A\

    public FixedJoystick joystick;
    Vector2 move;
    Rigidbody2D rb;

    private Vector3 direction;
    private Transform myTransform;
    void Start()
    {
        myTransform = transform;
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        float s = vertical * speed * Time.deltaTime;
        transform.Translate(0, s, 0);

        if (horizontal != 0 || vertical != 0)
        {
            Vector3 direction = new Vector3(horizontal, vertical, 0f);
            transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
        }
    }

 

}
