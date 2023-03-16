using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {


    public float speed = 10f;
    public float rotationSpeed = 100f;

    public FixedJoystick joystick;
    void Start()
    {
    }

    void Update()
    {

        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        Vector3 direction = new Vector3(horizontal, vertical, 0f).normalized;

        if (direction.magnitude > 0.1f)
        {
            // Rotate the game object based on the direction of the joystick
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle - 90f);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Move the game object in the direction of the joystick
            transform.position += direction * speed * Time.deltaTime;
        }
    }

}
