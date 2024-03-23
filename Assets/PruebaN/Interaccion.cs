using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaccion : MonoBehaviour
{
    public Anclaje Objeto;

    

    public GameObject RecibirObjeto()
    {
        //print("llego a interaccion sujetar" + name);
        GameObject gameObject = Objeto.EstaSiendoSujetado();
        return gameObject;
    }

    public void desarmar()
    {
        //print("llego a interaccion Desarmar" + name);
        Objeto.DesarmarPieza();
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
