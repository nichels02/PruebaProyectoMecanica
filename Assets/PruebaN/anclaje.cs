using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum NombreDePieza
{
    pieza1,
    pieza2,
    pieza3,
    pieza4,
    pieza5,
    pieza6,
    pieza7,
    pieza8,
    pieza9,
    pieza10,
    pieza11,
    pieza12,
    pieza13,
    pieza14,
    pieza15,
    pieza16,
    pieza17,
    pieza18,
    pieza19,
    pieza20,
    pieza31,
    pieza32,
    pieza33,
    horquilla,
    cabezalTrasero,
    cabezalDelantero,
    emboloTrasero,
    emboloDelantero,
    vastago,
    anillosDeDesgaste,
    tornillo,
    volandas,
    tubo,
    sellosDeBastago,
    sellosDelPiston,
    sellosAmortiguadores,
    g
}

public class Anclaje : MonoBehaviour
{
    public NombreDePieza ElNombre;
    [SerializeField] List<Anclaje> padres = new List<Anclaje>();
    [SerializeField] GameObject objetoPadre;
    [SerializeField] Anclaje ElPadreDeEstaPieza;
    public bool EsHijoDeOtraPieza = false;
    public bool estaDesarmado = false;
    public bool EstaSuelto = false;
    Renderer MyRenderer;
    Material MaterialGuardado;
    [SerializeField] Material materialT;
    [SerializeField] Material materialF;
    public bool EsteTieneOtroCollider;
    public Collider ElCollider;




    private void Start()
    {
        MyRenderer = GetComponent<Renderer>();
        ElCollider = GetComponent<Collider>();
        ElCollider.enabled = false;
        MaterialGuardado = MyRenderer.material;
    }
    public GameObject EstaSiendoSujetado()
    {
        //print("llego al metodo de sujertar" + name);
        if (EstaSuelto == false)
        {
            if (!EsHijoDeOtraPieza)
            {
                //print(objetoPadre.name);
                objetoPadre.GetComponent<ObjetoPadre>().ReubicarPadre(transform.position);

                return objetoPadre;
            }
            else
            {
                return ElPadreDeEstaPieza.EstaSiendoSujetado();
            }
            
        }
        else
        {
            if (EsteTieneOtroCollider)
            {
                ElCollider.enabled = true;
            }
            //print("se lleva al hijo"+name);
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
