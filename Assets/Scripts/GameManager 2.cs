using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    // Instancia est�tica del GameManager2
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

                // Si a�n no se encuentra, lanzamos un error
                if (instance == null)
                {
                    Debug.LogError("No se encontr� una instancia de GameManager2 en la escena.");
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
                Transform hijoObjeto = listaPiezas[i].transform.GetChild(0);
                Renderer renderer1 = hijoObjeto.GetComponent<Renderer>();
                renderer1.material.color = Color.black;
                ii = i;
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