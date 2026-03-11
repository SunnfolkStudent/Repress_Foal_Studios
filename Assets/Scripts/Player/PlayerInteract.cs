namespace Player
{
    using System;
    using UnityEngine;
    public class PlayerInteract  : MonoBehaviour
    {
        private void Start()
        {
            GameController.instance.onPlayerHide += UpdateHide;

        }

        private void UpdateHide()
        {
            if (!GameController.instance.playerIsHidden)
            {
                Debug.Log("PlayerHide");
            }
            else
            {
                Debug.Log("PlayerExitHide");
            }
        }
    }
}