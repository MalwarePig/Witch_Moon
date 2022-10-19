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
    {   //Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Caldero")
        { 
            Caldero = other;
            other.transform.GetComponent<Caldero>().ActivarEfectos(); //Ejecuta Funcion destruir de otro script 
            Destroy(gameObject); 
        }else if(other.gameObject.tag == "Cliente"){
             Destroy(gameObject); 
        }
    }


}
