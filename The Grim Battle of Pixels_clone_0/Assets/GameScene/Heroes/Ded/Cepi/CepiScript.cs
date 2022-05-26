using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CepiScript : MonoBehaviour
{
    private Animator animatorPlayer;
    private GameObject Enemy;
    private PlayerStatus plSt;
    private bool flag = true;


    private void Start()
    {
        if (transform.parent.transform.parent.gameObject.name == "Player1")
        {
            plSt = GameObject.Find("Player2").GetComponent<PlayerStatus>();
            Enemy = GameObject.Find("Player2").gameObject;
        }
        else
        {
            plSt = GameObject.Find("Player1").GetComponent<PlayerStatus>();
            Enemy = GameObject.Find("Player1").gameObject;
        }
        animatorPlayer = transform.parent.GetComponent<Animator>();
    }
    public void endUlta()
    {
        animatorPlayer.SetBool("ulta", false);
        gameObject.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null && collision.name == Enemy.transform.GetChild(0).name
                    && !collision.isTrigger && flag)
        {
            flag = false;
            plSt.TakeDamage(4);
            Invoke("sFlag1", 0.2f);
        }
    }

    private void sFlag1()
    {
        flag = true;
    }
}
