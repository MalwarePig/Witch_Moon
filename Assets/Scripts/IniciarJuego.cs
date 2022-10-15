using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class IniciarJuego : MonoBehaviour
{

   
    
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ComenzarJuego()
    {
        Debug.Log("clicccc");
        SceneManager.LoadScene("Cocina1");
         
    }
}
