using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardarPieza : MonoBehaviour
{
    [SerializeField] GameObject LaPieza;
    [SerializeField] GameObject PosicionGuardar;

    private void Start()
    {
        if (LaPieza.GetComponent<Interaccion>().Objeto.EsteTieneOtroCollider)
        {
            LaPieza = LaPieza.GetComponent<Interaccion>().Objeto.gameObject;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other == LaPieza)
        {
            if((LaPieza.GetComponent<Interaccion>() && LaPieza.GetComponent<Interaccion>().Objeto.estaDesarmado) ||
                (LaPieza.GetComponent<Anclaje>() && LaPieza.GetComponent<Anclaje>().estaDesarmado))
            {
                LaPieza.transform.position = PosicionGuardar.transform.position;
                LaPieza.tag = "YaSeGuardo";
            }
        }
    }
}
