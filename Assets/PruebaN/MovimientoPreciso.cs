using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovimientoPreciso : MonoBehaviour
{
    Rotacion LaRotacion;
    int velocidad = 100;
    [SerializeField] Vector3 ElVectorRotacion;
    Vector3 ElVectorRotacionComprobacion;
    [SerializeField] bool debeRotar;

    private void Start()
    {
        LaRotacion = GetComponent<Rotacion>();
    }

    private void Update()
    {
        transform.rotation = LaRotacion.calcularRotacion(ElVectorRotacion);
        if (debeRotar)
        {
            rotar();
        }
    }


    void rotar()
    {
        print(ElVectorRotacion);
        Vector3 elVector = ElVectorRotacion * Time.deltaTime * velocidad;
        ElVectorRotacionComprobacion += elVector;
        transform.rotation = LaRotacion.calcularRotacion(elVector);
        if (ElVectorRotacion.x < 0 && ElVectorRotacion.y<0 && ElVectorRotacion.z < 0)
        {
            debeRotar = false;
        }
    }


}
