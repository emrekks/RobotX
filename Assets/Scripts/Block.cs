using TMPro;
using DG.Tweening;
using UnityEngine;

public class Block : MonoBehaviour, IDamagable
{ 
    [Header("Stats")][Tooltip("Sets the player's health.")]
    public int blockHealth = 100;

    [Header("Companent")][Tooltip("Assign the TextMeshPro that displays the player's health value here.")] 
    public TextMeshPro tmp;

    //IDamageable properties
    public int Health { get; set; }
    
    private void Start()
    {
        Health = blockHealth;
        
        tmp.text = Health.ToString();
    }

    //Function of the IDamageable interface. Works when the block is damaged.
    public void Damage(int amount)
    {
        Health -= amount;
        
        //For damaged blocks to give feedback
        transform.DORewind();
        transform.DOPunchScale(new Vector3(0.3f,0.15f,0.3f), 0.5f);

        
        if (Health <= 0)
        {
            Health = 0;
            
            //Blocks with a health value of zero will shrink and disappear.
            transform.DOScale(Vector3.zero, 0.35f).OnComplete(() =>
            {
                gameObject.SetActive(false);
            });
        }
        
        tmp.text = Health.ToString();
    }
}
