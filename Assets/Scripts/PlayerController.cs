using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int NumbersOfGems { get; private set; }

    public void GemCollected()
    {
        NumbersOfGems++ ;
    }
}
