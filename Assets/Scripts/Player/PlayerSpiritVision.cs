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
    [SerializeField] private float _vignetteIntensity = 0.5f;
    [SerializeField] private float _chromaticAberrationIntensity = 0.3f;
    [SerializeField] private float nullValue;

    private void Start()
    {
        GameController.instance.onSpiritVisionActivated += TurnOnSpiritVision;
        GameController.instance.onSpiritVisionDeactivated += TurnOfSpiritVision;
    }
    
    private void TurnOnSpiritVision()
    {
        screenFilterVolume.profile.TryGet(out ColorAdjustments _colorAdjustment);
        screenFilterVolume.profile.TryGet(out Vignette _vignette);
        screenFilterVolume.profile.TryGet(out ChromaticAberration _chromaticAberration);
            
        _colorAdjustment.colorFilter.value = filterColor;
        _vignette.intensity.value = _vignetteIntensity;
        _chromaticAberration.intensity.value = _chromaticAberrationIntensity;
        Debug.Log("Spirit Vision on");
        
    }
    private void TurnOfSpiritVision()
    {
        screenFilterVolume.profile.TryGet(out ColorAdjustments _colorAdjustment);
        screenFilterVolume.profile.TryGet(out Vignette _vignette);
        screenFilterVolume.profile.TryGet(out ChromaticAberration _chromaticAberration);
        _colorAdjustment.colorFilter.value = originalfilterColor;
        _vignette.intensity.value = nullValue;
        _chromaticAberration.intensity.value = nullValue;
        Debug.Log("Spirit Vision off");
    }

    
}
