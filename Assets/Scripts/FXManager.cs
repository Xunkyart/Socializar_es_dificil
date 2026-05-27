using UnityEngine;

public class FXManager : MonoBehaviour
{
    [SerializeField] AudioSource FXSource; public AudioClip Slider;
    public AudioClip Button;
    public AudioClip Shutter;
    public AudioClip Exit;
    public AudioClip Drag;
    public AudioClip Win;
    public AudioClip Loss;  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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

    public void PlayButtonSFX()
    {
        FXSource.PlayOneShot(Button);

    }
   
    public void PlayShutterSFX()
    {
        FXSource.PlayOneShot(Shutter);

    }

   public void PlayExitSFX()
    {
        FXSource.PlayOneShot(Exit);

    }

    public void PlayDragSFX()
    {
        FXSource.PlayOneShot(Drag);
    }
}
