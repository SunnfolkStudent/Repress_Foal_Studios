using UnityEngine;

public class ViewConeManager : MonoBehaviour
{
    private SpriteRenderer _viewCone;
    
    void Start()
    {
        
        _viewCone = this.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        _viewCone.GetComponent<SpriteRenderer>().enabled = false;
        GameController.instance.onSpiritVisionActivated += ActivateConeVisibility;
        GameController.instance.onSpiritVisionDeactivated += DeactivateConeVisibility;
    }


    void ActivateConeVisibility()
    {
        _viewCone.enabled = true;
    }

    void DeactivateConeVisibility()
    {
        _viewCone.enabled = false;
    }
    
    
}
