using System;
using UnityEngine;


public class GameController : MonoBehaviour
{
    public static GameController instance;
    //Conditions
    public bool failStateTriggered;
    public bool winStateTriggered;

    public bool freezeMovement = false;
    //Mechanics
    public bool playerHidden;
    public bool playerVisionOn;
    public bool gameIsPaused;
    public Vector3 activeCheckpointPosition;
      
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

   
   public event Action onPlayerHide;
   public void PlayerHide()
   {
       if (onPlayerHide != null)
       {
           onPlayerHide();
       }
   }
   public event Action onPlayerHideExit;

   public void PlayerHideExit()
   {
       if (onPlayerHideExit != null)
       {
           onPlayerHideExit();
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
   public event Action onFailStateActive;
   public void FailStateActive()
   {
       if (onFailStateActive != null)
       {
           Debug.Log("FailstateActive");
           onFailStateActive();
       }
   }

}
