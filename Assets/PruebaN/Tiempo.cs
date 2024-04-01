using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Tiempo : MonoBehaviour
{
    [SerializeField] TMP_Text TextoTiempo;
    [SerializeField] GameObject PanelDePerdiste;
    float x;
    int minutos = 2;
    int segundos = 0;
    bool recargaEscenaRealizada;
    bool Perdio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x = x < 1 ? x + Time.deltaTime : Perdio ? tiempoPerder() : AumentarSegundos();
    }

    int AumentarSegundos()
    {
        segundos -= 1;
        if (segundos == -1 && minutos > 0)
        {
            segundos = 59;
            minutos = minutos!=0 ? minutos-1 : 0;
            TextoTiempo.text = minutos + " : " + segundos;
        }
        else if(segundos == -1 && minutos == 0)
        {
            segundos = 0;
            Perdio = true;
            TextoTiempo.text = minutos + " : " + segundos;
            PanelDePerdiste.SetActive(true);
        }
        
        return 0;
        
    }

    int tiempoPerder()
    {
        segundos+=1;
        if (segundos > 10 && !recargaEscenaRealizada)
        {
            recargaEscenaRealizada = true;
            SceneManager.LoadScene(0);
        }
        return 0;
    }
}
