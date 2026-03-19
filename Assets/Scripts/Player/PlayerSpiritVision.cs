using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerSpiritVision : MonoBehaviour
{

    public Volume screenFilterVolume;
    private ColorAdjustments _colorAdjustments;
    private Vignette _vignette;
    private ChromaticAberration _chromaticAberration;
    public Color filterColor;
    public Color originalfilterColor;
    

    private void Start()
    {
        GameController.instance.onSpiritVision += UpdateSpiritVision;
    }


    private void UpdateSpiritVision()
    {
        
        if (!GameController.instance.playerVisionOn)
        {
            screenFilterVolume.profile.TryGet(out ColorAdjustments _colorAdjustment);
            if (_colorAdjustment != null) _colorAdjustment.colorFilter.value = filterColor;
            Debug.Log("Spirit Vision on");
            GameController.instance.playerVisionOn = true;
            
        }
        else if (GameController.instance.playerVisionOn)
        {
            screenFilterVolume.profile.TryGet(out ColorAdjustments _colorAdjustment);
            if (_colorAdjustment != null) _colorAdjustment.colorFilter.value = originalfilterColor;
            GameController.instance.playerVisionOn = false;
            Debug.Log("Spirit Vision off");
        }
    }
}
