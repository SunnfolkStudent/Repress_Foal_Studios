using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerSpiritVision : MonoBehaviour
{

    public Volume screenFilterVolume;
    private ColorAdjustments _colorAdjustments;
    public Color filterColor;
    public Color originalfilterColor;
    public bool toggleOn;

    private void Start()
    {
        GameController.instance.onSpiritVision += UpdateSpiritVision;
    }


    private void UpdateSpiritVision()
    {
        Debug.Log("UpdateSpiritVision");
        if (toggleOn)
        {
            screenFilterVolume.profile.TryGet(out ColorAdjustments _colorAdjustment);
            if (_colorAdjustment != null) _colorAdjustment.colorFilter.value = filterColor;
            
            toggleOn = false;
        }
        else if (!toggleOn)
        {
            screenFilterVolume.profile.TryGet(out ColorAdjustments _colorAdjustment);
            if (_colorAdjustment != null) _colorAdjustment.colorFilter.value = originalfilterColor;
            toggleOn = true;
        }
    }
}
