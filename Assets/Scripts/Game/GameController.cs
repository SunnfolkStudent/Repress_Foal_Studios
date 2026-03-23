using System;
using UnityEngine;


public class GameController : MonoBehaviour
{
    public static GameController instance;
    //Conditions
    public bool failStateTriggered;
    public bool winStateTriggered;

    public bool freezeMovement;
    //Mechanics
    public bool playerHidden;
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

   #region PLAYER MECHANICS

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

    public event Action onSpiritVisionActivated;
    public void SpiritVisionActivated()
    {
      if (onSpiritVisionActivated != null)
      {
          onSpiritVisionActivated();
      }
    }
    public event Action onSpiritVisionDeactivated;
    public void SpiritVisionDeactivated()
    {
        if (onSpiritVisionDeactivated != null)
        {
            onSpiritVisionDeactivated();
        }
    }

   #endregion

   #region WIN/LOSE CONDITION
    public event Action onFailStateActive;
       public void FailStateActive()
       {
           if (onFailStateActive != null)
           {
               Debug.Log("FailstateActive");
               onFailStateActive();
           }
       }
       public event Action onWinstateActive;

       public void WinStateActive()
       {
           if (onWinstateActive != null)
           {
               Debug.Log("WinstateActive");
               onWinstateActive();
           }
       }
   #endregion
   

}
