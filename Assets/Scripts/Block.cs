using TMPro;
using DG.Tweening;
using UnityEngine;

public class Block : MonoBehaviour, IDamagable
{ 
    public int Health { get; set; }
    public int blockHealth = 100;
    [Header("Companent")] 
    public TextMeshPro tmp;

    private void Start()
    {
        Health = blockHealth;
        
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

            transform.DOScale(Vector3.zero, 0.35f).OnComplete(() =>
            {
                gameObject.SetActive(false);
            });
        }
        
        tmp.text = Health.ToString();
    }
}
