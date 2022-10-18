using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntregaRewards : MonoBehaviour
{
    GameObject FuncionesMalla;
    GameObject FuncionesGameplay;
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
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Cliente")
        {
            //  other.transform.GetComponent<Caldero>().ActivarEfectos(); //Ejecuta Funcion destruir de otro script 
            Destroy(gameObject);//Destruye recompensa al entregar
            FuncionesMalla = GameObject.FindGameObjectWithTag("Cliente");//Se ovtiene funciones de cliente
            FuncionesMalla.GetComponent<MovimientoMalla>().RegresarCliente();//Llama al npc y que se diriga a punto origen y se destruye

            FuncionesGameplay = GameObject.Find("GamePlay");//Se obtiene funciones de cliente
            FuncionesGameplay.GetComponent<GamePlay>().DetenerCocina();//Detiene
        }
    }

 







}
