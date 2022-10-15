using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    private Transform Client;
    private float Timer;
    public GameObject[] ClientesNuevos;
    
    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        /*  if (Timer < Time.time)
         { //This checks wether real time has caught up to the timer
             Instantiate(Enemy, transform.position, transform.rotation); //This spawns the emeny
             Timer = Time.time + 15; // THIS (15) IS THE SECONDS (TIME) IN WHICH THE ENEMY IS GOING TO SPAWN FOR THE SECOND TIME 
         } */
    }

    private void Awake()
    {
        //  Timer = Time.time + 15;// THIS (15) IS THE SECONDS (TIME) IN WHICH THE ENEMY IS GOING TO SPAWN FOR THE FIRST TIME 
    }

    public void InvocarCliente()
    { 
        int ClienteRandom = Random.Range(0, ClientesNuevos.Length);
        Instantiate(ClientesNuevos[ClienteRandom], transform.position, transform.rotation); //This spawns the emeny                                                                        // Instantiate(Client, transform.position, transform.rotation); //This spawns the emeny
    }

    public void MatarCliente()
    {
        Destroy(GameObject.FindGameObjectWithTag("Cliente"),5f);                                                                     // Instantiate(Client, transform.position, transform.rotation); //This spawns the emeny
    }

}
