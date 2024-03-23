using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public void Armado()
    {
        SceneManager.LoadScene(2);
    }
    public void Desarmado()
    {
        SceneManager.LoadScene(1);
    }
}
