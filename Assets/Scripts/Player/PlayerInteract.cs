namespace Player
{
    using System;
    using UnityEngine;
    public class PlayerInteract  : MonoBehaviour
    {
        [SerializeField] private float _interactRadius = 3f;
        [SerializeField] private int _interactLayer = 1 << 6;
        private void Start()
        {
            
            GameController.instance.onPlayerHide += UpdateHide;

        }

        public void UpdateHide()
        {
            var enterPosition = transform.position;
            
            if (!GameController.instance.playerIsHidden)
            {
                Debug.Log("PlayerHide");
                
                Collider2D hit = Physics2D.OverlapCircle(transform.position, _interactRadius, _interactLayer);
                if (hit != null)
                {
                    var targetPosition = hit.transform.position;
                    transform.position = targetPosition;
                    
                    GameController.instance.playerIsHidden = true;
                    
                }

            }
            else
            {
                Debug.Log("PlayerExitHide");
                GameController.instance.playerIsHidden = false;
                transform.position = enterPosition;
            }
        }
    }
}