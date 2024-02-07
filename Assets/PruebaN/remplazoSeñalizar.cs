using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class remplazoSeñalizar : MonoBehaviour
{
    [SerializeField] float raycastDistance = 10f;
    LineRenderer lineRenderer;
    GameObject objetoColicionado;
    GameObject objetoColicionadoPadre;
    bool estaSujetado = false;
    Vector3 PosicionParaRemplazar;
    float acercarOAlejar;
    bool RegularDistancia;
    bool EstanAgarrandoElPadre = false;
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
            if (EstanAgarrandoElPadre == false)
            {
                objetoColicionado = hit.collider.gameObject;
            }
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
                if (objetoColicionado.GetComponent<anclaje>())
                {
                    objetoColicionadoPadre = objetoColicionado.GetComponent<anclaje>().EstaSiendoSujetado();
                    objetoColicionadoPadre.transform.parent = transform;
                    EstanAgarrandoElPadre = true;
                    //print(EstanAgarrandoElPadre);
                }
                else
                {
                    objetoColicionado.transform.parent = transform;
                }
            }
        }
        else
        {
            if (EstanAgarrandoElPadre == true)
            {
                //print("soltar padre");
                EstanAgarrandoElPadre = false;
                objetoColicionadoPadre.transform.parent = null;
                objetoColicionadoPadre = null;
            }
            else if (objetoColicionado != null )
            {
                print(EstanAgarrandoElPadre);
                //print("soltar objeto");
                objetoColicionado.transform.parent = null;
            }
            estaSujetado = false;
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
            
            if (EstanAgarrandoElPadre == true)
            {
                elvector = objetoColicionadoPadre.transform.localRotation.eulerAngles + elvector * Time.deltaTime * 100;
                objetoColicionadoPadre.transform.localRotation = Quaternion.Euler(elvector);
            }
            else
            {
                elvector = objetoColicionado.transform.localRotation.eulerAngles + elvector * Time.deltaTime * 100;
                objetoColicionado.transform.localRotation = Quaternion.Euler(elvector);
            }
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
                    if (EstanAgarrandoElPadre == true)
                    {
                        print("1");
                        Acercar(objetoColicionadoPadre);
                    }
                    else
                    {
                        Acercar(objetoColicionado);
                    }
                    
                }
                else if (acercarOAlejar == -1)
                {
                    if (EstanAgarrandoElPadre == true)
                    {
                        Alejar(objetoColicionadoPadre);
                    }
                    else
                    {
                        Alejar(objetoColicionado);
                    }
                    
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


    void Acercar(GameObject objeto)
    {
        print(objeto.name);
        // Acercar
        Vector3 direction = (transform.position - PosicionParaRemplazar).normalized;
        //print(direction);
        Vector3 posicionReal = objeto.transform.position;
        posicionReal += direction * Time.deltaTime * 50;
        objeto.transform.position = posicionReal;
        raycastDistance -= Time.deltaTime * 25;
        print("acercar " + objeto.name);
    }

    void Alejar(GameObject objeto)
    {
        // Alejar
        Vector3 direction = (PosicionParaRemplazar - transform.position).normalized;
        //print(direction);
        Vector3 posicionReal = objeto.transform.position;
        posicionReal += direction * Time.deltaTime * 50;
        objeto.transform.position = posicionReal;
        raycastDistance += Time.deltaTime * 50;
        print("alejar " + objeto.name);
    }

}