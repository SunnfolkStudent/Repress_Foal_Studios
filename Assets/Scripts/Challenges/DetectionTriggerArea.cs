using System;
using UnityEngine;

public class DetectionTriggerArea : MonoBehaviour
{
    private float countDown = 2f;
    private bool counting;
    private void OnTriggerEnter2D(Collider2D other)
    {
     
        if (other.CompareTag("Player") && !GameController.instance.playerHidden)
        {
            if (!counting)countDown = +Time.time;
            
            if (countDown < Time.time)
            {
                GameController.instance.FailStateActive();
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !GameController.instance.playerHidden)
        {
            
        }
    }

    
}
