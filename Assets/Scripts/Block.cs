using TMPro;
using DG.Tweening;
using UnityEngine;

public class Block : MonoBehaviour, IDamagable
{ 
    public int Health { get; set; }

    [Header("Companent")] 
    public TextMeshPro tmp;
    public GameManager gm;
    public Transform hand;
    public Enemy enemy;
    

    private void Start()
    {
        Health = 100;
        
        tmp.text = Health.ToString();
    }

    public void Damage(int amount)
    {
        Health -= amount;
        
        transform.DORewind();
        transform.DOPunchScale(new Vector3(0.3f,0.15f,0.3f), 0.5f);

        
        if (Health <= 0)
        {
            Health = 0;

            gameObject.SetActive(false);
        }
        
        tmp.text = Health.ToString();
    }
}
