using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("4 Directional Move")]
    public Vector2 MoveDirection;
    private Animator _animator;
    private InputManager _input;
    private bool[] LRUD = new []{false, false, false, false}; // Left, Right, Up, Down bools
    private Vector2[] moveDirection = new [] {new Vector2(-1,0), new Vector2(1, 0), new Vector2(0,1), new Vector2(0, -1) }; // L R U D Directions
    [SerializeField] private List<Vector2> directions; // List to save the current direction


    private void Start()
    {
        _input =  GetComponent<InputManager>();
        _animator = GetComponent<Animator>();
    }

    #region MOVEMENT

    public void SetMoveDirection(Rigidbody2D _rb, float moveSpeed)
        {
            if (Gamepad.current != null)
            {
                //Deadzone
                if (Mathf.Abs(Gamepad.current.leftStick.value.x) > 0.12f ||
                    (Mathf.Abs(Gamepad.current.leftStick.value.y) > 0.12f))
                {
                    UpdateControlMovement(_rb, moveSpeed);
                }
                else
                {
                    UpdateKeyboardMovement(_rb, moveSpeed);
                }
            }
            else
            {
                UpdateKeyboardMovement(_rb, moveSpeed);
            }
            
        }
    
        private void UpdateControlMovement( Rigidbody2D _rb, float moveSpeed)
        {
            if (Mathf.Abs(_input.Horizontal) > Mathf.Abs(_input.Vertical))
            {
                _rb.linearVelocityX = moveSpeed * _input.Horizontal;
                _rb.linearVelocityY = 0;
            }
            else if (Mathf.Abs(_input.Horizontal) < Mathf.Abs(_input.Vertical))
            {
                _rb.linearVelocityY = moveSpeed * _input.Vertical;
                _rb.linearVelocityX = 0;
            }
            else
            {
                _rb.linearVelocityX = 0;
                _rb.linearVelocityY = 0;
                _animator.SetBool("isWalking", false);
            }
            
            
        }
    
        private void UpdateKeyboardMovement(Rigidbody2D _rb, float moveSpeed)
        {
          
            if (Gamepad.current != null)
            {
                LRUD[0] = Keyboard.current.aKey.isPressed || Gamepad.current.dpad.left.isPressed ? true : false;
                LRUD[1] = Keyboard.current.dKey.isPressed || Gamepad.current.dpad.right.isPressed ? true : false;
                LRUD[2] = Keyboard.current.wKey.isPressed || Gamepad.current.dpad.up.isPressed ? true : false;
                LRUD[3] = Keyboard.current.sKey.isPressed || Gamepad.current.dpad.down.isPressed ? true : false;
            }
            else
            {
                LRUD[0] = Keyboard.current.aKey.isPressed;
                LRUD[1] = Keyboard.current.dKey.isPressed;
                LRUD[2] = Keyboard.current.wKey.isPressed;
                LRUD[3] = Keyboard.current.sKey.isPressed;
            }
    
            for (int i = 0; i < LRUD.Length; i++)
            {
                if (LRUD[i] == true && !directions.Contains(moveDirection[i]))
                {
                    directions.Add(moveDirection[i]);
                }
                else if (LRUD[i] == false)
                {
                    directions.Remove(moveDirection[i]);
                }
            }
            MoveDirection = directions.Count > 0 ? directions.Last() : Vector2.zero;
            _rb.linearVelocity = MoveDirection * moveSpeed;
            
            
            if (_rb.linearVelocity == Vector2.zero)
            {
                Debug.Log(MoveDirection.x);
                _animator.SetBool("isWalking", false);
                
                
            }
            else if (_rb.linearVelocity != Vector2.zero)
            {
                _animator.SetBool("isWalking", true);
                _animator.SetFloat("lastInputX", _rb.linearVelocity.x);
                _animator.SetFloat("lastInputY", _rb.linearVelocity.y);
            }
            
        }

    #endregion

    

    
}