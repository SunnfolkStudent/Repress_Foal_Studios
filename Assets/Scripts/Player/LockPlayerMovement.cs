using UnityEngine;

public class LockPlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        GameController.instance.onFailStateActive += LockMovement;
        GameController.instance.onPlayerHide += LockMovement;
        GameController.instance.onPlayerHideExit += UnlockMovement;
        GameController.instance.onWinstateActive += LockMovement;
    }

    // Update is called once per frame
    private void LockMovement()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Rigidbody2D _rb = player.GetComponent<Rigidbody2D>();
        
        GameController.instance.freezeMovement = true;
        _rb.linearVelocity = Vector2.zero;
    }

    private void UnlockMovement()
    {
        GameController.instance.freezeMovement = false;
    }
}
