using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeFXManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider volumeSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetVolume(); 

    }

    // Update is called once per frame
    public void SetVolume()
    {
        float volume = volumeSlider.value;
        audioMixer.SetFloat("FX", volume);
       
    }

    void Update()
    {
        SetVolume();
    }
        
    }