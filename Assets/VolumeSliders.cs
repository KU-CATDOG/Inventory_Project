using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSliders : MonoBehaviour
{
    public enum Type
    {
        BGMSlider,
        SFXSlider,
    }
    public Type SliderType;
    Slider sli;

    // Start is called before the first frame update
    void Start()
    {
        sli = GetComponent<Slider>();
        switch(SliderType)
        {
            case Type.BGMSlider:
                sli.value = SoundManager.masterVolumeBGM;
                break;
            case Type.SFXSlider:
                sli.value = SoundManager.masterVolumeSFX;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SFXSlider()
    {
        SoundManager.masterVolumeSFX = sli.value;
    }

    public void BGMSlider()
    {
        SoundManager.masterVolumeBGM = sli.value;
    }
}
