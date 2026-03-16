namespace Player
{
    using System;
    using UnityEngine;
    public class PlayerInteract  : MonoBehaviour
    {
        [SerializeField] private float _interactRadius = 3f;

        private Vector3 _enterPosition;
        private void Start()
        {
            
            GameController.instance.onPlayerHide += UpdateHide;
            GameController.instance.onPlayerHideExit += UpdateHideExit;

        }

        private void UpdateHide()
        {
            _enterPosition = transform.position;
            Collider2D hit = Physics2D.OverlapCircle(transform.position, _interactRadius, 1 << 6);
            if (hit != null)
            {
                var targetPosition = hit.transform.position;
                transform.position = targetPosition;
                
                GameController.instance.playerHidden = true;
                
                Debug.Log ("the player is hidden");
            }
           
            
        }

        private void UpdateHideExit()
        {
            transform.position = _enterPosition;
            GameController.instance.playerHidden = false;
            Debug.Log ("the player is not hidden");
        }
    }
}