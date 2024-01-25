using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParaLaCamara : MonoBehaviour
{
    WebCamTexture webcam;
    public GameObject panel;
    void Start()
    {
        webcam = new WebCamTexture();
        panel.GetComponent<Renderer>().material.mainTexture = webcam;
    }
}
