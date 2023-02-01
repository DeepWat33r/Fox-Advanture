using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private PlayerController _playerController;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other)
    {
        _playerController = other.GetComponent<PlayerController>();
        if (_playerController != null)
        {
            _playerController.HealthDecreased(1);
        }
    }
}
