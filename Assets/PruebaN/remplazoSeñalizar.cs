using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class remplazoSeñalizar : MonoBehaviour
{
    [SerializeField] float raycastDistance = 10f;
    LineRenderer lineRenderer;
    GameObject objetoColicionado;
    bool estaSujetado = false;
    Vector3 PosicionParaRemplazar;
    float acercarOAlejar;
    bool RegularDistancia;

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
        Vector3 startPos = transform.position;

        // Dispara un rayo en la dirección del eje Z (puedes ajustar esto según tus necesidades)
        if (Physics.Raycast(startPos, transform.forward, out RaycastHit hit, raycastDistance))
        {
            // Si hay colisión, ajusta la posición final del LineRenderer
            lineRenderer.SetPosition(0, startPos);
            lineRenderer.SetPosition(1, hit.point);
            objetoColicionado = hit.collider.gameObject;
            PosicionParaRemplazar = hit.point;
            //print(PosicionParaRemplazar);
        }
        else
        {
            // Si no hay colisión, establece la posición final a la distancia máxima
            Vector3 endPos = startPos + transform.forward * raycastDistance;
            lineRenderer.SetPosition(0, startPos);
            lineRenderer.SetPosition(1, endPos);
            objetoColicionado = null;
        }

        if (RegularDistancia == true)
        {
            UpdateAcercaryAlejar();
        }

    }

    public void Sujetar(InputAction.CallbackContext value)
    {
        float inputSujetar = value.ReadValue<float>();
        if (inputSujetar == 1)
        {
            if (objetoColicionado != null)
            {
                estaSujetado = true;
                objetoColicionado.transform.parent = transform;
            }
        }
        else
        {
            estaSujetado = false;
            if (objetoColicionado != null)
            {
                objetoColicionado.transform.parent = null;
            }
        }
    }
  
    public void EventRotateObject(InputAction.CallbackContext value)
    {
        //print("1");
        Vector2 LaRotacion = value.ReadValue<Vector2>();
        //print(LaRotacion);
        if (objetoColicionado != null)
        {
            Vector3 elvector = new Vector3(LaRotacion.y, LaRotacion.x * -1, 0);
            elvector = objetoColicionado.transform.localRotation.eulerAngles + elvector * Time.deltaTime * 100;

            objetoColicionado.transform.localRotation = Quaternion.Euler(elvector);
        }
    }

    public void EventMoveAcercarObject(InputAction.CallbackContext value)
    {
        acercarOAlejar = value.ReadValue<float>();
        if (acercarOAlejar != 0f)
        {
            RegularDistancia = true;
        }
        else
        {
            RegularDistancia = false;
        }
    }

    public void UpdateAcercaryAlejar()
    {
        if (objetoColicionado != null)
        {
            if (estaSujetado == true)
            {
                if (acercarOAlejar == 1)
                {
                    // Acercar
                    Vector3 direction = (transform.position - PosicionParaRemplazar).normalized;
                    print(direction);
                    objetoColicionado.transform.position += direction * Time.deltaTime * 0.1f;
                    raycastDistance -= Time.deltaTime * 50;
                    print("acercar");
                }
                else if (acercarOAlejar == -1)
                {
                    // Alejar
                    Vector3 direction = (PosicionParaRemplazar - transform.position).normalized;
                    print(direction);
                    objetoColicionado.transform.position += direction * Time.deltaTime * 0.1f;
                    raycastDistance += Time.deltaTime * 50;
                    print("alejar");
                }
            }
        }
        else
        {
            if (acercarOAlejar == 1)
            {
                raycastDistance -= Time.deltaTime * 10;
            }
            else if (acercarOAlejar == -1)
            {
                raycastDistance += Time.deltaTime * 10;
            }
        }
    }

}