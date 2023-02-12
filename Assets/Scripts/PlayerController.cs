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
    public int Health { get; private set; }


    public UnityEvent<PlayerController> onGemScored;
    public UnityEvent<PlayerController> onHealthDecreased;


    public void GemCollected()
    {
        NumbersOfGems++;
        onGemScored.Invoke(this);
    }

    public void HealthDecreased(int damage)
    {
        Health-=damage;
        onHealthDecreased.Invoke(this);
    }
}