using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    [SerializeField]List<GameObject> listaPiezas;
     
    public void BusquedaReferenciaObjeto(GameObject nombre)
    {
        Transform primerHijo = nombre.transform.GetChild(0);
        Renderer renderer = primerHijo.GetComponent<Renderer>();
        renderer.material.color = Color.red;
    }
}

