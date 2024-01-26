using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Señalizar : MonoBehaviour
{
    [SerializeField] float raycastDistance = 10f;
    LineRenderer lineRenderer;
    [SerializeField] Transform mano;
    GameObject objetoColicionado;

    // Start is called before the first frame update
    void Start()
    {
        // Asegúrate de tener un LineRenderer en el objeto
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Obtén la posición del objeto actual
        Vector3 startPos = mano.position;

        // Dispara un rayo en la dirección del eje Z (puedes ajustar esto según tus necesidades)
        if (Physics.Raycast(startPos, transform.forward, out RaycastHit hit, raycastDistance))
        {
            // Si hay colisión, ajusta la posición final del LineRenderer
            lineRenderer.SetPosition(0, startPos);
            lineRenderer.SetPosition(1, hit.point);
            objetoColicionado = hit.collider.gameObject;
        }
        else
        {
            // Si no hay colisión, establece la posición final a la distancia máxima
            Vector3 endPos = startPos + transform.forward * raycastDistance;
            lineRenderer.SetPosition(0, startPos);
            lineRenderer.SetPosition(1, endPos);
            objetoColicionado = null;
        }
    }

    public void Sujetar(InputAction.CallbackContext value)
    {
        float inputSujetar = value.ReadValue<float>();
        if(objetoColicionado!=null && inputSujetar == 1)
        {
            objetoColicionado.transform.parent = transform;
        }
        else
        {
            objetoColicionado.transform.parent = null;
        }
    }
}


