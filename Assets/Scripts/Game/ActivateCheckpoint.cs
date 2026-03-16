using UnityEngine;

public class ActivateCheckpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log ("Checkpoint activated");
            GameController.instance.activeCheckpointPosition = transform.position;
        }
    }
}