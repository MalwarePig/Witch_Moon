using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caldero : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 Nuevovector;
    Quaternion Rotacion;

    private float timeRemaining;
    private bool Animacion;

    GameObject LibroCocina;

    void Start()
    {
        Nuevovector = this.transform.position;
        Rotacion = this.transform.rotation;
        LibroCocina = GameObject.Find("RecetasScript");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Nuevovector;
        transform.rotation = Rotacion;

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);//explosion
            transform.GetChild(1).gameObject.SetActive(false);//fuego  
            transform.GetComponent<AudioSource>().enabled = false;
            timeRemaining = 0.0f;
        }
    }

    public void ActivarEfectos()//Actifa efectos al dejar en caldero
    {
        transform.GetChild(0).gameObject.SetActive(true);//explosion
        transform.GetChild(1).gameObject.SetActive(true);//fuego 
        transform.GetComponent<AudioSource>().enabled = true;
        //transform.gameObject.GetComponent<AudioSource>().enabled = true;
        timeRemaining = 2.0f;


        LibroCocina.GetComponent<LibroRecetas>().AgregarEspecie();

    }




}
