using UnityEngine;
using TMPro;
using System.Collections;
using Unity.VisualScripting;


public class Dialogo : MonoBehaviour
{
    TextMeshProUGUI objDialogo;
    public string frase = "Hola buenas tardes";
    bool escribiendo = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objDialogo = this.GetComponent<TextMeshProUGUI>();
        objDialogo.text = " ";
    }

    // Update is called once per frame
    void Update()
    {
        if (escribiendo == false)
        {
            escribirEnPantalla();
        }
    }

    //ESCRIBIR EN PANTALLA  
    //Este método escribe la variable "frase" con un poco de delay por letra. Borra todo tras 3 seg.
    public void escribirEnPantalla()
    {
        escribiendo = true;
        StartCoroutine (EscribirLento());
        IEnumerator EscribirLento(){
            foreach (char c in frase)
            {
                objDialogo.text += c;
                yield return new WaitForSeconds(0.2f);
            }
            yield return new WaitForSeconds(3.0f);
            objDialogo.text = " ";
            escribiendo = false;
        }
    }
}
