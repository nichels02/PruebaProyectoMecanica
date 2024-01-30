using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//public enum Piezas { pieza1, pieza2, pieza3, pieza4, pieza5, pieza6, pieza7 }
public class MoveToCorrectPosition : MonoBehaviour
{
    [SerializeField] string tagCodigo;
    //public Piezas typePieza;
    public bool colisionDetectada = false;
    Rigidbody rb;
    Transform otherPosition;
    [SerializeField] float velocidad = 5f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
    }
    private void Update()
    {
        if (colisionDetectada== true)
        {
            MoverHaciaDestino();
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.isKinematic = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<TagsPiezas>().tagCodigo == this.tagCodigo)
        {
            colisionDetectada = true;
            rb.isKinematic = true;
            otherPosition = other.gameObject.transform;
            transform.parent = other.gameObject.transform;
        }
    }
    void MoverHaciaDestino()
    {
        if (transform.localPosition.magnitude > 0.1f)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, Vector3.zero, Time.deltaTime * velocidad);
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.identity, Time.deltaTime * velocidad);
        }

        else
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            colisionDetectada = false;
        }
    }
}