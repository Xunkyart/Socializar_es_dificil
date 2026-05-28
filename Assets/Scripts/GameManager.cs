using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Dialogo dialogo;

    public GameObject Interfaz_FinalBueno;
    public GameObject Interfaz_FinalNeutral;
    public GameObject Interfaz_FinalMalo;
    public GameObject Interfaz_Base;

    FXManager audioManager;



   



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Interfaz_FinalBueno.SetActive(false);
        Interfaz_FinalNeutral.SetActive(false);
        Interfaz_FinalMalo.SetActive(false);
        Interfaz_Base.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<FXManager>();
    }

    
    public void ActivarInterfazFinalBueno()
    {  
        audioManager.PlaySFX(audioManager.win);
        Interfaz_FinalBueno.SetActive(true);
      
        Interfaz_FinalNeutral.SetActive(false);
        Interfaz_Base.SetActive(false);
        Interfaz_FinalMalo.SetActive(false);
    }

    public void ActivarInterfazFinalNeutral()
    {
        Interfaz_FinalNeutral.SetActive(true);
        
        Interfaz_FinalBueno.SetActive(false);
        Interfaz_Base.SetActive(false);
        Interfaz_FinalMalo.SetActive(false);
    }

    public void ActivarInterfazFinalMalo()
    {
        Interfaz_FinalMalo.SetActive(true);
        audioManager.PlaySFX(audioManager.lose);

        Interfaz_FinalNeutral.SetActive(false);
        Interfaz_FinalBueno.SetActive(false);
        Interfaz_Base.SetActive(false);
    }

    public void volverInicio()
    {
        SceneManager.LoadScene("PantallaInicio");
    }
}