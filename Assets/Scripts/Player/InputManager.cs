using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private InputSystem_Actions _inputSystemActions;

    public bool interact;
    
    private void Awake() => _inputSystemActions = new InputSystem_Actions();
    private void OnEnable() => _inputSystemActions = new InputSystem_Actions();
    private void OnDisable() => _inputSystemActions = new InputSystem_Actions();

    private void Update()
    {
        interact = _inputSystemActions.Player.Interact.WasPressedThisFrame();
    }
}
