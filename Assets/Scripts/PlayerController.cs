using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    public int NumbersOfGems { get; private set; }

    public UnityEvent<PlayerController> onGemScored;

    public void GemCollected()
    {
        NumbersOfGems++ ;
        onGemScored.Invoke(this);
    }
}
