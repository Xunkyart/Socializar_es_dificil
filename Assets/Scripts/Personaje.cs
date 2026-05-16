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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
    }

        public void getSliderComisuraIzq()
    {
        float valorComisuraIzq = SliderComisuraIzq.value;
    }

        public void getSliderComisuraDcha()
    {
        float valorComisuraDcha = SliderComisuraDcha.value;
    }
}
