using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovimientoPreciso : MonoBehaviour
{
    [SerializeField] Rotacion LaRotacion;
    [SerializeField] int velocidad = 100;
    [SerializeField] int velocidadDeMovimiento = 100;
    [SerializeField] Vector3 ElVectorRotacion;
    [SerializeField] int vueltas;
    Vector3 ElVectorRotacionComprobacion = new Vector3(1, 1, 1);
    Vector3 ElVectorFinal;
    [SerializeField] bool debeRotar;
    bool debeRotar2;


    [SerializeField] GameObject puntoFinal;



    public bool DebeRotar
    {
        get
        {
            return debeRotar;
        }
        set
        {
            debeRotar = value;
        }
    }


    private void Start()
    {
        ElVectorRotacionComprobacion.x = ElVectorRotacion.x != 0 ? ElVectorRotacionComprobacion.x = 360 / ElVectorRotacion.x * vueltas * ElVectorRotacion.x : 0;
        ElVectorRotacionComprobacion.y = ElVectorRotacion.y != 0 ? ElVectorRotacionComprobacion.y = 360 / ElVectorRotacion.y * vueltas * ElVectorRotacion.y : 0;
        ElVectorRotacionComprobacion.z = ElVectorRotacion.z != 0 ? ElVectorRotacionComprobacion.z = 360 / ElVectorRotacion.z * vueltas * ElVectorRotacion.z : 0;
        ElVectorFinal = ElVectorRotacionComprobacion;
        
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
        if (debeRotar2 && ElVectorRotacionComprobacion.x > 0 || ElVectorRotacionComprobacion.y > 0 || ElVectorRotacionComprobacion.z > 0)
        {
            print(ElVectorRotacionComprobacion);
            rotar();
        }
        if (debeRotar2 && transform.position != puntoFinal.transform.position)
        {
            transporte();
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


    void transporte()
    {
        transform.position = Vector3.Lerp(transform.position, puntoFinal.transform.position, Time.deltaTime * velocidadDeMovimiento);
        if(Vector3.Distance(transform.position, puntoFinal.transform.position) <= 0.1f)
        {
            transform.position = puntoFinal.transform.position;
        }
    }





    /*
    void Rotar()
    {
        // Calcular el ángulo de rotación para este frame
        float anguloRotacion = velocidad * Time.deltaTime;

        // Aplicar la rotación
        transform.Rotate(ElVectorRotacion.normalized * anguloRotacion, Space.World);

        // Actualizar el ángulo restante
        ElVectorRotacionComprobacion -= ElVectorRotacion.normalized * anguloRotacion;
        // Detener la rotación si el ángulo restante es muy pequeño
        if (ElVectorRotacionComprobacion.magnitude <= 0.01f)
        {
            debeRotar = false;
        }
    }
    */

}
