using Player;
using UnityEngine;

[RequireComponent(typeof(PlayerInteract))]
public class PlayerInteractOutline : MonoBehaviour
{
    [SerializeField] private float _outlineSize = 1f;
    

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
