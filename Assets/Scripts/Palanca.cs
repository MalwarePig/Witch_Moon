using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palanca : MonoBehaviour
{
    GameObject Cliente;

    GameObject Spawn;
    Transform Padre;
    private Animator animatorPalanca;//Acceso al animator
    bool propIsActive;

    GameObject LibroCocina;
    // Start is called before the first frame update

    void Start()
    {
        Padre = this.transform.parent;
        animatorPalanca = Padre.GetComponent<Animator>();//Se obtiene la animacion del padre

        LibroCocina = GameObject.Find("RecetasScript");
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void ActivarPalanca()
    {
        if (propIsActive == false)
        {
            propIsActive = true;
        }
        else
        {
            propIsActive = false;
        }
        llamarCliente(propIsActive);
        animatorPalanca.SetBool("Activado", propIsActive);//Anima la palanca hacia arriba o abajo

        LibroCocina.GetComponent<LibroRecetas>().CrearRecetaRandom();
    }

    private void llamarCliente(bool EstadoPalanca)
    {
        if (EstadoPalanca == true)
        {
            //Obtener GameObject de spawner ejecutar funcion de crear cliente
            Spawn = GameObject.FindGameObjectWithTag("Spawn");
            Spawn.GetComponent<Spawner>().InvocarCliente();//Crear primero un clon de cliente 

            Cliente = GameObject.FindGameObjectWithTag("Cliente");
            Cliente.GetComponent<MovimientoMalla>().IrPuntoVenta();//Llama al npc y que se diriga a punto de venta
        }
        else
        {
            //Debug.Log(EstadoPalanca);

            Cliente = GameObject.FindGameObjectWithTag("Cliente");
            Cliente.GetComponent<MovimientoMalla>().RegresarCliente();//Llama al npc y que se diriga a punto de venta

            //Obtener GameObject de spawner ejecutar funcion de crear cliente
            Spawn = GameObject.FindGameObjectWithTag("Spawn");
            Spawn.GetComponent<Spawner>().MatarCliente();//Crear primero un clon de cliente 
        }

    }

}
