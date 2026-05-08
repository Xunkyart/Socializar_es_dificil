using UnityEngine;
using TMPro;
using System.Collections;
using Unity.VisualScripting;


public class Dialogo : MonoBehaviour
{
    TextMeshProUGUI objDialogo;
    string frase = "Hola buenas tardes";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objDialogo = this.GetComponent<TextMeshProUGUI>();
        escribirEnPantalla();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void escribirEnPantalla()
    {
        StartCoroutine (EscribirLento());
        IEnumerator EscribirLento(){
            objDialogo.text = " ";
            foreach (char c in frase)
            {
                objDialogo.text += c;
                yield return new WaitForSeconds(0.2f);
            }
        }
    }
}
