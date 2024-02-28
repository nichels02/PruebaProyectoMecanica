using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaccion : MonoBehaviour
{
    [SerializeField] Anclaje Objeto;

    

    public GameObject RecibirObjeto()
    {
        GameObject gameObject = Objeto.EstaSiendoSujetado();
        return gameObject;
    }
}
