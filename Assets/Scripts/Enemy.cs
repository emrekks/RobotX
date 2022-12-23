using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public Quaternion turretQuaternion;
    public Transform turretMovingPart;
    public float enemyPerceiveDistance;
    private float _distanceBetweenToObject;

    private void Start()
    {
        turretQuaternion = turretMovingPart.localRotation;
    }

    void Update()
    {
        _distanceBetweenToObject = Vector3.Distance(player.position, transform.position);

        if (_distanceBetweenToObject <= enemyPerceiveDistance)
        {
            var v3T = player.transform.position - transform.position;
            v3T.y = turretMovingPart.position.y + 50;
            turretQuaternion = Quaternion.LookRotation(v3T, Vector3.up);        
            turretMovingPart.rotation = Quaternion.RotateTowards(turretMovingPart.rotation, turretQuaternion, 30 * Time.deltaTime);
        }
    }
}
