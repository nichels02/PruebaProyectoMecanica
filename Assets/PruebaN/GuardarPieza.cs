using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardarPieza : MonoBehaviour
{
    [SerializeField] NombreDePieza ElNombre;
    [SerializeField] GameObject PosicionGuardar;
    Anclaje LaPieza;

    BoxCollider boxCollider;
    Vector3 size;
    Vector3 center;
    RaycastHit hit;
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        size = boxCollider.size;
        center = boxCollider.center;
        boxCollider.enabled = false;

    }
    private void Update()
    {
        // Comprobar si el BoxCast golpeó algo
        if (Physics.BoxCast(transform.position + center, size / 2, transform.forward, out hit))
        {
            Debug.Log("Golpeado: " + hit.collider.gameObject.name);
            Preguntar(hit.collider.gameObject);
        }
        else
        {
            Debug.Log("Nada golpeado.");
        }
    }


    void Preguntar(GameObject other)
    {
        print("entro");
        if (other.GetComponent<Interaccion>() && other.GetComponent<Interaccion>().Objeto.estaDesarmado && other.GetComponent<Interaccion>().Objeto.ElNombre == ElNombre)
        {
            print("entro");
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
