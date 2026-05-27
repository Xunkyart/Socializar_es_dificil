using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;

    public AudioClip Fondo;

    private static MusicManager instance;



    void Awake()
    {
        // If an instance already exists, destroy the new duplicate
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            // Prevent this object from being destroyed when loading new scenes
            DontDestroyOnLoad(gameObject);
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
      void Start()
    {
        musicSource.clip = Fondo;
        musicSource.Play();

    }

}
