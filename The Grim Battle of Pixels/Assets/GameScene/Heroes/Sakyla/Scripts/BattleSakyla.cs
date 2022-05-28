using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSakyla : MonoBehaviour
{
    private Animator animator;
    private PlayerStatus plSt;
    private PlayerStatus plStEnemy;
    private GameObject Enemy;
    private bool check_kick;
    private bool bk, tk;
    private bool bot_kick = false, t_kick = false;
    private int bot_damage = 12, top_damage = 10;

    void Start()
    {
        animator = GetComponent<Animator>();
        plStEnemy = transform.parent.gameObject.GetComponent<PlayerStatus>();
        if (transform.parent.gameObject.name == "Player1")
        {
            plSt = GameObject.Find("Player2").GetComponent<PlayerStatus>();
            Enemy = GameObject.Find("Player2").gameObject;
        }
        else
        {
            plSt = GameObject.Find("Player1").GetComponent<PlayerStatus>();
            Enemy = GameObject.Find("Player1").gameObject;
        }
    }



    void Update()
    {
        if (check_kick)
            tk = bk = true;
        check_kick = !animator.GetCurrentAnimatorStateInfo(0).IsName("botton_kick")
                            && !animator.GetCurrentAnimatorStateInfo(0).IsName("top_kick");
    }

    void FixedUpdate()
    {
        if (bk)
        {
            bot_kick = true;
            bk = false;
        }
        else if (tk)
        {
            t_kick = true;
            tk = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (bot_kick && collision != null && collision.name == Enemy.transform.GetChild(0).name
                    && animator.GetCurrentAnimatorStateInfo(0).IsName("botton_kick") && !collision.isTrigger)
        {
            Debug.Log("aboba");
            plStEnemy.setCurrentMana(5);
            plSt.TakeDamage(bot_damage);
            bot_kick = false;
        }
        if (t_kick && collision != null && collision.name == Enemy.transform.GetChild(0).name
                    && animator.GetCurrentAnimatorStateInfo(0).IsName("top_kick") && !collision.isTrigger)
        {
            Debug.Log("aboba");
            plStEnemy.setCurrentMana(5);
            plSt.TakeDamage(top_damage);
            t_kick = false;
        }
    }
}
