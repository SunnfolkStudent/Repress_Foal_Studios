using System;
using UnityEngine;
using UnityEngine.SceneManagement;

using System.Collections;
public class FailManager : MonoBehaviour
{
    
    public Canvas RestartOrMenuCanvas;

    private void Start()
    {
        GameController.instance.onFailStateActive += ActivateFailMenu;
        RestartOrMenuCanvas.gameObject.SetActive(false);
    }

    private void ActivateFailMenu()
    {
        GameController.instance.failStateTriggered = true;
        GameController.instance.freezeMovement = true;
        RestartOrMenuCanvas.gameObject.SetActive(true);
    }
    
    public void ReturnToChekpoint()
    {
        GameObject Restart = GameObject.Find("RestartOrMenuCanvas");
                Restart.SetActive(false);
        GameController.instance.failStateTriggered = false;
        GameController.instance.freezeMovement = false;
    
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player != null && GameController.instance.activeCheckpointPosition != Vector3.zero)
        {
            player.transform.position = GameController.instance.activeCheckpointPosition;
            GameController.instance.PlayerHide();
        }
        else
        {
            
            Restart.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        //RestartOrMenuCanvas.gameObject.SetActive(false);
        
    }

    private void ReturnToMenu()
    {
        RestartOrMenuCanvas.gameObject.SetActive(false);
        GameController.instance.failStateTriggered = false;
        SceneManager.LoadScene("Scenes/Main_Menu");
    }
}
