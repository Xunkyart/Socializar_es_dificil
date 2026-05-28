using UnityEngine;

public class FXManager : MonoBehaviour
{
    [SerializeField] AudioSource FXSource;


    public AudioClip slider;

    public AudioClip button;

    public AudioClip shutter;

    public AudioClip exit;

    public AudioClip drag;

    public AudioClip win;

    public AudioClip lose;  


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
        FXSource.PlayOneShot(slider);

    }

    public void PlayButtonSFX()
    {
        FXSource.PlayOneShot(button);

    }
   
    public void PlayShutterSFX()
    {
        FXSource.PlayOneShot(shutter);

    }

   public void PlayExitSFX()
    {
        FXSource.PlayOneShot(exit);

    }

    public void PlayDragSFX()
    {
        FXSource.PlayOneShot(drag);
    }

    public void PlayWinSFX()
    {
        FXSource.PlayOneShot(win);
    }

    public void PlayLoseSFX()
    {
        FXSource.PlayOneShot(lose);
    }

}


