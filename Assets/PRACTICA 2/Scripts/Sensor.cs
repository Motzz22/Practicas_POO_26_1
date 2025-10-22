using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{


    public GameObject [] Luces;

    public Score PUNTOS;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Panel"))
        {
            //Luz.SetActive(true); //de a solapa (cada uno de los 5 huevos, nessi view)
            foreach (var luz in Luces)
            {
                luz.SetActive(true); //en grupo de objetos usar este (para item hueso, huellas y cuernoUnicornio)
            }
            Debug.Log("Da clic en el botton");
        }

        if (other.CompareTag("Item"))
        {
            other.gameObject.SetActive(false);
            Debug.Log("mira el huevo del dragon, eso debido de doler");
            PUNTOS.CalcularPuntaje();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Panel"))
        {
            //Luz.SetActive(false);
            foreach (var luz in Luces)
            {
                luz.SetActive(false);
            }
            Debug.Log("Ya puedes pasar");
        }
    }

}//YOU SHALL NOT PASS!!

