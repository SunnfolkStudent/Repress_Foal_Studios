using Player;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    private InputManager _input;
    private PlayerMovement _playerMovement;
    private PlayerInteract _playerInteract;
    private Rigidbody2D _rb;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private bool ToggleOnSpiritVision;
    
    
    void Start()
    {
        _input = GetComponent<InputManager>();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerInteract = GetComponent<PlayerInteract>();
        _rb = GetComponent<Rigidbody2D>();
    }
    

    void Update()
    {
        if (!GameController.instance.gameIsPaused)
        {
            if (_input.interact)
            {
                // GAMECONTROLLER PREFAB NEEDS TO BE IN THE SCENE
                switch (GameController.instance.playerHidden)
                {
                    case false:
                        _playerInteract.UpdateHide();
                        break;
                    case true:
                        _playerInteract.UpdateHideExit();
                        break;
                }
            }
            if (_input.spiritVision)
            {
                switch (ToggleOnSpiritVision)
                {
                    case true:
                        GameController.instance.SpiritVisionDeactivated();
                        ToggleOnSpiritVision = false;
                        break;
                    case false:
                        GameController.instance.SpiritVisionActivated();
                        ToggleOnSpiritVision = true;
                        break;
                }
            }

            if (!GameController.instance.freezeMovement)
            {
                _playerMovement.SetMoveDirection(_rb, _moveSpeed);
            }
        }
        
        
    }
}
