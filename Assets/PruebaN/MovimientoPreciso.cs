using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovimientoPreciso : MonoBehaviour
{
    [SerializeField] Rotacion LaRotacion;
    [SerializeField] int velocidad = 100;
    [SerializeField] Vector3 ElVectorRotacion;
    [SerializeField] int vueltas;
    Vector3 ElVectorRotacionComprobacion = new Vector3(1, 1, 1);
    Vector3 ElVectorFinal;
    [SerializeField] bool debeRotar;
    bool debeRotar2;


    private void Start()
    {
        ElVectorRotacionComprobacion.x = ElVectorRotacion.x != 0 ? ElVectorRotacionComprobacion.x = 360 / ElVectorRotacion.x * vueltas * ElVectorRotacion.x : 0;
        ElVectorRotacionComprobacion.y = ElVectorRotacion.y != 0 ? ElVectorRotacionComprobacion.y = 360 / ElVectorRotacion.y * vueltas * ElVectorRotacion.y : 0;
        ElVectorRotacionComprobacion.z = ElVectorRotacion.z != 0 ? ElVectorRotacionComprobacion.z = 360 / ElVectorRotacion.z * vueltas * ElVectorRotacion.z : 0;
        ElVectorFinal = ElVectorRotacionComprobacion;
        debeRotar = true;
        
    }
    private void Update()
    {
        //print("1");
        //ElVectorRotacion= 5,0,0



        if (debeRotar == true)
        {
            debeRotar2 = true;
            //ElVectorRotacionComprobacion = ElVectorRotacion * 10000;
            debeRotar = false;
        }
        else if (debeRotar2 == true && ElVectorRotacionComprobacion.x > 0 || ElVectorRotacionComprobacion.y > 0 || ElVectorRotacionComprobacion.z > 0)
        {
            print(ElVectorRotacionComprobacion);
            rotar();
        }
        
    }

    void rotar()
    {
        Vector3 elVector = ElVectorRotacion * Time.deltaTime * velocidad;
        ElVectorRotacionComprobacion -= elVector;
        Quaternion currentRotation = transform.rotation;
        Quaternion deltaRotation = LaRotacion.calcularRotacion(elVector);

        transform.rotation = currentRotation * deltaRotation;
        if (ElVectorRotacionComprobacion.magnitude <= 0.01f)
        {
            transform.rotation = LaRotacion.calcularRotacion(ElVectorFinal);
        }
    }




    void Rotar()
    {
        // Calcular el �ngulo de rotaci�n para este frame
        float anguloRotacion = velocidad * Time.deltaTime;

        // Aplicar la rotaci�n
        transform.Rotate(ElVectorRotacion.normalized * anguloRotacion, Space.World);

        // Actualizar el �ngulo restante
        ElVectorRotacionComprobacion -= ElVectorRotacion.normalized * anguloRotacion;
        // Detener la rotaci�n si el �ngulo restante es muy peque�o
        if (ElVectorRotacionComprobacion.magnitude <= 0.01f)
        {
            debeRotar = false;
        }
    }


}
