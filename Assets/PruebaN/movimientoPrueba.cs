using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class movimientoPrueba : MonoBehaviour
{
    [SerializeField] Transform cubo;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMovement(InputAction.CallbackContext value)
    {
        Vector3 inputMovement = value.ReadValue<Vector3>();
        cubo.position = inputMovement;
    }

    public void OnRotation (InputAction.CallbackContext value)
    {
        Quaternion inputMovement = value.ReadValue<Quaternion>();
        cubo.rotation = inputMovement;
    }
}
