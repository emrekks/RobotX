using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Companent")]
    
    [Tooltip("Assign the movement here to stop the Player Manager when the characters are present.")]
    public Movement movement;
   
    [Tooltip("Assigns the active players here. You don't make an assignment.")]
    public GameObject[] players;

    [Tooltip("Displays the number of power in the upper left corner of the game screen.")]
    public TextMeshProUGUI powerTmp;

    [Tooltip("Integrates the number of power into a bar based on the target power number.")]
    public Image fillPowerBar;
    
    
    [Header("Current Players Total Stats")]
    public int playersDamage;
    public int playersFireRate;
    public int playersPower;
    public int playerCloneCount = 0;
    
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.2f);
        CheckPlayerPower();
    }

    private void Update()
    {
        players = GameObject.FindGameObjectsWithTag("Character");

        if (players.Length == 0)
        {
            movement.StopCharacters();
        }
    }

    //Updates the player power number and integrates the current numbers into the UI.
    public void CheckPlayerPower()
    {
        playersDamage = 0;
        playersFireRate = 0;
        
        foreach (var VARIABLE in players)
        {
            playersDamage += VARIABLE.GetComponent<GunManager>().currentWeapon.GetComponent<Gun>().damage;
            playersFireRate += VARIABLE.GetComponent<GunManager>().currentWeapon.GetComponent<Gun>().fireRate;
        }

        playersPower = (playersFireRate / 60) * playersDamage;

        powerTmp.text = "Power:" + playersPower;
        powerTmp.transform.DOPunchPosition(Vector3.up * 10, 1f, 10);
        
        fillPowerBar.fillAmount = (float)playersPower / 700;
    }
}
