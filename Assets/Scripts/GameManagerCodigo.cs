using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerCodigo : MonoBehaviour
{
    [SerializeField] VerificationMovement[] objetos;
    private void Start()
    {
        objetos[8].ActivateInteraction();
        objetos[7].ActivateInteraction();
        objetos[6].ActivateInteraction();
    }

}
