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
    private List<int> bloquesDisponibles = new List<int>();
    int bloqueIdentificador = 0;
    bool escribiendoBloque = false;
    int bloqueElegido = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objDialogo = this.GetComponent<TextMeshProUGUI>();
        objDialogo.text = " ";

        //Rellenamos la lista de bloques. el mínimo se incluye, el máximo no. El 0 es la introducción, así que no se incluye. 
        for (int i = 1; i < 8; i++)
        {
            bloquesDisponibles.Add(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
     if (escribiendoBloque == false){
    
        //INTRO bloqueIdentificador 0

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
                 laRuleta();
                 bloqueIdentificador = bloqueElegido;
                }
            }
        }
    }







    //ESCRIBIR EN PANTALLA  
    //Este método escribe la variable "frase" con un poco de delay por letra. Borra todo tras tiempoEntreFrases segundos.

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


    //ELIGE UN BLOQUE DE DIALOGO AL AZAR QUE NO HAYA SALIDO ANTES
    //Tenemos una lista de bloques. Elige uno de los disponibles y lo borra de la lista para que no se repita.
    
    void laRuleta()
    {
        bloqueElegido = Random.Range(1, 10);
        if (bloquesDisponibles.Contains(bloqueElegido))
        {
            bloqueIdentificador = bloqueElegido;
            bloquesDisponibles.Remove(bloqueElegido);
        }
        else
        {
            laRuleta();
        }
    }
















        //POZO DE LAS COSAS SIN ACABAR O QUE NO HAN FUNCIONADO  

    /*void esperarAcabarFrase()
    {
        StartCoroutine (Esperar());
        IEnumerator Esperar()
         {
         int cantidadCaracteres = frase.Length;
         yield return new WaitForSeconds(tiempoEntreFrases+0.2f+velocidadEscribir*cantidadCaracteres);
         }
    }*/

    

}}
