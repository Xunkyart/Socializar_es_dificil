using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class Personaje : MonoBehaviour
{
    //  PICKERS
    public GameObject cejaIZq;
    public GameObject ceraDcha;
    public GameObject labioInf;
    public GameObject dientesInf;
    public GameObject comisuraIzq;
    public GameObject comisuraDcha;


    //SLIDERS
    public Slider sliderCejaIzq;
    public Slider SliderCeraDcha;
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
        //posInicialCejaIzq = cejaIZq.transform.position;
        //posInicialCejaDcha = ceraDcha.transform.position;
        posInicialLabioInf = labioInf.transform.position;
        posInicialDientesInf = dientesInf.transform.position;
        posInicialComisuraIzq = comisuraIzq.transform.position;
        posInicialComisuraDcha = comisuraDcha.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }















    //Sacar el valor del slider
    public void getSliderCejaIzq()
    {
        float valorCejaIzq = sliderCejaIzq.value;
    }

        public void getSliderCejaDcha()
    {
        float valorCejaDcha = SliderCeraDcha.value;
    }

        public void getSliderAperturaBoca()
    {
        float valorAperturaBoca = SliderAperturaBoca.value;
        labioInf.transform.position = new UnityEngine.Vector3(posInicialLabioInf.x, posInicialLabioInf.y + valorAperturaBoca*0.02f, posInicialLabioInf.z);
        dientesInf.transform.position = new UnityEngine.Vector3(posInicialDientesInf.x, posInicialDientesInf.y + valorAperturaBoca*0.02f, posInicialDientesInf.z);
    }

        public void getSliderComisuraIzq()
    {
        float valorComisuraIzq = SliderComisuraIzq.value;
        comisuraIzq.transform.position = new UnityEngine.Vector3(posInicialComisuraIzq.x, posInicialComisuraIzq.y + valorComisuraIzq*0.012f, posInicialComisuraIzq.z);
    }

        public void getSliderComisuraDcha()
    {
        float valorComisuraDcha = SliderComisuraDcha.value;
        comisuraDcha.transform.position = new UnityEngine.Vector3(posInicialComisuraDcha.x, posInicialComisuraDcha.y + valorComisuraDcha*0.012f, posInicialComisuraDcha.z);
    }
}
