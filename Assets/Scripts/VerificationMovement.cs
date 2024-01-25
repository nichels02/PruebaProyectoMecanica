using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VerificationMovement : MonoBehaviour
{
    [SerializeField] XRGrabInteractable xrMovement;
    private void Awake()
    {
        xrMovement = GetComponent<XRGrabInteractable>();
        xrMovement.enabled = false;
    }
    public void ActivateInteraction()
    {
        xrMovement.enabled = true;
    }
    public void DeactivateInteraction()
    {
        xrMovement.enabled = false;
    }
}
