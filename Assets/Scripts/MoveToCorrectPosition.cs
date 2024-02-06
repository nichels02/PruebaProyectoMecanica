using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MoveToCorrectPosition : MonoBehaviour
{
    public XRGrabInteractable xd;
    public string tagName;
    Rigidbody rb;

    private void Awake()
    {
        tagName = gameObject.name;
        rb = GetComponent<Rigidbody>();
        xd = GetComponent<XRGrabInteractable>();
    }
    private void Update()
    {
        if (transform.parent == null)
        {
            GameManager2.Instance.BusquedaReferenciaObjeto(this.gameObject);
        }
        else
        {
           GameManager2.Instance.VolverAColor(this.gameObject);
        }
    }
}

