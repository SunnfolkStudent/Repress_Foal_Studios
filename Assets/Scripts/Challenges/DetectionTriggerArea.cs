using System;
using UnityEngine;

public class DetectionTriggerArea : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
     
        if (other.CompareTag("Player") && !GameController.instance.playerHidden)
        {
           
            GameController.instance.FailStateActive();
        }
    }
}
