using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int GemCollected;

    private void Awake()
    {
        GemCollected = 0;
    }
    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.gameObject.CompareTag(MushroomTag))
    //     {
    //         ColorState.ChangeColor(this);
    //     }
    // }
    // public void ChangeSpriteRendererColor(Color color)
    // {
    //     _spriteRenderer.color = color;
    // }
}
