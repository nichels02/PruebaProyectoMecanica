using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Senalizar : MonoBehaviour
{
    [SerializeField] float raycastDistance = 10f;
    LineRenderer lineRenderer;
    //[SerializeField] Transform mano;
    GameObject objetoColicionado;
    bool estaSujetandoAlgo;
    Vector3 startPos;
    Vector3 endPos;
    public LayerMask maskCollider;
    public bool RightpressA;
    public bool RightpressB;
    public bool EstaSujetandoAlgo
    {
        get { return estaSujetandoAlgo; }
    }
    public GameObject ObjetoColicionado
    {
        get { return objetoColicionado; }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Asegúrate de tener un LineRenderer en el objeto
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLazerSize();

        startPos = transform.position;
        
        if (estaSujetandoAlgo)
        {

            if (objetoColicionado != null)
            {
                endPos = transform.position + transform.forward * raycastDistance;
                UpdateobjetoColliderTransform();
            }
            pintarLineRender();

            return;
        }
        // Obtén la posición del objeto actual
        endPos = transform.position + transform.forward * raycastDistance;
        pintarLineRender();

    }
    #region Update
    private void UpdateLazerSize()
    {
        if (RightpressA)
            raycastDistance += Time.deltaTime * 10;
        if (RightpressB)
            raycastDistance -= Time.deltaTime * 10;
    }
    private void UpdateobjetoColliderTransform()
    {
        if (objetoColicionado != null)
        {
            objetoColicionado.transform.localPosition = transform.InverseTransformPoint(endPos);
        }
    }
    #endregion
    #region Event
    public void EventMoveAcercarObject(InputAction.CallbackContext value)
    {
        float v = value.ReadValue<float>();

        RightpressA = (v == 1) ? true : false;

    }
    public void EventMoveAlejarObject(InputAction.CallbackContext value)
    {
        float v = value.ReadValue<float>();

        RightpressB = (v == 1) ? true : false;

    }
    public void EventRotationObject(InputAction.CallbackContext value)
    {
        Vector2 inputMovement = value.ReadValue<Vector2>();
        transform.position = inputMovement;
    }
    public void EventSujetar(InputAction.CallbackContext value)
    {

        float inputSujetar = value.ReadValue<float>();
        if (inputSujetar == 1)
        {
            if (objetoColicionado == null)
            {
                tomarObjeto();
            }
        }
        else
        {

            if (objetoColicionado != null)
            {
                estaSujetandoAlgo = false;
                objetoColicionado.transform.parent = null;
                objetoColicionado = null;
            }
        }

    }
    #endregion
    #region Action
    private void tomarObjeto()
    {
        if (estaSujetandoAlgo == false)
        {

            // Dispara un rayo en la dirección del eje Z (puedes ajustar esto según tus necesidades)
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, raycastDistance, maskCollider))
            {

                // Si hay colisión, ajusta la posición final del LineRenderer
                raycastDistance = hit.distance;
                endPos = transform.position + transform.forward * raycastDistance;
                estaSujetandoAlgo = true;
                objetoColicionado = hit.collider.gameObject;
                objetoColicionado.transform.parent = transform;
                objetoColicionado.transform.localPosition = transform.InverseTransformPoint(endPos);
            }
        }
    }
    #endregion


    #region Draw
    void pintarLineRender()
    {
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, 0.1f);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * raycastDistance);

        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position + transform.forward * raycastDistance, 0.1f);
    }
    #endregion

                
}


