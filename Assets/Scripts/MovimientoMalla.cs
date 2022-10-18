using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovimientoMalla : MonoBehaviour
{
    private GameObject Objetivo;//Punto de venta
    private GameObject ObjetivoRetorno;//Punto de spawn
    private bool Estado;
    NavMeshAgent agente; 
    GameObject Cronometro;

    // Start is called before the first frame update
    void Start()
    {
        Estado = false;
        agente = GetComponent<NavMeshAgent>();
    }



    // Update is called once per frame
    void Update()
    {
        if ((agente.remainingDistance > 0 && agente.remainingDistance < 1) && Estado == false)//Detenerse y girar
        {
            Estado = true;
            agente.isStopped = true;
            //this.transform.Rotate(Vector3.down * rotationTime);
            //Obtener GameObject de spawner ejecutar funcion de crear cliente
            Cronometro = GameObject.Find("GamePlay");
            Cronometro.GetComponent<GamePlay>().IniciarCocina();//Crear primero un clon de cliente
        }
    }


    //agente.pathEndPosition: posisión del objetivo final
    //agente.remainingDistance : distancia faltante 

    public void IrPuntoVenta()
    {
        Objetivo = GameObject.FindGameObjectWithTag("PuntoVenta");
        agente = GetComponent<NavMeshAgent>();
        agente.destination = Objetivo.transform.position;

        //Debug.Log("Punto de venta: " + agente.destination);
    }

    public void RegresarCliente()
    {
        Cronometro = GameObject.Find("GamePlay");
        Cronometro.GetComponent<GamePlay>().DetenerCocina();//Crear primero un clon de cliente


        agente.isStopped = false;
        //Estado = false;
        ObjetivoRetorno = GameObject.FindGameObjectWithTag("Spawn");

        agente.destination = ObjetivoRetorno.transform.position;
        //Debug.Log("Punto de spawn: " + agente.destination);
    }


}
