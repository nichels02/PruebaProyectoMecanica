using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirObjetos : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject,2);
    }
}
