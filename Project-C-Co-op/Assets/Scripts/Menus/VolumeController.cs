
using UnityEngine;
using UnityEngine.UI;


public class VolumeController : MonoBehaviour
{
    public Slider MusicSlider;
    public Slider SfxSlider;

    void Start()
    {
        MusicSlider.value = AudioManager.Instance.MusicVolume;
        SfxSlider.value = AudioManager.Instance.SFXVolume;
    }

    public void OnSliderChange(string slider)
    {
        if (slider.Equals("Music"))
        {
            AudioManager.Instance.MusicVolume = MusicSlider.value;
        }
        else
        {
            AudioManager.Instance.MusicVolume = SfxSlider.value;
        }
    }
}
