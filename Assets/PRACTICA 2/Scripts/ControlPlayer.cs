using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ControlPlayer : MonoBehaviour

{
    //movimento

    public float velocidad = 5f; //para controlar la velocidad del player
    public float gravedad = -9.8f; //esta controla la gravedad en el playes

    private CharacterController controller;  //esta es capaz de dar movimento al player en el juego
    private Vector3 velocidadVertical; //nos permite sabe qye tan rapido caemos

    //Variables Vista

    public Transform camara; //registra que camara sirve como los ojos del jugador
    public float sensibilidadMouse = 200f; //que tan rapido se mueve el mouse a la hora de voltear la vista 
    private float rotacionXVertical = 0F; //indica los grados que el jugador puede ver tanto como arriba como abajo

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        ManejadorVista();
        ManjedorMovimento(); 
    }

    void ManejadorVista ()
    {
        //1.imvocar el input del mouse

        float mouseX = Input.GetAxis("Mouse X") * sensibilidadMouse * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadMouse * Time.deltaTime;

        //2. Velocidad mouse
        transform.Rotate(Vector3.up * mouseX);

        //3.rotacion vertical
        rotacionXVertical -= mouseY;

        //4. limitar rotacion
        Mathf.Clamp(rotacionXVertical, -90f, 90f);

        //5. aplicar rotacion
        camara.localRotation = Quaternion.Euler(rotacionXVertical, 0, 0);

    }

    void ManjedorMovimento()
    {
        //1. INPUT MOVIMIENTO "WASD O FLECHAS DE DIRECCION"

        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");


        //2. VECTOR DE MOVIMIENTO
        
        Vector3 direccion = transform.right*inputX+transform.forward*inputZ;

        //3. MOVER EL CGARACTER CONTROLLER

        controller.Move (direccion*velocidad*Time.deltaTime);

        //4. AÑADIR GRAVEDAD
        //regustrar si estas en el piso para poder saltar (proximamente)

        if (controller.isGrounded && velocidadVertical.y <0)
        {
            velocidadVertical.y = -2f;
        }

        velocidadVertical.y += gravedad * Time.deltaTime;
        controller.Move(velocidadVertical*Time.deltaTime);
    }

}//YOU SHALL NOT PASS!!!
