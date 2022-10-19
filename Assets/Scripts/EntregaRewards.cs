 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntregaRewards : MonoBehaviour
{
    GameObject FuncionesMalla;
    GameObject MovimientoPalanca;
    // Start is called before the first frame update
    void Start()
    {
        //FuncionesMalla = GameObject.Find("SpawnerScript");

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Cliente")
        {
            Debug.Log(other.gameObject.name);
            //  other.transform.GetComponent<Caldero>().ActivarEfectos(); //Ejecuta Funcion destruir de otro script 
            Destroy(gameObject);//Destruye recompensa al entregar
            FuncionesMalla = GameObject.FindGameObjectWithTag("Cliente");//Se ovtiene funciones de cliente
            FuncionesMalla.GetComponent<MovimientoMalla>().RegresarCliente();//Llama al npc y que se diriga a punto origen y se destruye

             MovimientoPalanca = GameObject.Find("Lever_Wall_Handle");//Se obtiene funciones de cliente
            MovimientoPalanca.GetComponent<Palanca>().ActivarPalanca();//Detiene
        }
    }
}



















