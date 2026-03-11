using Player;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private InputManager _input;
    private PlayerInteract _playerInteract;
    
    
    void Start()
    {
        _input = GetComponent<InputManager>();
        _playerInteract = GetComponent<PlayerInteract>();
        
    }
    

    void Update()
    {
        if (_input.interact)
        {
            GameController.instance.PlayerHide();
        }
    }
}
