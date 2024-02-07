using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoPadre : MonoBehaviour
{
    public void ReubicarPadre(Vector3 LaNuevaPosicion)
    {
        List<Transform> hijos = new List<Transform>();

        int cantidadHijos = transform.childCount;
        //print(cantidadHijos);
        for (int i = 0; i < cantidadHijos; i++) 
        {
            //print(transform.GetChild(i).name);
            //print(i);
            // Obtener el hijo en la posición i
            hijos.Add(transform.GetChild(i));
            //transform.GetChild(i).parent = null;
        }
        foreach (Transform hijo in hijos)
        {
            hijo.parent = null;
        }
        transform.position = LaNuevaPosicion;
        for (int i = 0; i < cantidadHijos; i++) 
        {
            hijos[i].parent = transform;
        }
    }
}
