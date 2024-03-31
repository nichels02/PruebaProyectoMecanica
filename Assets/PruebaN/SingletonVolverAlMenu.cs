using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingletonVolverAlMenu : MonoBehaviour
{
    public static SingletonVolverAlMenu instance { get; private set; }
    public int LasPiezas;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void YaEstaSujetada()
    {
        LasPiezas -= 1;
        if(LasPiezas <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
