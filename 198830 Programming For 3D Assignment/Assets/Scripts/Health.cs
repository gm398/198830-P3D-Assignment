using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private float MaxHealth = 20;
    [SerializeField] private float CurrentHealth;
    [SerializeField] private bool IsDead = false;

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }
    public float GetHealth()
    {
        return CurrentHealth;
    }
    public void SetHealth(float health)
    {
        MaxHealth = health;
        if(CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
    }
    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        if(CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            IsDead = true;
            gameObject.BroadcastMessage("Die", null, SendMessageOptions.DontRequireReceiver);
        }
    }
}
