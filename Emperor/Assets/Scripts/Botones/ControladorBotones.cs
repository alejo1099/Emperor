using UnityEngine;

public class ControladorBotones : MonoBehaviour
{
    public GameObject botonesMenuInicio;
    public GameObject elementosInstrucciones;


    public void ActivarInstrucciones()
    {
        botonesMenuInicio.SetActive(false);
        elementosInstrucciones.SetActive(true);
    }

    public void ActivarMenuPrincipal()
    {
        elementosInstrucciones.SetActive(false);
        botonesMenuInicio.SetActive(true);
    }
}