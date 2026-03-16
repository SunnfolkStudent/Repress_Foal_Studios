using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FailManager : MonoBehaviour
{
    
    public Canvas RestartOrMenuCanvas;

    private void Start()
    {
        GameController.instance.onFailStateActive += ActivateFailMenu;
    }

    private void ActivateFailMenu()
    {
        GameController.instance.failStateTriggered = true;
        GameController.instance.freezeMovement = true;
        RestartOrMenuCanvas.gameObject.SetActive(true);
    }
    
    public void ReturnToChekpoint()
    {
        RestartOrMenuCanvas.gameObject.SetActive(false);
        GameController.instance.failStateTriggered = false;
        GameController.instance.freezeMovement = false;
    
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player != null && GameController.instance.activeCheckpointPosition != Vector3.zero)
        {
            player.transform.position = GameController.instance.activeCheckpointPosition;
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    private void ReturnToMenu()
    {
        RestartOrMenuCanvas.gameObject.SetActive(false);
        GameController.instance.failStateTriggered = false;
        Debug.Log("No menu scene to load");
        //SceneManager.LoadScene("Scenes/MenuScene");
    }
}
