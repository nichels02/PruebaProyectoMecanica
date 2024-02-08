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
                ii = i;
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
        if (ii == 2)
        {
            PintarPieza();
        }
        else if (ii != 2 && listaPiezas[2].prueba) 
        {
            PintarPieza();
        }
    }
    public void Grupo2()
    {
        if (ii == 4 || ii==8)
        {
            PintarPieza();
        }
        else if (ii == 5 && listaPiezas[4].prueba)
        {
            PintarPieza();
        }
        else if (ii == 3 && listaPiezas[5].prueba)
        {
            PintarPieza();
        }
        else if ((ii == 6 || ii == 7) && listaPiezas[3].prueba)
        {
            PintarPieza();
        }
        else if (ii == 10 && listaPiezas[8].prueba)
        {
            PintarPieza();
        }
        else if (ii == 9 && listaPiezas[10].prueba)
        {
            PintarPieza();
        }
        /*
          * grupo 2
  
                                4 -5 - 3 -(6-7)
            * 3--10 -- orden -   
                                8 - 10 - 9
         */
    }
    public void Grupo3()
    {
        if (ii == 18)
        {
            PintarPieza();
        }
        else if (ii == 11 && listaPiezas[18].prueba)
        {
            PintarPieza();
        }
        else if (ii == 22 && listaPiezas[11].prueba)
        {
            PintarPieza();
        }
        else if (ii == 12 && listaPiezas[22].prueba)
        {
            PintarPieza();
        }
        else if (ii == 15 && listaPiezas[12].prueba)
        {
            PintarPieza();
        }
        else if (ii == 13 && listaPiezas[22].prueba)
        {
            PintarPieza();
        }
        else if (ii == 16 && listaPiezas[13].prueba)
        {
            PintarPieza();
        }
        else if (ii == 14 && listaPiezas[22].prueba)
        {
            PintarPieza();
        }
        else if (ii == 17 && listaPiezas[14].prueba)
        {
            PintarPieza();
        }
        else if ((ii == 21|| ii == 20) && listaPiezas[11].prueba)
        {
            PintarPieza();
        }
        else if (ii == 19 && (listaPiezas[20].prueba && listaPiezas[21].prueba))
        {
            PintarPieza();
        }
        /** grupo 3
                              12 - 15
                         22 - 13 -16
                              14 -17
 * 11--22 -- orden 18-11-
                         (21-20)-19*/

    }
    public void Grupo4()
    {
        if (ii == 26)
        {
            PintarPieza();
        }
        else if (ii ==25 && listaPiezas[26].prueba)
        {
            PintarPieza();
        }
        else if (ii == 28  && listaPiezas[26].prueba)
        {
            PintarPieza();
        }
        else if (ii == 27  && listaPiezas[28].prueba)
        {
            PintarPieza();
        }
        else if (ii == 23  && listaPiezas[25].prueba)
        {
            PintarPieza();
        }else if (ii == 24 && listaPiezas[23].prueba)
        {
            PintarPieza();
        }

        /* * grupo 4
 
                         23-24
 * 23--28 -- orden 25-26
                         27-28*/
    }
    public void Grupo5()
    {
        PintarPieza();
    }
    public void Grupo6()
    {
        PintarPieza();
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