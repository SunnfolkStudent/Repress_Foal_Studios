using Player;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    private InputManager _input;
    private PlayerMovement _playerMovement;
    private Rigidbody2D _rb;
    [SerializeField] private float _moveSpeed = 5f;
    
    
    void Start()
    {
        _input = GetComponent<InputManager>();
        _playerMovement = GetComponent<PlayerMovement>();
        _rb = GetComponent<Rigidbody2D>();
    }
    

    void Update()
    {
        if (_input.interact)
        {
            // GAMECONTROLLER PREFAB NEEDS TO BE IN THE SCENE
            switch (GameController.instance.playerHidden)
            {
                case false:
                    GameController.instance.PlayerHide();
                    break;
                case true:
                    GameController.instance.PlayerHideExit();
                    break;
            }
        }
        if (!GameController.instance.freezeMovement)
        {
            if (_input.spiritVision) GameController.instance.SpiritVision();
            _playerMovement.SetMoveDirection(_rb, _moveSpeed);
        }
        
        
    }
}
