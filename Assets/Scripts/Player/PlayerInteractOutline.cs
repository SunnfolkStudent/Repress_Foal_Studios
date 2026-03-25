using System;
using Player;
using UnityEngine;

public class PlayerInteractOutline : MonoBehaviour
{
    private PlayerInteract _playerInteract;
    [SerializeField] private float _outlineSize = 1f;

    private void Start()
    {
        _playerInteract = GetComponentInParent<PlayerInteract>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        SpriteRenderer spriteRenderer = other.GetComponent<SpriteRenderer>();
        spriteRenderer.material.SetFloat("_OutlineSize", _outlineSize);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        
        SpriteRenderer spriteRenderer = other.GetComponent<SpriteRenderer>();
        spriteRenderer.material.SetFloat("_OutlineSize", 0);
    }
}
