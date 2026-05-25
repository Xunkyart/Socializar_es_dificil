using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void volverInicio()
    {
        SceneManager.LoadScene("PantallaInicio");
    }  
}
/*cuando llegue a casa: 
Mirar como conectar al resto del juego

Duplicar script de dialogo para hacer pruebas con lo que hice ayer y con lo de ahora
*/
