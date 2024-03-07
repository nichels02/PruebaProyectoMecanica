using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class movimientoPrueba : MonoBehaviour
{
    [SerializeField] Vector3 posicion;
    [SerializeField] Quaternion Rotacion;
    //[SerializeField] Transform cubo;


  
    public void OnMovement(InputAction.CallbackContext value)
    {
        Vector3 inputMovement = value.ReadValue<Vector3>();
        transform.position = inputMovement + posicion;
    }

    public void OnRotation (InputAction.CallbackContext value)
    {
        Quaternion inputMovement = value.ReadValue<Quaternion>();
        transform.rotation = inputMovement;
    }
}
