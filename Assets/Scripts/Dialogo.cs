using UnityEngine;
using TMPro;
using System.Collections;
using Unity.VisualScripting;
using System.Collections.Generic;


public class Dialogo : MonoBehaviour
{
    TextMeshProUGUI objDialogo;
    public string frase = "";
    float velocidadEscribir = 0.05f;
    float tiempoEntreFrases = 2.0f;
    int bloqueIdentificador = 0;
    bool escribiendoBloque = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objDialogo = this.GetComponent<TextMeshProUGUI>();
        objDialogo.text = " ";
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(bloqueIdentificador);
     if (escribiendoBloque == false){

        //INTRO

        if (bloqueIdentificador == 0)
            {
            escribiendoBloque = true;
            frase = "¡Ei! ¿Eres tú? Madre mía, ¡cuánto tiempo sin verte! Desde el instituto, ¿verdad? No has cambiado nada, tienes exactamente la misma cara que cuando teníamos 15 años.";
            escribirEnPantalla();
            StartCoroutine (Esperar());
            IEnumerator Esperar()
            {
                int cantidadCaracteres = frase.Length;
                yield return new WaitForSeconds(tiempoEntreFrases+0.2f+velocidadEscribir*cantidadCaracteres);
                objDialogo.text = " ";
                frase = "¡Tenemos que ponernos al día! Llevas demasiado tiempo fuera de la ciudad, han pasado muchas cosas…";
                escribirEnPantalla();
                StartCoroutine (Esperar());
                IEnumerator Esperar()
                {
                 int cantidadCaracteres = frase.Length;
                 yield return new WaitForSeconds(tiempoEntreFrases+0.2f+velocidadEscribir*cantidadCaracteres);
                 objDialogo.text = " ";
                 escribiendoBloque = false;
            
                }
            }
        

        }







     
    }







    //ESCRIBIR EN PANTALLA  
    //Este método escribe la variable "frase" con un poco de delay por letra. Borra todo tras 3 seg.
    void escribirEnPantalla()
    {
        StartCoroutine (EscribirLento());
        IEnumerator EscribirLento(){
            
            foreach (char c in frase)
            {
                objDialogo.text += c;
                yield return new WaitForSeconds(velocidadEscribir);
            }
            yield return new WaitForSeconds(tiempoEntreFrases);
            //escribiendo = false;
        }
    }

    void esperarAcabarFrase()
    {
        StartCoroutine (Esperar());
        IEnumerator Esperar()
         {
         int cantidadCaracteres = frase.Length;
         yield return new WaitForSeconds(tiempoEntreFrases+0.2f+velocidadEscribir*cantidadCaracteres);
         }
    }
}}
