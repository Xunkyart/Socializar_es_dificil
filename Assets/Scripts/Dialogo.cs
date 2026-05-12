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
    int minListaBloques = 1;
    int maxListaBloques = 8;
    
    void Start()
    {
        objDialogo = this.GetComponent<TextMeshProUGUI>();
        objDialogo.text = " ";

        //Rellenamos la lista de bloques. El mínimo se incluye, el máximo no. El 0 es la introducción, así que no se incluye. 
        for (int i = minListaBloques; i < maxListaBloques; i++)
        {
            bloquesDisponibles.Add(i);
        }
    }

    void Update()
    {
        Debug.Log(bloqueIdentificador);
     if (escribiendoBloque == false)
        {
            if (bloqueIdentificador == 0)
            {
                StartCoroutine(Intro());
            }
        }
    }
















    IEnumerator Intro()
    {
        escribiendoBloque = true;
        frase = "¡Ei! ¿Eres tú? Madre mía, ¡cuánto tiempo sin verte! Desde el instituto, ¿verdad? No has cambiado nada, tienes exactamente la misma cara que cuando teníamos 15 años.";
        yield return StartCoroutine (EscribirLento());
        frase = "¡Tenemos que ponernos al día! Llevas demasiado tiempo fuera de la ciudad, han pasado muchas cosas…";
        yield return StartCoroutine (EscribirLento());
        laRuleta();
        escribiendoBloque = false;
    }




















    //ESCRIBE "FRASE" EN PANTALLA LETRA POR LETRA, ESPERA tiempoEntreFrases SEGUNDOS Y BORRA EL TEXTO.

    IEnumerator EscribirLento(){
    
    foreach (char c in frase)
    {
        objDialogo.text += c;
        yield return new WaitForSeconds(velocidadEscribir);
    }
    yield return new WaitForSeconds(tiempoEntreFrases);
    objDialogo.text = " ";
    }

    

    
    //ELIGE UN BLOQUE DE DIALOGO AL AZAR QUE NO HAYA SALIDO ANTES
    //Tenemos una lista de bloques. Elige uno de los disponibles y lo borra de la lista para que no se repita.

    void laRuleta()
    {
        //Por seguridad. No debería poder pasar, pero si la lista está vacía, se rellena para evitar un error.
        if (bloquesDisponibles.Count == 0)
        {
            for (int i = minListaBloques; i < maxListaBloques; i++)
            {
                bloquesDisponibles.Add(i);
            }
        }


        //Elige un bloque al azar de la lista, lo asigna como bloque elegido y lo borra de la lista. 
        bloqueIdentificador = Random.Range(minListaBloques, maxListaBloques);
        if (bloquesDisponibles.Contains(bloqueIdentificador))
        {
            bloquesDisponibles.Remove(bloqueIdentificador);
        }
        else
        {
            laRuleta();
        }

    }


    

}
