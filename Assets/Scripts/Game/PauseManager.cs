using System;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private bool isPaused;
    [SerializeField] private Canvas pauseMenu;
    private void Start()
    {
        
    }

    private void UpdatePauseMenu()
    {
        if (isPaused)
        {
            Debug.Log("Pause Menu");
        }
        else if (!isPaused)
        {
            Debug.Log("Unpause");
        }
    }
}
