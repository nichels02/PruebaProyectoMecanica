using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MoveToCorrectPosition : MonoBehaviour
{
    public string tagName;
    [SerializeField] Transform manoDerecha;
    [SerializeField] Transform manoIzquierda;

    private void Awake()
    {
        tagName = gameObject.name;
    }
    private void Update()
    {
        if (transform.parent == manoDerecha || transform.parent == manoIzquierda)
        {
            GameManager2.Instance.BusquedaReferenciaObjeto(this.gameObject);
        }
        else
        {
           GameManager2.Instance.VolverAColor(this.gameObject);
        }
    }
}

