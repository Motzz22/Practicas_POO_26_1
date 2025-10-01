using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlbola : MonoBehaviour
{
    public Transform camaraPrincipal;

    public Rigidbody rb;

    public float velocidadDeApuntado = 5f;
    public float limiteIzquierda = -2f;
    public float limiteDerecha = 2f;

    public float fuerzaDeLanzamiento = 1000f;

    private bool haSidolansada = false;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (haSidolansada == false)
        {
            Apuntar();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Lanzar();

            }
        }
    }

    void Apuntar()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");

        transform.Translate (Vector3.right *  inputHorizontal *  velocidadDeApuntado * Time.deltaTime);

        Vector3 posicionActual = transform.position;

        //TransformPotition me permite sabe la posicion actual de la bola

        posicionActual.x=Mathf.Clamp(posicionActual.x, limiteIzquierda,limiteDerecha);

        transform.position = posicionActual;
    }

    void Lanzar()
    {
        haSidolansada = true;
        rb.AddForce(Vector3.forward * fuerzaDeLanzamiento);

        if (camaraPrincipal != null)
        {
            camaraPrincipal.SetParent(transform);
        }

    }

}//YOU SHALL NOT PASS!!!
