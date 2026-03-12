using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private InputSystem_Actions _input;

    public bool interact;
    public bool spiritVision;
    public float Horizontal, Vertical;
    
    
    private void Awake() => _input = new InputSystem_Actions();
    private void OnEnable() => _input.Enable();
    private void OnDisable() => _input.Disable();

    private void Update()
    {
        interact = _input.Player.Interact.WasPressedThisFrame();
        spiritVision = _input.Player.SpiritVision.WasPressedThisFrame();
        Horizontal = _input.Player.Move.ReadValue<Vector2>().x;
        Vertical = _input.Player.Move.ReadValue<Vector2>().y;
    }
}
