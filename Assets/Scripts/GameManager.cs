using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Dialogo dialogo;

    public GameObject Interfaz_FinalBueno;
    public GameObject Interfaz_FinalNeutral;
    public GameObject Interfaz_FinalMalo;
    public GameObject Interfaz_Base;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Interfaz_FinalBueno.SetActive(false);
        Interfaz_FinalNeutral.SetActive(false);
        Interfaz_Base.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ActivarInterfazFinalBueno()
    {
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

        Interfaz_FinalNeutral.SetActive(false);
        Interfaz_FinalBueno.SetActive(false);
        Interfaz_Base.SetActive(false);
    }

    public void volverInicio()
    {
        SceneManager.LoadScene("PantallaInicio");
    }  
}
