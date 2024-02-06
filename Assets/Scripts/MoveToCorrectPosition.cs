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
}



/*
private void Update()
{
    if (colisionDetectada== true)
    {
        MoverHaciaDestino();
    }
}
private void OnTriggerEnter(Collider other)
{
    if(other.GetComponent<TagsPiezas>().tagCodigo == tagName)
    {
        //if(other.transform.parent != null)
        //{
        //    transform.parent = null;
        //}
        //xd = other.transform;
        //this.transform.position = xd.transform.localPosition;
        //this.transform.parent = other.gameObject.transform;
        //colisionDetectada = true;
        //rb.isKinematic = true;
    }
}*/