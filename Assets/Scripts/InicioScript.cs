using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class InicioScript : MonoBehaviour
{   

    public GameObject panelInicio;
    public GameObject panelSetting;
    public GameObject PanelCreditos;
    public GameObject PanelSelectNivel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        panelSetting.SetActive(false);
        PanelCreditos.SetActive(false);
        PanelSelectNivel.SetActive(false);
        
    }

    // Update is called once per frame
    void Update() { }

    // Ajustes
    public void showSettings()
    {
        panelSetting.SetActive(true);

        panelInicio.SetActive(false);

    }

    public void exitSettings()
    {
        panelSetting.SetActive(false);

        panelInicio.SetActive(true);

    }

    // Salir del juego

    public void exitGame()
    {
        Application.Quit();

    }

    // Creditos

    public void showCreditos()
    {
        PanelCreditos.SetActive(true);

        panelInicio.SetActive(false);

    }

    public void exitCreditos()
    {
        PanelCreditos.SetActive(false);

        panelInicio.SetActive(true);

    }

    // Selección de nivel

    public void showSelectNivel()
    {
        PanelSelectNivel.SetActive(true);

        panelInicio.SetActive(false);

    }

    public void exitSelectNivel()
    {
        PanelSelectNivel.SetActive(false);

        panelInicio.SetActive(true);

    }

    public void StartLvl1()
    {
        SceneManager.LoadScene("Cagarro");
    }  

}
