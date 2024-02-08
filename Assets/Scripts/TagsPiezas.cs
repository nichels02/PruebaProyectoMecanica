using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagsPiezas : MonoBehaviour
{
    Renderer renderer;
    public string tagCodigo;
    [SerializeField] float velocidad = 5f;

    public bool prueba = false;
    Transform prueba3;
    private void Start()
    {
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
            Invoke("MaterialOriginal", 3f);
            Destroy(other.gameObject, 3.2f);
            
        }
    }

    public void MoverHaciaDestino()
    {
        if (transform.localPosition.magnitude > 0.1f)
        {
            prueba3.transform.position = Vector3.Lerp(prueba3.transform.position, transform.position, Time.deltaTime * velocidad);
            prueba3.transform.rotation = Quaternion.Lerp(prueba3.transform.rotation, transform.rotation, Time.deltaTime * velocidad);
        }
        else
        {
            prueba3.transform.localPosition = transform.position;
            prueba3.transform.localRotation = transform.rotation;
        }
    }
    public void MaterialOriginal()
    {
        Material mat = prueba3.GetChild(0).GetComponent<MeshRenderer>().material;
        MeshRenderer transformT = transform.GetChild(0).GetComponent<MeshRenderer>();
        transformT.material=  mat ;
    }
}
