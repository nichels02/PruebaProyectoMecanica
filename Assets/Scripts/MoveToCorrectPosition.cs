using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToCorrectPosition : MonoBehaviour
{
    [SerializeField] string tagCodigo;
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
            transform.parent = other.gameObject.transform;
            otherPosition = other.gameObject.transform;
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<TagsPiezas>().tagCodigo == this.tagCodigo)
        {
            colisionDetectada = false;
            rb.isKinematic = true;
            transform.parent = null;

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