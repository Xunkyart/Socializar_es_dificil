using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class InicioScript : MonoBehaviour
{
    public GameObject panelInicio;
    public GameObject panelSetting;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        panelSetting.SetActive(false);
    }

    // Update is called once per frame
    void Update() { }

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

    public void exitGame()
    {
        Application.Quit();

    }

    public void Inicio()
    {
        SceneManager.LoadScene("juego");
    }

}
