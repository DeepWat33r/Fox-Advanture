using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    public int NumbersOfGems { get; private set; }
    // public int Health { get; private set; }
    public int MaxHealth = 5;
    public int CurrentHealth;
    public HealthBar HealthBar;

    public UnityEvent<PlayerController> onGemScored;
    //public UnityEvent<PlayerController> onHealthDecreased;
    void Start()
    {
        CurrentHealth = MaxHealth;
        HealthBar.SetMaxHealth(MaxHealth);
    }

    public void GemCollected()
    {
        NumbersOfGems++;
        onGemScored.Invoke(this);
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        HealthBar.SetHealth(CurrentHealth);
    }
    // public void HealthDecreased(int damage)
    // {
    //     Health-=damage;
    //     onHealthDecreased.Invoke(this);
    // }
}