using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class remplazoSeñalizar : MonoBehaviour
{
    [SerializeField] float raycastDistance = 10f;
    LineRenderer lineRenderer;
    [SerializeField] GameObject objetoColicionado;
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
                //cambiarColor(hit.collider.gameObject,objetoColicionado);
                objetoColicionado = hit.collider.gameObject;
                //print(objetoColicionado.name);
                //objetoColicionado.GetComponent<Anclaje>().CambiarColor();
            }
            PosicionParaRemplazar = hit.point;
            //print(PosicionParaRemplazar);
            //print("a");
        }
        else
        {
            // Si no hay colisión, establece la posición final a la distancia máxima
            
            
            
            Vector3 endPos = startPos + transform.forward * raycastDistance;
            lineRenderer.SetPosition(0, startPos);
            lineRenderer.SetPosition(1, endPos);
            objetoColicionado = null;
            //print("b");
        }

        if (RegularDistancia == true)
        {
            UpdateAcercaryAlejar();
        }

    }

    public void Sujetar(InputAction.CallbackContext value)
    {
        float inputSujetar = value.ReadValue<float>();

        if(inputSujetar == 1 &&   objetoColicionado != null   && objetoColicionado.tag=="objeto" && !estaSujetado)
        {
            estaSujetado = true;
            if (objetoColicionado.GetComponent<Interaccion>())
            {
                objetoColicionadoPadre = objetoColicionado.GetComponent<Interaccion>().RecibirObjeto();
                objetoColicionadoPadre.transform.parent = transform;
                EstanAgarrandoElPadre = true;
                //print(EstanAgarrandoElPadre);
                //print("1");
            }
            else
            {
                objetoColicionado.transform.parent = transform;
            }
        }
        /*
        else if(inputSujetar == 1 && objetoColicionado != null && objetoColicionado.tag == "objeto" && !estaSujetado)
        {

        }
        */
        else if(inputSujetar == 0 && estaSujetado == true)
        {
            if (EstanAgarrandoElPadre == true)
            {
                //print("soltar padre");
                EstanAgarrandoElPadre = false;
                objetoColicionadoPadre.transform.parent = null;
                objetoColicionadoPadre = null;
            }
            else if (objetoColicionado != null)
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
            if (EstanAgarrandoElPadre == true)
            {
                Vector3 elvector = new Vector3(0, LaRotacion.x * -1, LaRotacion.y);
                //print("1");
                elvector = objetoColicionadoPadre.transform.rotation.eulerAngles + elvector * Time.deltaTime * 100;
                objetoColicionadoPadre.transform.rotation = Quaternion.Euler(elvector);
                print("evento moverse" + name);
            }
            else if (estaSujetado)
            {
                Vector3 elvector = new Vector3(LaRotacion.y, LaRotacion.x * -1, 0);
                elvector = objetoColicionado.transform.localRotation.eulerAngles + elvector * Time.deltaTime * 100;
                objetoColicionado.transform.localRotation = Quaternion.Euler(elvector);
            }
        }
    }

    public void EventMoveAcercarObject(InputAction.CallbackContext value)
    {
        acercarOAlejar = value.ReadValue<float>();
        RegularDistancia = (acercarOAlejar != 0 ? true : false);
    }

    public void EventDesarmar(InputAction.CallbackContext value)
    {
        //print("evento desarmar" + name);
        float inputDesarmar = value.ReadValue<float>();
        if (objetoColicionado != null && !estaSujetado && inputDesarmar == 1 && objetoColicionado.GetComponent<Interaccion>()) 
        {
            objetoColicionado.GetComponent<Interaccion>().desarmar();
        }
        else if(objetoColicionado != null && !estaSujetado && inputDesarmar == 1 && objetoColicionado.GetComponent<Button>())
        {
            //print("llego al boton");
            objetoColicionado.GetComponent<Button>().onClick.Invoke();
        }
    }


    void UpdateAcercaryAlejar()
    {
        if(objetoColicionado != null && estaSujetado == true && acercarOAlejar == 1)
        {
            if (EstanAgarrandoElPadre == true)
            {
                //print("1");
                Acercar(objetoColicionadoPadre);
            }
            else
            {
                Acercar(objetoColicionado);
            }
        }
        else if(objetoColicionado != null && estaSujetado == true && acercarOAlejar == -1)
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
        //print(objeto.name);
        float distancia = Vector3.Distance(objeto.transform.position, transform.position);
        if (distancia > 1)
        {
            // Acercar
            Vector3 direction = (transform.position - PosicionParaRemplazar).normalized;
            //print(direction);
            Vector3 posicionReal = objeto.transform.position;
            posicionReal += direction * Time.deltaTime * 12.5f;
            objeto.transform.position = posicionReal;
            raycastDistance -= Time.deltaTime * 6.25f;
            //print("acercar " + objeto.name);
        }
    }

    void Alejar(GameObject objeto)
    {
        // Alejar
        Vector3 direction = (PosicionParaRemplazar - transform.position).normalized;
        //print(direction);
        Vector3 posicionReal = objeto.transform.position;
        posicionReal += direction * Time.deltaTime * 12.5f;
        objeto.transform.position = posicionReal;
        raycastDistance += Time.deltaTime * 12.5f;
        //print("alejar " + objeto.name);
    }


    void cambiarColor(GameObject ElNuevo, GameObject ElAntiguo)
    {
        ////print("111111");
        if (ElAntiguo.GetComponent<Interaccion>() && ElAntiguo != null) 
        {
            ElAntiguo.GetComponent<Interaccion>().color(false);
        }
        if (ElNuevo.GetComponent<Interaccion>())
        {
            ElNuevo.GetComponent<Interaccion>().color(true);
        }
    }

}