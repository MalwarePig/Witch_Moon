using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LibroRecetas : MonoBehaviour
{
    Dictionary<string, bool> Receta_Uno;

    string[]
        Ingredientes =
        {
            "Vacio",
            "Potion_Purple",
            "Potion_Blue",
            "Potion_Red",
            "PolvoAzul",
            "PolvoRed"
        };

    string[] ingrActual = new string[5];

    public string IngredienteActual; //Ingrediente en mano

    private float timeReady = 3f; //Tiempo para prepararse

    //Potion_Purple, Potion_Blue, Potion_Red, PolvoAzul, PolvoRed
    public GameObject[] MarcoIcono; //;Marco del icono de la receta

    public Sprite[] SpritePotion; //Icono de los ingredientes

    public GameObject ScriptReward; //Icono de la receta

    private bool RecetaIniciada = false; //Para saber si ya se creo la primera receta

    void Start()
    {
        ScriptReward = GameObject.Find("Reward");
    }

    private void Update()
    {
        timeReady -= Time.deltaTime;
    }

    public void RecetaActual()
    {
        //   Debug.Log(Receta_Uno["Potion_Red"]);
    }

    public void IngredienteEnMano(string nombre)
    {
        //Debug.Log (nombre);
        if (
            RecetaIniciada == true //Ejecutar solo si ya esta una receta activa si se toma un ingrediente antes de empezar
        )
        {
            IngredienteActual = nombre;
            Receta_Uno[IngredienteActual] = true;
        }
    }

    public void AgregarEspecie()
    {
        int totalElementos = 0;

        if (RecetaIniciada == true)
        {
            //Receta_Uno["Potion_Red"] = true;
            foreach (var entry in Receta_Uno)
            {
                //Debug.Log(entry.Key + ":" + entry.Value);
                if (entry.Value)
                {
                    totalElementos++;
                    if (totalElementos == 5)
                    {
                        Debug.Log("Completo!");
                        ScriptReward.GetComponent<Rewards>().InvocarRewards();
                    }
                }
            }
            //Debug.Log("El Nombre que llega al libro: " + IngredienteActual);s
        }
    }

    public void CrearRecetaRandom()
    {
        RecetaIniciada = true; //Se inicia la receta
        int[] numRandom = CalcularNumeros();
        for (int i = 0; i < 5; i++)
        {
            ingrActual[i] = Ingredientes[numRandom[i]];
        }

        Receta_Uno =
            new Dictionary<string, bool>()
            {
                { ingrActual[0], false },
                { ingrActual[1], false },
                { ingrActual[2], false },
                { ingrActual[3], false },
                { ingrActual[4], false }
            };
    }

    public void MostrarReceta() //Muestra los iconos segun la receta
    {
        MarcoIcono[0].GetComponent<Image>().sprite = SpritePotion[0];
        int index = 0;
        foreach (var entry in Receta_Uno)
        {
            //Debug.Log(entry.Key + ":" + entry.Value);
            switch (entry.Key)
            {
                case "PolvoAzul":
                    MarcoIcono[index].GetComponent<Image>().sprite =
                        SpritePotion[0];
                    break;
                case "PolvoRed":
                    MarcoIcono[index].GetComponent<Image>().sprite =
                        SpritePotion[1];
                    break;
                case "Potion_Blue":
                    MarcoIcono[index].GetComponent<Image>().sprite =
                        SpritePotion[2];
                    break;
                case "Potion_Purple":
                    MarcoIcono[index].GetComponent<Image>().sprite =
                        SpritePotion[3];
                    break;
                case "Potion_Red":
                    MarcoIcono[index].GetComponent<Image>().sprite =
                        SpritePotion[4];
                    break;
                default: //MarcoIcono[index].GetComponent<Image>().sprite = SpritePotion[0];
                    break;
            }
            index++;
        }
    }

    private int[] CalcularNumeros()
    {
        int[] numeros = new int[5];
        System.Random r = new System.Random();

        int auxiliar = 0;
        int contador = 0;

        for (int i = 0; i < 5; i++)
        {
            auxiliar = r.Next(0, 6);
            bool continuar = false;

            while (!continuar)
            {
                for (int j = 0; j <= contador; j++)
                {
                    if (auxiliar == numeros[j])
                    {
                        continuar = true;
                        j = contador;
                    }
                }

                if (continuar)
                {
                    auxiliar = r.Next(0, 6);
                    continuar = false;
                }
                else
                {
                    continuar = true;
                    numeros[contador] = auxiliar;
                    contador++;
                }
            }
        }
        return numeros;
    }
}
