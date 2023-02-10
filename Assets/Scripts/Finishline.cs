using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Finishline : MonoBehaviour
{
    public Movement movement;

    public GameManager gm;

    public EnemyBoss boss;
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

    IEnumerator FinishLineStopDelay()
    {
        yield return new WaitForSeconds (0.4f);

        foreach (var player in gm.players)
        {
            player.GetComponentInChildren<Gun>().canFirePlayer = false;
        }
        
        gm.CheckPlayerPower();

        movement.StopCharacters();
        
        movement.horizontal = 0;

        if (gm.playerPower >= 100)
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
