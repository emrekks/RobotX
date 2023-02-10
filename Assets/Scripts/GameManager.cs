using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int playerCloneCount = 0;
    public GameObject[] players;
    public int playerPower;
    public Movement movement;

    private void Update()
    {
        players = GameObject.FindGameObjectsWithTag("Character");

        if (players.Length == 0)
        {
            movement.StopCharacters();
        }
    }

    public void CheckPlayerPower()
    {
        foreach (var VARIABLE in players)
        {
            playerPower += VARIABLE.GetComponent<GunManager>().currentWeapon.GetComponent<Gun>().damage;
        }
    }
}
