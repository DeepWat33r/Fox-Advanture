using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private PlayerController _playerController;
    // Start is called before the first frame update
    public int damageAmount = 1;
    private void OnTriggerStay2D(Collider2D other)
    {
        _playerController = other.GetComponent<PlayerController>();
        if (_playerController != null)
        {
            if(!_playerController.playerFlash)
                _playerController.TakeDamage(damageAmount, (_playerController.transform.position - transform.position));
        }

    }
}
