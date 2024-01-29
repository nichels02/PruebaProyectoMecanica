using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class movimientoPrueba : MonoBehaviour
{
    //[SerializeField] Transform cubo;


  
    public void OnMovement(InputAction.CallbackContext value)
    {
        Vector3 inputMovement = value.ReadValue<Vector3>();
        transform.position = inputMovement;
    }

    public void OnRotation (InputAction.CallbackContext value)
    {
        Quaternion inputMovement = value.ReadValue<Quaternion>();
        transform.rotation = inputMovement;
    }
}
