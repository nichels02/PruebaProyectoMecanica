using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardarPieza : MonoBehaviour
{
    [SerializeField] NombreDePieza ElNombre;
    [SerializeField] GameObject PosicionGuardar;
    Anclaje LaPieza;

    /*
    private void Start()
    {
        if (LaPieza.GetComponent<Interaccion>().Objeto.EsteTieneOtroCollider)
        {
            LaPieza = LaPieza.GetComponent<Interaccion>().Objeto.gameObject;
        }
    }
    */
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Interaccion>() && other.GetComponent<Interaccion>().Objeto.estaDesarmado && other.GetComponent<Interaccion>().Objeto.ElNombre==ElNombre)   
        {
            LaPieza = other.GetComponent<Interaccion>().Objeto;
            posicionar();
            //LaPieza.transform.position = PosicionGuardar.transform.position;
            //LaPieza.tag = "YaSeGuardo";
        }
        else if (other.GetComponent<Anclaje>() && other.GetComponent<Anclaje>().estaDesarmado && other.GetComponent<Anclaje>().ElNombre == ElNombre)
        {
            LaPieza = other.GetComponent<Anclaje>();
            posicionar();
        }
    }




    void posicionar()
    {
        LaPieza.transform.position = PosicionGuardar.transform.position;
        LaPieza.transform.rotation = PosicionGuardar.transform.rotation;
        LaPieza.tag = "YaSeGuardo";
        this.enabled = false;
    }




}
