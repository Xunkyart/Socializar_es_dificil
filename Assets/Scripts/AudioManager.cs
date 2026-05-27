using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource FXSource;

    public static AudioManager instance;

    //public AudioClip
    public AudioClip Fondo;
    public AudioClip Slider;
    public AudioClip Button;
    public AudioClip Shutter;
    public AudioClip Exit;
    public AudioClip Drag;
     public AudioClip Win;
    public AudioClip Lose;  

     
     void Awake()
    {
        // 1. Check if an instance already exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 2. Keep this one alive
        }
        else
        {
            // 3. Duplicate found! Destroy the new one immediately.
            Destroy(gameObject);
        }
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        musicSource.clip = Fondo;
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
   