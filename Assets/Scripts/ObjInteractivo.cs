using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjInteractivo : MonoBehaviour
{
    

    Collision Caldero;
    public void ActivarObjeto()
    {
        // Destroy(gameObject); 
    }

    private void OnCollisionEnter(Collision other)
    {   
        if (other.gameObject.tag == "Caldero")
        { 
            Caldero = other;

            other.transform.GetComponent<Caldero>().ActivarEfectos(); //Ejecuta Funcion destruir de otro script 
            Destroy(gameObject); 
        }
    }


}
