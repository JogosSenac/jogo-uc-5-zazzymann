using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class PlayerManege : MonoBehaviour
{
    public GameObject player;
    public GameObject TelaMorte;
    public GameObject TelaVitoria;
    public Vector3 posInicial;
    public Vector3 posInicialMoeda;
    public Vector3 posInicialChest = new Vector3(20.11527f,0.7714387f,0);
    public GameObject playerPrefab;
    public GameObject Money;
    public GameObject MoneyPrefab;
    public GameObject Chest;
    public GameObject ChestPrefab;
    public int vitoria;
    
    // Start is called before the first frame update
    void Start()
    {
        TelaMorte.GetComponent<GameObject>();
        posInicial = player.transform.position;
        posInicialMoeda = MoneyPrefab.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null){
            player = GameObject.FindWithTag("Player");
            Money = GameObject.FindWithTag("Money");
            Chest = GameObject.FindWithTag("Chest");
            TelaMorte.SetActive(true);
            TelaVitoria.SetActive(false);
        }else{
            TelaMorte.SetActive(false);
        }
    }
    public void Renascer(){
        vitoria++;
        Destroy(player);
        Time.timeScale = 1;
        TelaVitoria.SetActive(false);
        if(Money == null){
            Instantiate(MoneyPrefab,posInicialMoeda,quaternion.identity);
        }
        if(Chest == null){
            Instantiate(ChestPrefab,posInicialChest,quaternion.identity);
        }
        Instantiate(playerPrefab,posInicial,quaternion.identity);

    }
    public void quit(){
        Application.Quit();
    }
}
