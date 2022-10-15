using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    // Start is called before the first frame update

    [Range(3, 7), SerializeField, Tooltip("Velocidad maxima")]
    private float speed = 5.0f;
    private float speedMAX = 9.0f;
    private bool Moved = false;
    private bool Cooked = false;

    private float horizontalInput, verticalInput, CookedInput;// Botones 

    [Header("Animacion")]
    private Animator animator;

    void Start()
    { 
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
       
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        CookedInput = Input.GetAxis("Jump");

       if (CookedInput != 0)
        {
            Cooked = true;
        }
        else
        {
            Cooked = false; 
        }
     
        animator.SetBool("Cook", Cooked);

        Debug.Log(Cooked);
        if (horizontalInput > 0 && verticalInput == 0)//Girar Derecha
        {
            if (speed < speedMAX) {
                speed = (speed * 1.002f);
            }
            
            Moved = true;
            this.transform.rotation = Quaternion.AngleAxis(180, Vector3.down * Time.deltaTime);
            this.transform.Translate(speed * Time.deltaTime * Vector3.forward * horizontalInput); //Moviemiento con aceleracion
        }
        else if(horizontalInput < 0 && verticalInput == 0 ){//Girar Izquierda
            Moved = true;
            if (speed < speedMAX)
            {
                speed = (speed * 1.002f);
            }
            this.transform.rotation = Quaternion.AngleAxis(0, Vector3.down * Time.deltaTime);
            this.transform.Translate(speed * Time.deltaTime * Vector3.back * horizontalInput); //Moviemiento con aceleracion 
        }
        else if (horizontalInput > 0 && verticalInput > 0)//inclinar Derecha arriba
        {
            if (speed < speedMAX)
            {
                speed = (speed * 1.002f);
            }
            Moved = true;
            this.transform.rotation = Quaternion.AngleAxis(225, Vector3.down * Time.deltaTime);
            this.transform.Translate(speed * Time.deltaTime * Vector3.forward * horizontalInput); //Moviemiento con aceleracion
        }
        else if (horizontalInput > 0 && verticalInput < 0)//inclinar Derecha abajo
        {
            if (speed < speedMAX)
            {
                speed = (speed * 1.002f);
            }
            Moved = true;
            this.transform.rotation = Quaternion.AngleAxis(135, Vector3.down * Time.deltaTime);
            this.transform.Translate(speed * Time.deltaTime * Vector3.forward * horizontalInput); //Moviemiento con aceleracion
        }
        else if (horizontalInput < 0 && verticalInput > 0)//inclinar Izquierda arriba
        {
            if (speed < speedMAX)
            {
                speed = (speed * 1.002f);
            }
            Moved = true;
            this.transform.rotation = Quaternion.AngleAxis(315, Vector3.down * Time.deltaTime);
            this.transform.Translate(speed * Time.deltaTime * Vector3.back * horizontalInput); //Moviemiento con aceleracion
        }
        else if (horizontalInput < 0 && verticalInput < 0)//inclinar Izquierda abajo
        {
            if (speed < speedMAX)
            {
                speed = (speed * 1.002f);
            }
            Moved = true;
            this.transform.rotation = Quaternion.AngleAxis(45, Vector3.down * Time.deltaTime);
            this.transform.Translate(speed * Time.deltaTime * Vector3.back * horizontalInput); //Moviemiento con aceleracion
        }

        
        //Movimiento vertical
        if (verticalInput > 0 && horizontalInput == 0)//Hacia enfrente
        {
            if (speed < speedMAX)
            {
                speed = (speed * 1.002f);
            }
            Moved = true;
            this.transform.rotation = Quaternion.AngleAxis(270, Vector3.down * Time.deltaTime);
            this.transform.Translate(speed * Time.deltaTime * Vector3.forward * verticalInput); //Moviemiento con aceleracion
            Cooked = false;
        }
        else if (verticalInput < 0 && horizontalInput == 0)//Hacia atras
        {
            if (speed < speedMAX)
            {
                speed = (speed * 1.002f);
            }
            Moved = true;
            this.transform.rotation = Quaternion.AngleAxis(90, Vector3.down * Time.deltaTime);
            this.transform.Translate(speed * Time.deltaTime * Vector3.back * verticalInput); //Moviemiento con aceleracion
            Cooked = false;
        } 


        //Resetear animacion de correr y velocidad inicial
        if (verticalInput == 0 && horizontalInput == 0)
        {
            speed = 5.0f;
            Moved = false;
        }


      

       
        animator.SetBool("Movimiento", Moved);
        //this.transform.Rotate(speed * Vector3.up * horizontalInput); //Moviemiento de giro
      



    }
}
