using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagsPiezas : MonoBehaviour
{
    Renderer renderer;
    public string tagCodigo;
    [SerializeField] float velocidad ;

    public bool prueba = false;
    Transform prueba3;
    private void Start()
    {
        velocidad = 3f;
        tagCodigo = gameObject.name;
        renderer = GetComponentInChildren<Renderer>();
    }
    private void Update()
    {
        if (prueba && prueba3 != null)
        {
            MoverHaciaDestino();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MoveToCorrectPosition>().tagName == tagCodigo)
        {
            prueba = true;
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.GetComponent<MoveToCorrectPosition>().xd.enabled = false;
            prueba3 = other.transform;
            
            print(other.transform.position);
            print(transform.position);
            Invoke("MaterialOriginal", 3f);
            Destroy(other.gameObject, 3.2f);
        }
    }

    public void MoverHaciaDestino()
    {
        float distancia =09;
        if (prueba3.gameObject != null)
        {
            distancia = Vector3.Distance(prueba3.position, transform.position);
        }
        if (distancia > 0.2f)
        {
            prueba3.position = Vector3.Lerp(prueba3.position, transform.position, Time.deltaTime * velocidad);
            prueba3.rotation = Quaternion.Lerp(prueba3.rotation, transform.rotation, Time.deltaTime * velocidad);
        }
        else
        {
            prueba3.position = transform.position;
            prueba3.rotation = transform.rotation;
        }
        /*if (prueba3.localPosition.magnitude > 0.2f)
        {
            print(prueba3.localPosition.magnitude);
            prueba3.transform.localPosition = Vector3.Lerp(prueba3.transform.localPosition, transform.localPosition, Time.deltaTime * velocidad);
            prueba3.transform.localRotation = Quaternion.Lerp(prueba3.transform.localRotation, transform.localRotation, Time.deltaTime * velocidad);
        }
        else
        {
            prueba3.transform.position= transform.position;
            prueba3.transform.rotation = transform.rotation;
        }*/
    }
    public void MaterialOriginal()
    {
        /*Material mat = prueba3.GetChild(0).GetComponent<MeshRenderer>().material;
        MeshRenderer transformT = transform.GetChild(0).GetComponent<MeshRenderer>();
        transformT.material=  mat ;*/
    }
}
