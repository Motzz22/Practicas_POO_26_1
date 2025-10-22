using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI textoPuntaje;

    private int puntajeActual = 0;
   
    public int PuntajeActual { get { return puntajeActual; } set { value = puntajeActual; } }

    void Start()
    {
        textoPuntaje.text = "Puntos: " + puntajeActual;
    }

    private void Update()
    {
        textoPuntaje.text = "Puntos: " + puntajeActual;
    }

    public void CalcularPuntaje()
    {
        int puntaje = 0;
        puntaje++;

        puntajeActual = puntaje;
        if (textoPuntaje != null) { textoPuntaje.text = "Puntos: " + puntajeActual; }
    }
}
