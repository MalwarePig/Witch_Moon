using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewards : MonoBehaviour
{

    GameObject Clone;


    public GameObject[] PotionRewards;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void InvocarRewards()
    {
        int RewardRandom = Random.Range(0, PotionRewards.Length);
        Clone = Instantiate(PotionRewards[RewardRandom], transform.position, transform.rotation); //This spawns the emeny           
        Clone.tag = "ObjetoInteractivo";
        Clone.name = "RecompensaActiva";
        Destroy(PotionRewards[RewardRandom].gameObject);                                                     // Instantiate(Client, transform.position, transform.rotation); //This spawns the emeny;
    }
}
