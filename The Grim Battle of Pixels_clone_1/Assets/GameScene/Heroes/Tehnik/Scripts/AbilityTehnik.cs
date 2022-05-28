using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityTehnik : MonoBehaviour
{
    private Animator animator;
    private GameObject Enemy;
    private PlayerStatus plSt;
    private bool ability = false;
    private bool flag = true;


    void Start()
    {
        animator = GetComponent<Animator>();
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
                    && animator.GetCurrentAnimatorStateInfo(0).IsName("ability") && !collision.isTrigger)
        {

            plSt.TakeDamage(35);
            ability = false;
        }
    }
}
