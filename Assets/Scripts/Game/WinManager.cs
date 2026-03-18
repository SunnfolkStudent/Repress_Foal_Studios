using System;
using UnityEngine;

public class WinManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameController.instance.winStateTriggered = true;
            GameController.instance.WinStateActive();
        }
    }
    
    
}
