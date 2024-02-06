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


/*
using UnityEngine;

public class PadreScript : MonoBehaviour
{
    private void Start()
    {
        // Acceder al primer hijo del objeto padre
        Transform primerHijo = transform.GetChild(0);

        if (primerHijo != null)
        {
            // Obtener el componente del script en el primer hijo
            HijoScript hijoScript = primerHijo.GetComponent<HijoScript>();

            if (hijoScript != null)
            {
                // Realizar cambios en el script del hijo
                hijoScript.ModificarCodigo();
            }
            else
            {
                Debug.LogError("El primer hijo no tiene el script HijoScript adjunto.");
            }
        }
        else
        {
            Debug.LogError("El objeto padre no tiene hijos.");
        }
    }
}

*/