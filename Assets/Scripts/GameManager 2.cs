using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    // Instancia estática del GameManager2
    private static GameManager2 instance;

    // Lista de piezas
    [SerializeField] List<TagsPiezas> listaPiezas;
    [SerializeField] Color colorBase;
    int ii;
    // Propiedad para acceder a la instancia del GameManager2
    public static GameManager2 Instance
    {
        get
        {
            // Si no hay una instancia, la buscamos en la escena
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager2>();

                // Si aún no se encuentra, lanzamos un error
                if (instance == null)
                {
                    Debug.LogError("No se encontró una instancia de GameManager2 en la escena.");
                }
            }
            return instance;
        }
    }
    private void Awake()
    {
        colorBase = listaPiezas[0].transform.GetChild(0).GetComponent<Renderer>().material.color;
    }
    public void BusquedaReferenciaObjeto(GameObject nombre)
    {
        for (int i=0;i<listaPiezas.Count;i++)
        {
            if(listaPiezas[i].tagCodigo == nombre.GetComponent<MoveToCorrectPosition>().tagName)
            {
                if (i >= 0 && i <= 2)
                {
                    Grupo1();
                }
                else if (i >= 3 && i <= 10)
                {
                    Grupo2();
                }
                else if(i >=11 && i <= 22)
                {
                    Grupo3();
                }
                else if(i >= 23 && i <= 28)
                {
                    Grupo4();
                }
                else if(i == 29)
                {
                    Grupo5();
                }
                else if(i == 30)
                {
                    Grupo6();
                }
                ii = i;
                //Transform hijoObjeto = listaPiezas[i].transform.GetChild(0);
                //Renderer renderer1 = hijoObjeto.GetComponent<Renderer>();
                //renderer1.material.color = Color.black;

            }
        }
    }
    public void VolverAColor(GameObject nombre)
    {
        if (listaPiezas[ii].tagCodigo == nombre.GetComponent<MoveToCorrectPosition>().tagName)
        {

            listaPiezas[ii].transform.GetChild(0).GetComponent<Renderer>().material.color = colorBase;
        }
    }

    public void Grupo1() {
        bool a1 = false;
        if (ii == 2)
        {
            PintarPieza();
            if (listaPiezas[ii].prueba)
            {
                a1 = true;
            }
        }
        if (a1 == true)
        {
            PintarPieza();
        }
        ii = int.MinValue;
        
    }
    public void Grupo2()
    {

    }
    public void Grupo3()
    {

    }
    public void Grupo4()
    {

    }
    public void Grupo5()
    {

    }
    public void Grupo6()
    {

    }
    public void PintarPieza()
    {
        Transform hijoObjeto = listaPiezas[ii].transform.GetChild(0);
        Renderer renderer1 = hijoObjeto.GetComponent<Renderer>();
        renderer1.material.color = Color.black;
    }

}

/////Grupos
/* grupo 1 
 * 0,1,2 -- orden 2-(1-0)
 * grupo 2
  
                   4 -5 - 3 -(6-7)
 * 3--10 -- orden -   
                   8 - 10 - 9
 * grupo 3
                              12 - 15
                         22 - 13 -16
                              14 -17
 * 11--22 -- orden 18-11-
                         (21-20)-19
 

 * grupo 4
 
                         23-24
 * 23--28 -- orden 26-25-
                         29-28

 * grupo 5
 * 29 -- orden 29
 * grupo 6
 * 30 -- orden 30
 */