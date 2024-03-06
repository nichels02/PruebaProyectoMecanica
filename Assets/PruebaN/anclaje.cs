using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anclaje : MonoBehaviour
{
    [SerializeField] List<Anclaje> padres = new List<Anclaje>();
    [SerializeField] GameObject objetoPadre;
    bool estaDesarmado = false;
    public bool EstaSuelto = false;
    Renderer MyRenderer;
    Material MaterialGuardado;
    [SerializeField] Material materialT;
    [SerializeField] Material materialF;




    private void Start()
    {
        MyRenderer = GetComponent<Renderer>();
        MaterialGuardado = MyRenderer.material;
    }
    public GameObject EstaSiendoSujetado()
    {
        //print("llego");
        if (EstaSuelto == false)
        {
            print(objetoPadre.name);
            objetoPadre.GetComponent<ObjetoPadre>().ReubicarPadre(transform.position);
            
            return objetoPadre;
        }
        else
        {
            print("se lleva al hijo");
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
                //EstaSuelto = true;
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


    public void CambiarColor()
    {
        if (padres.Count == 0 && !EstaSuelto)
        {
            Color(materialT);
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
                Color(materialT);
            }
            else
            {
                Color(materialF);
            }
        }
    }

    void Color(Material color)
    {
        MaterialGuardado = MyRenderer.material;
        MyRenderer.material = color;
    }

    public void RegresarColor()
    {
        MyRenderer.material = MaterialGuardado;
    }

}
