using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
    private Rigidbody rb;

    private float speed = 5;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        if (GameController.instance.isGo)
        {
            rb.velocity = new Vector3(0f, 0, -speed);
            rb.isKinematic = false;
        }
        else
        {
            rb.velocity = new Vector3(0, 0, 0);
            rb.isKinematic = true;
        }
    }
}
