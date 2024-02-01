using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class anclaje : MonoBehaviour
{
    [SerializeField] List<anclaje> padres = new List<anclaje>();
    [SerializeField] GameObject objetoPadre;
    bool estaDesarmado = false;
    bool EstaSuelto = false;


    private void Start()
    {
        if (padres.Count == 0)
        {
            EstaSuelto = true;
        }
    }


    public GameObject EstaSiendoSujetado()
    {
        print("llego");
        if (EstaSuelto == false)
        {
            //se lleva el objetoPadre
            return objetoPadre;
        }
        else
        {
            //se lleva el objeto suelto
            estaDesarmado = true;
            return gameObject;
        }

    }


    public void DesarmarPieza()
    {
        if (EstaSuelto == false)
        {
            bool tmp = false;
            for (int i = 0; i < padres.Count; i++)
            {
                if (padres[i] != null && padres[i].estaDesarmado == false)
                {
                    tmp = true;
                }
            }

            if (tmp == false)
            {
                EstaSuelto = true;
                //se desarma
            }
        }
        

    }




}
