using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovimientoPreciso : MonoBehaviour
{
    [SerializeField] Rotacion LaRotacion;
    [SerializeField] int velocidad = 1500;
    [SerializeField] int velocidadDeMovimiento = 1;
    [SerializeField] Vector3 ElVectorRotacion;
    [SerializeField] Vector3 escalaInicial;
    Vector3 escalaFinal;
    [SerializeField] int vueltas;
    Vector3 ElVectorRotacionComprobacion = new Vector3(1, 1, 1);
    Vector3 ElVectorFinal;
    [SerializeField] bool debeRotar;
    bool debeRotar2;
    bool debeRotar2_1;
    bool debeRotar2_2;
    bool debeRotar3;


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
        ElVectorRotacionComprobacion.x = ElVectorRotacion.x != 0 ?   ElVectorRotacionComprobacion.x = 360 / ElVectorRotacion.x * vueltas * ElVectorRotacion.x : 0;
        ElVectorRotacionComprobacion.y = ElVectorRotacion.y != 0 ?   ElVectorRotacionComprobacion.y = 360 / ElVectorRotacion.y * vueltas * ElVectorRotacion.y : 0;
        ElVectorRotacionComprobacion.z = ElVectorRotacion.z != 0 ?   ElVectorRotacionComprobacion.z = 360 / ElVectorRotacion.z * vueltas * ElVectorRotacion.z : 0;
        ElVectorFinal = ElVectorRotacionComprobacion;
        escalaFinal = transform.localScale;
    }
    private void Update()
    {
        //print("1");
        //ElVectorRotacion= 5,0,0



        if (debeRotar == true)
        {
            GetComponent<Anclaje>().enabled = false;
            escala(escalaInicial);
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
        if (debeRotar3)
        {
            escala(escalaFinal);
            
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
            debeRotar2_1 = true;
            debeRotar3 = debeRotar2_2 = true ? true : false;
        }
    }


    void transporte()
    {
        transform.position = Vector3.Lerp(transform.position, puntoFinal.transform.position, Time.deltaTime * velocidadDeMovimiento);
        if(Vector3.Distance(transform.position, puntoFinal.transform.position) <= 0.3f)
        {
            transform.position = puntoFinal.transform.position;
            debeRotar2_2 = true;
            debeRotar3 = debeRotar2_1 = true ? true : false;
        }
    }

    void escala(Vector3 escalaDeseada)
    {
        transform.localScale = Vector3.Lerp(transform.localScale, escalaDeseada, Time.deltaTime * velocidadDeMovimiento);
        if (Vector3.Distance(transform.localScale, escalaDeseada) <= 0.3f)
        {
            transform.localScale = escalaDeseada;
            if (debeRotar)
            {
                debeRotar2 = true;
                debeRotar = false;
            }
            else if (debeRotar3)
            {
                debeRotar3 = false;
                GetComponent<Anclaje>().enabled = true;
                GetComponent<MovimientoPreciso>().enabled = false;
            }
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
