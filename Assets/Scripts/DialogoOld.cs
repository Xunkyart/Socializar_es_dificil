using UnityEngine;
using TMPro;
using System.Collections;
using Unity.VisualScripting;
using System.Collections.Generic;


public class DialogoOld : MonoBehaviour
{
    TextMeshProUGUI objDialogo;
    public string frase = "";
    float velocidadEscribir = 0.05f;
    float tiempoEntreFrases = 2.0f;
    private List<int> bloquesDisponibles = new List<int>();
    int bloqueIdentificador = 0;
    bool escribiendoBloque = false;
    int minListaBloques = 1;
    int maxListaBloques = 2;
    public string emocion = "neutral";
    public float exito = 0.5f;

    //public int[] listadoFrases;
    
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
            //INTRODUCCIÓN
            if (bloqueIdentificador == 0)
            {
                StartCoroutine(Intro());
            }
            //BLOQUE 1
            else if  (bloqueIdentificador == 1)
            {
                StartCoroutine(Bloque1());
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

    IEnumerator Bloque1()
    {
        escribiendoBloque = true;
        frase = "Nuevo curro en la tienda ¿eh?. Tranquilo, no todos estamos hechos para el éxito ¿sabes a lo que me refiero?";
        yield return StartCoroutine(EscribirLento());
        frase = "Hay gente que tiene que suplir su falta de talento de alguna manera… no todos podemos ganarnos la vida haciendo cosas interesantes.";
        yield return StartCoroutine(EscribirLento());
        if (emocion == "neutral")
        {
            frase = "Al final es como funciona el mundo, nos guste o no.";
            exito += 0.1f;
        }
        else if (emocion == "feliz")
        {
           frase = "Sabía que lo entenderías, no todo el mundo está hecho para triunfar.";
           exito += 0.3f;
        }
        else if (emocion == "enfadado")
        {
            frase = "No pretendía ofender, eh? Que sensible te has vuelto…";
            exito -= 0.3f;
        }
        else if (emocion == "triste")
        {
           frase = "Pero hombre, ¡no te pongas triste! Este curro es temporal, ¿verdad?";
           exito -= 0.1f;
        }
        else if (emocion == "sorprendido")
        {
            frase = "¿Ah? ¿No estás de acuerdo? Pues así es como funciona el mundo";
            exito -= 0.1f;
        }
        yield return StartCoroutine(EscribirLento());
        frase = "Pero bueno, hablando de trabajo… ¡Adivina quién acaba de conseguir un ascenso!";
        yield return StartCoroutine(EscribirLento());
        frase = "Un poco tarde si me preguntas, ya era hora de que alguien se diese cuenta de lo importante que soy para la empresa ¡estarían perdidos sin mí!";
        yield return StartCoroutine(EscribirLento());
        frase = "¿Que donde trabajo? En una firma de modelos claro, ¡el lugar indicado para una chica como yo!";
        yield return StartCoroutine(EscribirLento());
        if (emocion == "neutral")
        {
            frase = "Podrías alegrarte un poco más, tu falta de éxito en la vida no es culpa mía.";
            exito -= 0.2f;
        }
        else if (emocion == "feliz")
        {
           frase = "La vida acaba poniendo a cada uno en su lugar, y el mío está bastante guay.";
           exito += 0.2f;
        }
        else if (emocion == "enfadado")
        {
            frase = "¿Qué? ¿Envidioso de mi increíble vida?";
            exito -= 0.1f;
        }
        else if (emocion == "triste")
        {
           frase = "¡No te apures! No todos estamos hechos de la misma pasta, no hay que avergonzarse de ser mediocre.";
           exito -= 0.2f;
        }
        else if (emocion == "sorprendido")
        {
            frase = "Es normal que te sorprenda, la gente suele quedarse sin palabras ante mi genialidad.";
            exito += 0.1f;
        }
        yield return StartCoroutine(EscribirLento());
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
/*
        if (emocion == "neutral")
        {
            frase = "";
            exito += 0.0f;
        }
        else if (emocion == "feliz")
        {
           frase = "";
           exito += 0.0f;
        }
        else if (emocion == "enfadado")
        {
            frase = "";
            exito += 0.0f;
        }
        else if (emocion == "triste")
        {
           frase = "";
           exito += 0.0f;
        }
        else if (emocion == "sorprendido")
        {
            frase = "";
            exito += 0.0f;
        }





        yield return StartCoroutine(EscribirLento());
        */
