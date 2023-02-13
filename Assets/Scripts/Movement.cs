using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //public GameManager gm;
    [Header("Values")]
    [SerializeField] private float speed;
    [SerializeField] private float maxValue;
    [SerializeField] private float minValue;
  
    [HideInInspector]public float forwardSpeed = 1;
    [HideInInspector]public bool lockMovement = false;
    [HideInInspector]public float horizontal;

    private void Update()
    {
        //Movement
        if (!lockMovement)
        {
            horizontal = Input.GetAxis("Horizontal");
        }

        Vector3 move = new Vector3(horizontal, 0, forwardSpeed);
        
        transform.Translate(move * (speed * Time.deltaTime));

        
        //Clamp Character Movement to adding border to map
        Vector3 clampedPosition = transform.position;

        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minValue, maxValue);

        transform.position = clampedPosition;
    }

    public void StopCharacters()
    {
        lockMovement = true;

        speed = 0;
    }
}
