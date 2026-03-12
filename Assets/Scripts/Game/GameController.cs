using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    //Conditions
    public bool failStateTriggered;
    public bool winStateTriggered;
    //Mechanics
    public bool playerIsHidden;
    public  Vector3 activeCheckpointPosition;
    public Canvas RestartOrMenuCanvas;
      
   private void Awake()
       {
           if (instance == null)
           {
               instance = this;    
               DontDestroyOnLoad(gameObject);
           }
           else if (instance != this)
           {
               Destroy(gameObject);
           }
       }

   public void ReturnToChekpoint()
   {
       RestartOrMenuCanvas.gameObject.SetActive(false);
       failStateTriggered = false;
    
       var player = GameObject.FindGameObjectWithTag("Player");
       if (player != null && activeCheckpointPosition != Vector3.zero)
       {
           player.transform.position = activeCheckpointPosition;
       }
       else
       {
           SceneManager.LoadScene("Scenes/DevScene");
       }
   }

   
   public event Action onPlayerHide;
   public void PlayerHide()
   {
       Debug.Log(" attempting to PlayerHide");
       if (onPlayerHide != null)
       {
           onPlayerHide();
       }
   }

   public event Action onSpiritVision;

   public void SpiritVision()
   {
       if (onSpiritVision != null)
       {
           onSpiritVision();
       }
   }

}
