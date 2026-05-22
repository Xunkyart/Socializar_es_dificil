using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource FXSource;

    //public AudioClip
    public AudioClip Prueba;
    public AudioClip Slider;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        musicSource.clip = Prueba;
        musicSource.Play();
    }

    // Update is called once per frame
    public void PlaySFX(AudioClip clip)
    {
        FXSource.PlayOneShot(clip);
    }

    public void PlaySliderSFX()
    {
        FXSource.PlayOneShot(Slider);

    

    }

    
   
}
