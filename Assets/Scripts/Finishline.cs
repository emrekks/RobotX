using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Finishline : MonoBehaviour
{
    [Header("Companent")][Tooltip("Assign the movement code inside PlayerManager to stop the movements of the players here.")] 
    public Movement movement;
   
    [Tooltip("Assign the gamemanager here to access the player count and power from here.")] 
    public GameManager gm;
   
    [Tooltip("Assign the boss script here to access the states of the boss")] 
    public EnemyBoss boss;
    
    //Limits the player's movement and changes the animation to idle when the player reaches the finish line
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(FinishLineStopDelay());
            
            foreach (var player in gm.players)
            {
                player.GetComponent<Player>().ChangeAnimation();
            }
        }
    }

    //Adds delay when reaching the finish line to decide who wins
    IEnumerator FinishLineStopDelay()
    {
        yield return new WaitForSeconds (0.4f);

        //Stops the players from shooting.
        foreach (var player in gm.players)
        {
            player.GetComponentInChildren<Gun>().canFirePlayer = false;
        }
        
        gm.CheckPlayerPower();

        movement.StopCharacters();
        
        movement.horizontal = 0;

        //Calculates who won with per sec attack damage
        if ((gm.playersFireRate / 60) * gm.playersDamage >= 700)
        {
            foreach (var player in gm.players)
            {
                player.GetComponentInChildren<Gun>().KillBoss();
                boss.finishline = true;
                player.transform.DOLookAt(boss.transform.position, 0.5f, axisConstraint: AxisConstraint.Y);
            }
        }
        else
        {
            boss.Jump();
        }
    }
    
    
}
