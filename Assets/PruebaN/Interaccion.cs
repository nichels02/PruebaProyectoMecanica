using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaccion : MonoBehaviour
{
    [SerializeField] Anclaje Objeto;

    

    public GameObject RecibirObjeto()
    {
        print("llego a la interaccion");
        GameObject gameObject = Objeto.EstaSiendoSujetado();
        return gameObject;
    }

    public void color(bool entradaOSalida)
    {
        if (entradaOSalida)
        {
            Objeto.CambiarColor();
        }
        else
        {
            Objeto.RegresarColor();
        }
    }
}
