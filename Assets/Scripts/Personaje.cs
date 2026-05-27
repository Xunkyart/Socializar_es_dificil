using UnityEngine;
using UnityEngine.UI;

public class Personaje : MonoBehaviour
{
    //EMOCIÓN DEL PERSONAJE
    public string emocion = "neutra";

    //ESTADOS ABSOLUTOS DE LOS RASGOS FACIALES
    string alturaCejaIzq = "media";
    string alturaCejaDcha = "media";
    string aperturaBoca = "cerrada";
    string alturaComisuraIzq = "media";
    string alturaComisuraDcha = "media";

    //  PICKERS
    public GameObject cejaIzq;
    public GameObject cejaDcha;
    public GameObject labioInf;
    public GameObject dientesInf;
    public GameObject comisuraIzq;
    public GameObject comisuraDcha;

    //SLIDERS
    public Slider sliderCejaIzq;
    public Slider SliderCejaDcha;
    public Slider SliderAperturaBoca;
    public Slider SliderComisuraIzq;
    public Slider SliderComisuraDcha;

    //POSICIÓN QUE MODIFICARÁN LOS SLIDERS
    UnityEngine.Vector3 posCejaIzq;
    UnityEngine.Vector3 posCejaDcha;
    UnityEngine.Vector3 posLabioInf;
    UnityEngine.Vector3 posDientesInf;
    UnityEngine.Vector3 posComisuraIzq;
    UnityEngine.Vector3 posComisuraDcha;

    //POSICIONES INICIALES Y DE REFERENCIA PARA LAS MODIFICACIONES
    UnityEngine.Vector3 posInicialCejaIzq;
    UnityEngine.Vector3 posInicialCejaDcha;
    UnityEngine.Vector3 posInicialLabioInf;
    UnityEngine.Vector3 posInicialDientesInf;
    UnityEngine.Vector3 posInicialComisuraIzq;
    UnityEngine.Vector3 posInicialComisuraDcha;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posInicialCejaIzq = cejaIzq.transform.position;
        posInicialCejaDcha = cejaDcha.transform.position;
        posInicialLabioInf = labioInf.transform.position;
        posInicialDientesInf = dientesInf.transform.position;
        posInicialComisuraIzq = comisuraIzq.transform.position;
        posInicialComisuraDcha = comisuraDcha.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(emocion);
        if (
            (alturaCejaIzq == "alta" || alturaCejaIzq == "media")
            && (alturaCejaDcha == "alta" || alturaCejaDcha == "media")
            && alturaComisuraIzq == "alta"
            && alturaComisuraDcha == "alta"
            && aperturaBoca == "cerrada"
        )
        {
            emocion = "feliz";
        }
        else if (
            (alturaCejaIzq == "alta" || alturaCejaIzq == "media")
            && (alturaCejaDcha == "alta" || alturaCejaDcha == "media")
            && alturaComisuraIzq == "baja"
            && alturaComisuraDcha == "baja"
            && aperturaBoca == "cerrada"
        )
        {
            emocion = "triste";
        }
        else if (
            alturaCejaIzq == "baja"
            && alturaCejaDcha == "baja"
            && (alturaComisuraIzq == "baja" || alturaComisuraIzq == "media")
            && (alturaComisuraDcha == "baja" || alturaComisuraDcha == "media")
        )
        {
            emocion = "enfadado";
        }
        else if (
            alturaCejaIzq == "alta"
            && alturaCejaDcha == "alta"
            && (alturaComisuraIzq == "alta" || alturaComisuraIzq == "media")
            && (alturaComisuraDcha == "alta" || alturaComisuraDcha == "media")
            && aperturaBoca == "abierta"
        )
        {
            emocion = "sorprendido";
        }
        else
        {
            emocion = "neutral";
        }
    }

    //Sacar el valor del slider
    public void getSliderCejaIzq()
    {
        float valorCejaIzq = sliderCejaIzq.value;
        cejaIzq.transform.position = new UnityEngine.Vector3(
            posInicialCejaIzq.x,
            posInicialCejaIzq.y + valorCejaIzq * 0.012f,
            posInicialCejaIzq.z
        );
        if (valorCejaIzq > 0.44f)
        {
            alturaCejaIzq = "alta";
        }
        else if (valorCejaIzq < -0.05f)
        {
            alturaCejaIzq = "baja";
        }
        else
        {
            alturaCejaIzq = "media";
        }
    }

    public void getSliderCejaDcha()
    {
        float valorCejaDcha = SliderCejaDcha.value;
        cejaDcha.transform.position = new UnityEngine.Vector3(
            posInicialCejaDcha.x,
            posInicialCejaDcha.y + valorCejaDcha * 0.012f,
            posInicialCejaDcha.z
        );
        if (valorCejaDcha > 0.44f)
        {
            alturaCejaDcha = "alta";
        }
        else if (valorCejaDcha < -0.05f)
        {
            alturaCejaDcha = "baja";
        }
        else
        {
            alturaCejaDcha = "media";
        }
    }

    public void getSliderAperturaBoca()
    {
        float valorAperturaBoca = SliderAperturaBoca.value;
        labioInf.transform.position = new UnityEngine.Vector3(
            posInicialLabioInf.x,
            posInicialLabioInf.y + valorAperturaBoca * 0.02f,
            posInicialLabioInf.z
        );
        dientesInf.transform.position = new UnityEngine.Vector3(
            posInicialDientesInf.x,
            posInicialDientesInf.y + valorAperturaBoca * 0.02f,
            posInicialDientesInf.z
        );
        if (valorAperturaBoca > -0.3f)
        {
            aperturaBoca = "cerrada";
        }
        else
        {
            aperturaBoca = "abierta";
        }
    }

    public void getSliderComisuraIzq()
    {
        float valorComisuraIzq = SliderComisuraIzq.value;
        comisuraIzq.transform.position = new UnityEngine.Vector3(
            posInicialComisuraIzq.x,
            posInicialComisuraIzq.y + valorComisuraIzq * 0.012f,
            posInicialComisuraIzq.z
        );

        if (valorComisuraIzq > 0.55f)
        {
            alturaComisuraIzq = "alta";
        }
        else if (valorComisuraIzq < -0.2f)
        {
            alturaComisuraIzq = "baja";
        }
        else
        {
            alturaComisuraIzq = "media";
        }
    }

    public void getSliderComisuraDcha()
    {
        float valorComisuraDcha = SliderComisuraDcha.value;
        comisuraDcha.transform.position = new UnityEngine.Vector3(
            posInicialComisuraDcha.x,
            posInicialComisuraDcha.y + valorComisuraDcha * 0.012f,
            posInicialComisuraDcha.z
        );
        if (valorComisuraDcha > 0.55f)
        {
            alturaComisuraDcha = "alta";
        }
        else if (valorComisuraDcha < -0.2f)
        {
            alturaComisuraDcha = "baja";
        }
        else
        {
            alturaComisuraDcha = "media";
        }
    }
}
