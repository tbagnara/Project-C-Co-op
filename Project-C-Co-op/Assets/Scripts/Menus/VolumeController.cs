
using UnityEngine;
using UnityEngine.UI;


public class VolumeController : MonoBehaviour
{
    public Slider MusicSlider;
    public Slider SfxSlider;

    void Start()    // Sets slider values to match the values already assigned
    {
        MusicSlider.value = AudioManager.Instance.MusicVolume;
        SfxSlider.value = AudioManager.Instance.SFXVolume;
    }

    public void OnSliderChange(string slider)   // Changes msuic value based on slider position
    {
        if (slider.Equals("Music"))
        {
            AudioManager.Instance.MusicVolume = MusicSlider.value;
        }
        else // The only other option is SFX so defaults to it
        {
            AudioManager.Instance.MusicVolume = SfxSlider.value;
        }
    }
}
