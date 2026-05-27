using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogo : MonoBehaviour
{
    public GameObject SlidersUI;
    TextMeshProUGUI objDialogo;
    public string frase = "";
    float velocidadEscribir = 0.035f;
    float tiempoEntreFrases = 2.0f;
    private List<int> bloquesDisponibles = new List<int>();
    int bloqueIdentificador = 0;
    bool escribiendoBloque = false;
    int minListaBloques = 1;
    int maxListaBloques = 6;
    public float exito = 0.5f;
    GameObject personajeJugador;
    string emocion;
    public int bloquesPartida = 5; //Incluye la introducción, no incluye el outro ni el fail.
    //public int[] listadoFrases;

     //Referencia al GameManager para activar las interfaces finales
    public GameManager gameManager;
    bool haPerdido = false;
    bool haTerminado = false;

    AudioManager audioManager;


     private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    void Start()
    {
        SlidersUI.SetActive(false);
        objDialogo = this.GetComponent<TextMeshProUGUI>();
        objDialogo.text = " ";
        personajeJugador = GameObject.FindWithTag("Player");

        //Rellenamos la lista de bloques. El mínimo se incluye, el máximo no. El 0 es la introducción, así que no se incluye.
        for (int i = minListaBloques; i < maxListaBloques; i++)
        {
            bloquesDisponibles.Add(i);
        }
    }

    void Update()
    {
        //para que el dialogo no haga cosas raras si se ha perdido o ha terminado el juego
        if (haPerdido || haTerminado) return;

        // Actualizar la emoción del personaje
        emocion = personajeJugador.GetComponent<Personaje>().emocion;
        if (escribiendoBloque == false && bloquesPartida > 0)
        {
            //INTRODUCCIÓN
            if (bloqueIdentificador == 0)
            {
                StartCoroutine(Intro());
            }
            //BLOQUE 1
            else if (bloqueIdentificador == 1)
            {
                StartCoroutine(Bloque1());
            }
            //BLOQUE 2
            else if (bloqueIdentificador == 2)
            {
                StartCoroutine(Bloque2());
            }
            //BLOQUE 3
            else if (bloqueIdentificador == 3)
            {
                StartCoroutine(Bloque3());
            }
            //BLOQUE 4
            else if (bloqueIdentificador == 4)
            {
                StartCoroutine(Bloque4());
            }
            //BLOQUE 5
            else if (bloqueIdentificador == 5)
            {
                StartCoroutine(Bloque5());
            }
        }

        ComprobarEstadoFinal();
    }
    // Parar las corrutinas y que salga la outro o el fail
    public void PararDialogo()
    {
        StopAllCoroutines();
        escribiendoBloque = false;
    }

    public void StartOutro()
    {
        StartCoroutine(Outro());
    }

    public void StartFail()
    {
        StartCoroutine(Fail());
    }

    void ComprobarEstadoFinal()
    {
        if (!haPerdido && exito < 0f)
        {
            haPerdido = true;
            PararDialogo();
            StartFail();
            return;
        }
        if (!haTerminado && bloquesDisponibles.Count == 1)
        {
            haTerminado = true;
            PararDialogo();
            StartOutro();

        }
    }

    IEnumerator MostrarSliders()
    {
        yield return new WaitForSeconds(20.0f);
        SlidersUI.SetActive(true);
    }
    IEnumerator Intro()
    {
        StartCoroutine(MostrarSliders());
        escribiendoBloque = true;
        yield return new WaitForSeconds(8.0f);
        frase =
            "¡Ei! ¿Eres tú? Madre mía, ¡cuánto tiempo sin verte! Desde el instituto, ¿verdad? No has cambiado nada, tienes exactamente la misma cara que cuando teníamos 15 años.";
        yield return StartCoroutine(EscribirLento());
        frase =
            "¡Tenemos que ponernos al día! Llevas demasiado tiempo fuera de la ciudad, han pasado muchas cosas…";
        yield return StartCoroutine(EscribirLento());
        laRuleta();
        escribiendoBloque = false;
    }

    IEnumerator Bloque1()
    {
        escribiendoBloque = true;
        frase =
            "Nuevo curro en la tienda ¿eh?. Tranquilo, no todos estamos hechos para el éxito ¿sabes a lo que me refiero?";
        yield return StartCoroutine(EscribirLento());
        frase =
            "Hay gente que tiene que suplir su falta de talento de alguna manera… no todos podemos ganarnos la vida haciendo cosas interesantes.";
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
        frase =
            "Un poco tarde si me preguntas, ya era hora de que alguien se diese cuenta de lo importante que soy para la empresa ¡estarían perdidos sin mí!";
        yield return StartCoroutine(EscribirLento());
        frase =
            "¿Que donde trabajo? En una firma de modelos claro, ¡el lugar indicado para una chica como yo!";
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
            frase =
                "¡No te apures! No todos estamos hechos de la misma pasta, no hay que avergonzarse de ser mediocre.";
            exito -= 0.2f;
        }
        else if (emocion == "sorprendido")
        {
            frase =
                "Es normal que te sorprenda, la gente suele quedarse sin palabras ante mi genialidad.";
            exito += 0.1f;
        }
        yield return StartCoroutine(EscribirLento());
        laRuleta();
        escribiendoBloque = false;
    }

    IEnumerator Bloque2()
    {
        escribiendoBloque = true;
        frase =
            "Últimamente estoy un poco deprimida, ya no es lo mismo sin ella… ¿No te has enterado? Hace un mes falleció mi tía abuela, pobre mujer ¡En la flor de la vida! Solo 94 años tenía…";
        yield return StartCoroutine(EscribirLento());
        frase =
            "Ay, siempre se van los mejores primero. De ella heredé mi tipo, ¡esta belleza es 100% natural claro! Tenía a todos los chicos del pueblo locos en su juventud... ";
        yield return StartCoroutine(EscribirLento());
        if (emocion == "neutral")
        {
            frase = "En serio? ¿Ni una lagrimilla? Ni que estuvieras hecho de piedra";
            exito -= 0.3f;
        }
        else if (emocion == "feliz")
        {
            frase = "A qué viene esa sonrisa? Madre mía, un poco de respeto por los muertos";
            exito -= 0.1f;
        }
        else if (emocion == "enfadado")
        {
            frase = "Así de injusta es la vida";
            exito -= 0.1f;
        }
        else if (emocion == "triste")
        {
            frase = " Sí, estas semanas han sido bastante duras…";
            exito += 0.3f;
        }
        else if (emocion == "sorprendido")
        {
            frase = "Si es que siempre se van cuando menos te lo esperas, estaba como una rosa…";
            exito += 0.2f;
        }
        yield return StartCoroutine(EscribirLento());
        frase =
            "Nos pilló a todos por sorpresa, la mujer estaba como un roble… Fue un accidente en un Safari, muy aventurera ella.";
        yield return StartCoroutine(EscribirLento());
        frase =
            "Al intentar hacerse una foto se cayó a la fosa de los cocodrilos ¡no dejaron ni los huesos! En el entierro tuvimos que mantener el ataúd cerrado claro…";
        yield return StartCoroutine(EscribirLento());
        if (emocion == "neutral")
        {
            frase = "Pero bueno, cambiemos de tema. Que veo que no te importa mucho";
            exito -= 0.0f;
        }
        else if (emocion == "feliz")
        {
            frase = "Cualquiera diría que estás del lado de los cocodrilos";
            exito -= 0.0f;
        }
        else if (emocion == "enfadado")
        {
            frase =
                "Debería haber más control en esos sitios! Yo voto por que se deshagan de los cocodrilos";
            exito += 0.0f;
        }
        else if (emocion == "triste")
        {
            frase = "Aún así una ceremonia muy bonita, deberías haberlo visto";
            exito += 0.0f;
        }
        else if (emocion == "sorprendido")
        {
            frase = "¿Qué? ¿Qué por ser mayor crees que no podía tener aventuras?";
            exito -= 0.0f;
        }
        yield return StartCoroutine(EscribirLento());
        laRuleta();
        escribiendoBloque = false;
    }

    IEnumerator Bloque3()
    {
        escribiendoBloque = true;
        frase =
            "Por cierto ¿te acuerdas de X, del instituto? No te vas a creer lo que ha pasado. Resulta que el otro día estaba en el bar con unos amigos y acabó recibiendo una paliza.";
        yield return StartCoroutine(EscribirLento());
        frase = "Se ve que le dieron bien, no lo han vuelto a ver por la calle todavía.";
        yield return StartCoroutine(EscribirLento());
        if (emocion == "neutral")
        {
            frase = "¿No te alegras ni un poco? Sigue siendo tan idiota como antes";
            exito -= 0.0f;
        }
        else if (emocion == "feliz")
        {
            frase = "Se lo tiene buscado, en el instituto ya era un idiota que solo buscaba peleas";
            exito += 0.0f;
        }
        else if (emocion == "enfadado")
        {
            frase = "En mi opinión le deberían haber dado aún más fuerte, se lo tiene ganado";
            exito -= 0.0f;
        }
        else if (emocion == "triste")
        {
            frase = "¿A qué viene esa cara? ¿No se burlaba de ti en el colegio?";
            exito -= 0.0f;
        }
        else if (emocion == "sorprendido")
        {
            frase = "No se como te sorprende, si lleva siendo toda la vida así";
            exito += 0.0f;
        }
        yield return StartCoroutine(EscribirLento());
        frase = "Aunque bueno, lo que tiene de tonto también lo tiene de guapo, menudo hombre… ";
        yield return StartCoroutine(EscribirLento());
        frase = "Hablando de hombres, ¡adivina a quién le pidieron matrimonio hace unos meses!";
        yield return StartCoroutine(EscribirLento());
        frase =
            "Mi novio intentó pedirme matrimonio hace unos años, pero lo hizo con un anillo de lo más básico, ¡Ni hablar! ";
        yield return StartCoroutine(EscribirLento());
        frase =
            "Una mujer como yo necesita un diamante tan brillante como ella, así que le hice volver a preguntarme cuando tuviese el valor de comprar uno.";
        yield return StartCoroutine(EscribirLento());
        if (emocion == "neutral")
        {
            frase = "Me entiendes ¿verdad? ¿Cómo pensaba que me rebajase a un nivel tan bajo?";
            exito += 0.0f;
        }
        else if (emocion == "feliz")
        {
            frase = "Sabía que me darías la razón, tu sí que sabes reconocer lo mucho que merezco";
            exito += 0.0f;
        }
        else if (emocion == "enfadado")
        {
            frase = "No hace falta que te pongas celoso, no eres para nada mi tipo";
            exito -= 0.0f;
        }
        else if (emocion == "triste")
        {
            frase = "¿Qué? ¿Triste por haber perdido tu oportunidad conmigo";
            exito -= 0.0f;
        }
        else if (emocion == "sorprendido")
        {
            frase = "No sé por qué te extraña tanto, soy una mujer que sabe lo que vale";
            exito -= 0.0f;
        }
        yield return StartCoroutine(EscribirLento());
        frase =
            "Recuerdas a mi prometido, verdad? Se que en el instituto se metía contigo, pero ahora es todo un amor ¡Ya ni siquiera insulta a minorías cuando nos los cruzamos por la calle!";
        yield return StartCoroutine(EscribirLento());
        frase =
            "aunque bueno, alguna vez se le escapa algún comentario. Pero todos tenemos defectos, no? Nadie es perfecto en esta vida";
        yield return StartCoroutine(EscribirLento());
        if (emocion == "neutral")
        {
            frase =
                "Bueeeeno puede que tenga más defectos que la mayoría, pero también tiene más dinero que la mayoría";
            exito -= 0.0f;
        }
        else if (emocion == "feliz")
        {
            frase = "¿Ves como ya no es el mismo que en el instituto?";
            exito += 0.0f;
        }
        else if (emocion == "enfadado")
        {
            frase =
                "No sabía que te habías vuelto tan activista, el tiempo fuera de la ciudad te ha cambiado…";
            exito -= 0.0f;
        }
        else if (emocion == "triste")
        {
            frase = "¿Todavía te molesta lo del instituto? ¡Pero si fue hace años!";
            exito -= 0.0f;
        }
        else if (emocion == "sorprendido")
        {
            frase = "No hay que ser moralistas, todos tenemos nuestras taras";
            exito -= 0.0f;
        }
        yield return StartCoroutine(EscribirLento());
        laRuleta();
        escribiendoBloque = false;
    }

    IEnumerator Bloque4()
    {
        escribiendoBloque = true;
        frase =
            "Madre mía, ¡cómo están los precios! He venido a por tres tonterías y me voy a gastar un pastizal.";
        yield return StartCoroutine(EscribirLento());
        frase = " Y pensar que hace unos años te hacías la compra de la semana con cuatro chavos…";
        yield return StartCoroutine(EscribirLento());
        if (emocion == "neutral")
        {
            frase = "No te molesta? Esto nos afecta a todos eh";
            exito -= 0.0f;
        }
        else if (emocion == "feliz")
        {
            frase = "Muy contento te veo para estar trabajando por debajo del sueldo mínimo";
            exito -= 0.0f;
        }
        else if (emocion == "enfadado")
        {
            frase = "Es indignante, cómo esperan que la gente viva así? ";
            exito += 0.0f;
        }
        else if (emocion == "triste")
        {
            frase = "Alegra esa cara, seguro que los bancos de comida aceptan a pobretones como tú";
            exito -= 0.0f;
        }
        else if (emocion == "sorprendido")
        {
            frase = "Es indignante, cómo esperan que la gente viva así?";
            exito += 0.0f;
        }
        yield return StartCoroutine(EscribirLento());
        frase =
            "Todo por culpa de ese partido! Esos comunistas están arruinando el país con sus locuras sobre la igualdad y nosequé derechos.";
        yield return StartCoroutine(EscribirLento());
        frase =
            "¿Por qué debería pagar yo más para que un pobre desgraciado tenga su paguita? ¡Que se hubiese esforzado tanto como yo!";
        yield return StartCoroutine(EscribirLento());
        if (emocion == "neutral")
        {
            frase =
                "No es que lo diga por tí, eh? Aunque visto lo visto tu tampoco te has esforzado mucho en la vida";
            exito -= 0.0f;
        }
        else if (emocion == "feliz")
        {
            frase =
                " ¡Por fin alguien reconoce mi trabajo duro! Me costó mucho conseguir que me enchufaran en la empresa";
            exito += 0.0f;
        }
        else if (emocion == "enfadado")
        {
            frase = "¿Qué? No sabía que tu también eras uno de esos rojos";
            exito -= 0.0f;
        }
        else if (emocion == "triste")
        {
            frase =
                "¿Te sientes ofendido? Menuda generación se està quedando, todos unos sensibles";
            exito -= 0.0f;
        }
        else if (emocion == "sorprendido")
        {
            frase = "¿No estás de acuerdo? No me digas que eres un alternativo de esos";
            exito -= 0.0f;
        }
        yield return StartCoroutine(EscribirLento());
        laRuleta();
        escribiendoBloque = false;
    }

    IEnumerator Bloque5()
    {
        escribiendoBloque = true;
        frase = "Cambiando de tema… ¿Te has enterado del jaleo que hay en el ayuntamiento? ";
        yield return StartCoroutine(EscribirLento());
        frase =
            " El equipo del fútbol quiere organizar un torneo la misma semana que la asociación de atletismo tiene una competición, se ve que ambos bandos dicen que fueron ellos quien lo dijeron primero…";
        yield return StartCoroutine(EscribirLento());
        frase =
            "Normalmente no me interesan los dramas del populacho,¡pero quien ignoraría tremendo culebrón!";
        yield return StartCoroutine(EscribirLento());
        if (emocion == "neutral")
        {
            frase =
                "No sabía que eras demasiado superior como para interesarte en los asuntos del pueblo";
            exito -= 0.0f;
        }
        else if (emocion == "feliz")
        {
            frase = "¡Al fin pasa algo interesante en este pueblucho!";
            exito += 0.0f;
        }
        else if (emocion == "enfadado")
        {
            frase = "No sabía que le dabas tanta importancia a los dramas tontos de pueblo";
            exito -= 0.0f;
        }
        else if (emocion == "triste")
        {
            frase = "Venga hombre, seguro que no es para tanto";
            exito -= 0.0f;
        }
        else if (emocion == "sorprendido")
        {
            frase = "Emocionante, verdad? Dicen que ha llegado a haber peleas físicas…";
            exito += 0.0f;
        }
        yield return StartCoroutine(EscribirLento());
        frase =
            "Bueno, esto seguro que te sorprende. Resulta que los presidentes de ambos clubes ¡Están casados! ";
        yield return StartCoroutine(EscribirLento());
        frase = "Menudo ambiente tiene que haber en esa casa… Són los padres de Y, ¿la recuerdas?";
        yield return StartCoroutine(EscribirLento());
        frase =
            "Voy con ella a pilates y dice que la cosa está desmadrándose, aunque mi teoría es que es todo una farsa para publicitar los eventos.";
        yield return StartCoroutine(EscribirLento());
        if (emocion == "neutral")
        {
            frase =
                "e estoy contando información altamente secreta, podrías al menos fingir un poco de emoción";
            exito -= 0.0f;
        }
        else if (emocion == "feliz")
        {
            frase = "Tu también lo crees, ¿verdad? Es una estrategia infalible";
            exito += 0.0f;
        }
        else if (emocion == "enfadado")
        {
            frase = "Venga, no hay nada de malo en especular un poco";
            exito -= 0.0f;
        }
        else if (emocion == "triste")
        {
            frase = "No me digas que te crees la historieta de Y…";
            exito -= 0.0f;
        }
        else if (emocion == "sorprendido")
        {
            frase = "¿No te fías de mí? Pues que sepas que mi intuición nunca falla";

            exito -= 0.0f;
        }
        yield return StartCoroutine(EscribirLento());
        laRuleta();
        escribiendoBloque = false;
    }

    IEnumerator Outro()
    {
        escribiendoBloque = true;
        if (exito >= 0.7f)
        {
            frase =
                "Bueno, ya paro que se me hace tarde. ¡Me alegro de volver a verte! Tienes que venir este sábado al bar, seguro que los demás tienen ganas de ponerse al día.";
        }
        else if (exito >= 0.4f)
        {
            frase =
                "Bueno, debería ir yéndome, no puedo decir que ha sido un placer volver a verte. Sigues igual de rarito que en el instituto, a ver si espabilas.";
        }
        else
        {
            frase =
                "Vaya, mira que hora es, mejor me voy ya. Ha estado bien ponernos al día… ya nos veremos por ahi, supongo";
        }
        yield return StartCoroutine(EscribirLento());
        StopAllCoroutines();
        escribiendoBloque = false;

        if (exito >= 0.7f)
        {
            gameManager.ActivarInterfazFinalBueno();
        }
        else if (exito >= 0.4f)
        {
            gameManager.ActivarInterfazFinalNeutral();
        }
    }

    IEnumerator Fail()
    {
        escribiendoBloque = true;
        if (exito <= -0.5f)
        {
            frase = "¡Menudo payaso! Es imposible hablar contigo. Hasta nunca.";
        }
        yield return StartCoroutine(EscribirLento());
        escribiendoBloque = false;

        if (exito <= -0.5f)
        {
            gameManager.ActivarInterfazFinalMalo();
        }
    }

    //ESCRIBE "FRASE" EN PANTALLA LETRA POR LETRA, ESPERA tiempoEntreFrases SEGUNDOS Y BORRA EL TEXTO.

    IEnumerator EscribirLento()
    {
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

        //Restamos uno de los bloques totales de la partida
        bloquesPartida--;
        
        if (bloquesPartida <= 0)
        {
            StartCoroutine(Outro());
        }
        else if (bloquesDisponibles.Contains(bloqueIdentificador))
        {
            //Asignamos el bloque elegido como bloque actual y lo borramos de la lista para que no se repita
            bloquesDisponibles.Remove(bloqueIdentificador);
        }
        //No debería poder pasar pero por seguridad
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
