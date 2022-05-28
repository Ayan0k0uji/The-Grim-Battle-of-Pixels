using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class SpawnHeroesOnline : MonoBehaviourPunCallbacks
{
    [SerializeField] int Player1;
    [SerializeField] int Player2;
    private GameObject PL1;
    private GameObject PL2;
    private PhotonView photonView;
    private bool host = false;
    private string[] nameHeroes = new string[5] {"Babka", "Ponchic", "Tehnik", "Ded", "" };

    [SerializeField] Sprite[] HeroesIcons = new Sprite[5];
    private Image P1I;
    private Image P2I;
    bool flag = true;


    //private MenuScript msc;


    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        if (PhotonNetwork.IsMasterClient)
            host = true;

        Player1 = LobbyManager.P1;
        Player2 = LobbyManager.P2;

        if (host)
        {
                 
                 /*  PL1 = PhotonNetwork.Instantiate(nameHeroes[Player1], GameObject.Find("Player1").transform.position, Quaternion.identity);
                   PL1.transform.parent = GameObject.Find("Player1").transform;
                   PL1.transform.localPosition = Vector3.zero;*/
                PL1 = PhotonNetwork.Instantiate(nameHeroes[Player1], Vector3.zero, Quaternion.identity);
                PL1.transform.SetParent(GameObject.Find("Player1").transform);
                PL1.transform.localPosition = Vector3.zero;
               //GameObject.Find(nameHeroes[Player2] + "(clone)").transform.SetParent(GameObject.Find("Player2").transform);
                

        }
        else
        {
            /*PL2 = PhotonNetwork.Instantiate(nameHeroes[Player2], GameObject.Find("Player2").transform.position, Quaternion.identity);
            PL2.transform.parent = GameObject.Find("Player2").transform;
            PL2.transform.localPosition = Vector3.zero;*/

            PL2 = PhotonNetwork.Instantiate(nameHeroes[Player2], Vector3.zero, Quaternion.identity);
            PL2.transform.SetParent(GameObject.Find("Player2").transform);
            PL2.transform.localPosition = Vector3.zero;
            //GameObject.Find(nameHeroes[Player1] + "(clone)").transform.SetParent(GameObject.Find("Player1").transform);
            
        }

        
        /*if (host)
        {
            photonView.RPC("spawnEnemy", PhotonNetwork.PlayerList[1]);
        }
        else
        {
            photonView.RPC("spawnEnemy", PhotonNetwork.PlayerList[0]);
        }*/
        



        if (Player1 == Player2)
            PL2.name = PL2.name + "1";

        

        P1I = GameObject.Find("IconP1").GetComponent<Image>();
        P2I = GameObject.Find("IconP2").GetComponent<Image>();
        P1I.sprite = HeroesIcons[Player1];
        P2I.sprite = HeroesIcons[Player2];
    }
    private void Update()
    {
        GameObject.Find(nameHeroes[Player1] + " clone").transform.SetParent(GameObject.Find("Player1").transform);
        GameObject.Find("Babka(Clone)").transform.parent = GameObject.Find("Player2").transform;
        /*if (GameObject.Find(nameHeroes[Player1] + "(clone)") && flag)
        {
            Debug.Log("as");
            *//*GameObject.Find(nameHeroes[Player1] + "(clone)").transform.SetParent(GameObject.Find("Player1").transform);
            flag = false;*//*
        }
        if (GameObject.Find(nameHeroes[Player2] + "(clone)") && flag)
        {
            Debug.Log("qw");
           *//* GameObject.Find(nameHeroes[Player2] + "(clone)").transform.SetParent(GameObject.Find("Player2").transform);
            flag = false;*//*
        }*/
    }


    /*[PunRPC]
    private void spawnEnemy()
    {
        if (host)
        {
            PL2 = GameObject.Find(nameHeroes[Player2]);
            Debug.Log(PL2.name);
            PL2.transform.parent = GameObject.Find("Player2").transform;
        }
        else
        {
            PL1 = GameObject.Find(nameHeroes[Player1]);
            Debug.Log(PL1.name);
            PL1.transform.parent = GameObject.Find("Player1").transform;
        }
    }*/
}
