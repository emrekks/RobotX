using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(-horizontal, 0, -1);
        rb.velocity = move * speed;
    }
}
