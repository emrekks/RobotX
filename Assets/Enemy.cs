using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float enemyPerceiveDistance;
    private float _distanceBetweenToObject;
    
    void Update()
    {
        _distanceBetweenToObject = Vector3.Distance(player.position, transform.position);

        if (_distanceBetweenToObject <= enemyPerceiveDistance)
        {
            transform.LookAt(player);
        }
    }
}
