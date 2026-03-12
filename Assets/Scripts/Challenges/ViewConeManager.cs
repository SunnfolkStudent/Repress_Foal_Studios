using UnityEngine;

public class ViewConeManager : MonoBehaviour
{
    private GameObject _viewCone;
   
    void Start()
    {
        
        _viewCone = this.gameObject.transform.GetChild(0).gameObject;
        GameController.instance.onSpiritVision += UpdateViewConeVisibility;
    }


    void UpdateViewConeVisibility()
    {
        if (GameController.instance.PlayerVisionOn) _viewCone.GetComponent<SpriteRenderer>().enabled = false;
        else _viewCone.GetComponent<SpriteRenderer>().enabled = true;
    }
}
