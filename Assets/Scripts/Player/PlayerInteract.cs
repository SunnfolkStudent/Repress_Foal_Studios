namespace Player
{
    using System;
    using UnityEngine;
    public class PlayerInteract  : MonoBehaviour
    {
       public float interactRadius = 3f;

       private SpriteRenderer _spriteRenderer;
        private Vector3 _enterPosition;

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void UpdateHide()
        {
            _enterPosition = transform.position;
            Collider2D hit = Physics2D.OverlapCircle(transform.position, interactRadius, 1 << 6);
            if (hit != null)
            {
                var targetPosition = hit.transform.position;
                transform.position = targetPosition;
                _spriteRenderer.enabled = false;
                GameController.instance.playerHidden = true;
                GameController.instance.PlayerHide();
                Debug.Log ("the player is hidden");
            }
           
            
        }

        public void UpdateHideExit()
        {
            _spriteRenderer.enabled = true;
            transform.position = _enterPosition;
            GameController.instance.playerHidden = false;
            GameController.instance.PlayerHideExit();
            Debug.Log ("the player is not hidden");
        }
    }
}