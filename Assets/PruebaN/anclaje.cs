using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anclaje : MonoBehaviour
{
    [SerializeField] List<Anclaje> padres = new List<Anclaje>();
    [SerializeField] GameObject objetoPadre;
    bool estaDesarmado = false;
    bool EstaSuelto = false;





    private void Start()
    {
        
    }
    public GameObject EstaSiendoSujetado()
    {
        //print("llego");
        if (EstaSuelto == false)
        {
            //se lleva el objetoPadre
            objetoPadre.GetComponent<ObjetoPadre>().ReubicarPadre(transform.position);
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
        if (padres.Count == 0 && !EstaSuelto)
        {
            SiSeDesarmara();
            EstaSuelto = true;
        }
        else if (!EstaSuelto)
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
                SiSeDesarmara();
            }
            else
            {
                //suena Sonido de fallido
            }
        }
    }


    void SiSeDesarmara()
    {
        GetComponent<MovimientoPreciso>().DebeRotar = true;
    }




}
