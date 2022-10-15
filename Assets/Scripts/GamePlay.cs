using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
public class GamePlay : MonoBehaviour
{

    private float timeRemaining;//Tiempo de Gameplay;
    private float timeReady = 3f;//Tiempo para prepararse
    GameObject txtContador;//Reloj de GamePlay
    GameObject txtReadyCount;//Reloj para prepararse 3 segundos
    public bool CocinarActivo = false;//Estado si se solicita cocinar
    GameObject CameraGameOver;//Reloj para prepararse 3 segundos
    GameObject ButtonPlay;

    GameObject LibroCocina;

    // Start is called before the first frame update
    void Start()
    {
        txtReadyCount = GameObject.Find("ReadyCount");//Txt 3 segundos
        txtContador = GameObject.Find("ContadorNumerico");//Txt Cronometro Gameplay
        LibroCocina = GameObject.Find("RecetasScript");
        CameraGameOver = GameObject.Find("CameraGameOver");
        ButtonPlay = GameObject.Find("ButtonPlay");
    }

    // Update is called once per frame
    void Update()
    {
        if (CocinarActivo == true)
        {
            if (timeReady > 0)//Si esta el contador 3 sec de estar listo
            {
                txtReadyCount.GetComponent<Text>().enabled = true;
                char[] Resultado = timeReady.ToString().ToCharArray();
                txtReadyCount.GetComponent<Text>().text = Resultado[0].ToString();
                timeReady -= Time.deltaTime;  // Math.Round(Convert.ToDecimal(timeReady), 0);
            }
            else//si ya inicia el tiempo de gameplay
            {
                txtReadyCount.GetComponent<Text>().enabled = false;
                txtContador.GetComponent<Text>().text = timeRemaining.ToString();
                timeRemaining -= Time.deltaTime;
                LibroCocina.GetComponent<LibroRecetas>().RecetaActual();
                LibroCocina.GetComponent<LibroRecetas>().MostrarReceta();
                if (timeRemaining < 28)
                {
                    //SceneManager.LoadScene( SceneManager.GetActiveScene().name );
                    //CanvasGameOver.SetActive(true);
                    //SceneManager.LoadScene("Cocina1");
                    Debug.Log(CameraGameOver.name);
                    Cursor.lockState = CursorLockMode.None;//Cursor no salga del juego

                    ButtonPlay.GetComponent<Image>().enabled = true;//MostrarBoton
                   
                    
                    CameraGameOver.GetComponent<Camera>().enabled = true;
                }
            }
        }
        else//NO se va a cocinar
        {
            txtReadyCount.GetComponent<Text>().enabled = false;
            txtContador.GetComponent<Text>().text = "00";
        }
    }

    public void IniciarCocina()//Inicia contadores de Gameplay
    {
        timeReady = 3;
        CocinarActivo = true;
        timeRemaining = 30.0f;
    }

    public void DetenerCocina()//Detiene contadores de Gameplay
    {
        timeReady = 3;
        CocinarActivo = false;
        timeRemaining = 30.0f;
    }
}
