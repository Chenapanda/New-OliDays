using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public float maxHealth = 3f;
    private float health = 3f;
    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }
    }


    void Start()
    {
        this.Health = this.health;
    }


    public void TakeDamage(int amount)
    {
        Health -= amount;
        if (Health <= 0)
            Die();
    }

    private void Die()
    {
        Debug.Log("Player dead. Reset health.");
        this.Health = this.maxHealth;    
    }
}
