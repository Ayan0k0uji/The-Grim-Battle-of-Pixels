using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityDed : MonoBehaviour
{
    private Animator animator;
    private GameObject Enemy;
    private PlayerStatus plStEnemy;
    private PlayerStatus plSt;
    private Rigidbody2D rb;
    private bool ulta = false;
    private bool ability = false;
    private bool flag = true;
    private bool flagAb = true;
    private Vector2 temp;
    private Transform UltaPosition;


    void Start()
    {
        animator = GetComponent<Animator>();
        plSt = transform.parent.gameObject.GetComponent<PlayerStatus>();
        if (transform.parent.gameObject.name == "Player1")
        {
            plStEnemy = GameObject.Find("Player2").GetComponent<PlayerStatus>();
            Enemy = GameObject.Find("Player2").gameObject;
            rb = Enemy.transform.GetChild(0).gameObject.GetComponent<Rigidbody2D>();
        }
        else
        {
            plStEnemy = GameObject.Find("Player1").GetComponent<PlayerStatus>();
            Enemy = GameObject.Find("Player1").gameObject;
            rb = Enemy.transform.GetChild(0).gameObject.GetComponent<Rigidbody2D>();
        }
    }


    void Update()
    {

        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("ability"))
            flag = true;
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("ability") && flag)
        {
            ability = true;
            flag = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ability && collision != null && collision.name == Enemy.transform.GetChild(0).name
                    && animator.GetCurrentAnimatorStateInfo(0).IsName("ability1") && !collision.isTrigger && flagAb)
        {
            plStEnemy.TakeDamage(14);
            flagAb = false;
        }
    }

    private void flagAb1() {
        flagAb = true;
    }
}
