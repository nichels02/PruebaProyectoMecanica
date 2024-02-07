using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovimientoPreciso : MonoBehaviour
{
    [SerializeField] string tagReferences;
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
        // Agrega el nuevo tag si no existe
        if (TagExists(tagReferences))
        {
            //Debug.Log("Si existe");
            this.gameObject.tag = tagReferences;
        }
        else
        {
            //Debug.Log("no existe");
        }
    }
    private void Update()
    {
        if (colisionDetectada == true)
        {
            MoverHaciaDestino();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.isKinematic = false;
        }
    }
    private bool TagExists(string tag)
    {
        // Obtén todos los tags en el proyecto
        string[] allTags = UnityEditorInternal.InternalEditorUtility.tags;

        // Verifica si el tag deseado está en la lista
        return System.Array.Exists(allTags, element => element == tag);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == this.gameObject.tag)
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
