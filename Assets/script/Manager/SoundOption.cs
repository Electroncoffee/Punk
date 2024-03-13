using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundOption : MonoBehaviour
{
    //BGM 및 SFX 볼륨 조절


    public Slider bgmSlider;
    public Slider sfxSlider;

    void Start()
    {
        bgmSlider.value = SoundManger.instance.bgmVolume;
        sfxSlider.value = SoundManger.instance.bgmVolume;
    }

    public void UpdatebgmVolume()
    {
        SoundManger.instance.bgmPlayer.volume = bgmSlider.value;

    }
    public float ReturnsfxVolume()
    {
        return sfxSlider.value;
    }
}