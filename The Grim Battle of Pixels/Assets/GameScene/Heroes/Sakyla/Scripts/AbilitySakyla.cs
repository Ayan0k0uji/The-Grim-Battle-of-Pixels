using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySakyla : MonoBehaviour
{
    private Animator animator;
    private GameObject Enemy;
    private PlayerStatus plStEnemy;
    private PlayerStatus myPlSt;
    private Rigidbody2D rb;
    private bool ulta = false;
    private bool ability = false;
    private bool flag = true;
    private Vector2 temp;
    private Transform UltaPosition;
    [SerializeField] GameObject snot;


    void Start()
    {
        animator = GetComponent<Animator>();
        myPlSt = transform.parent.gameObject.GetComponent<PlayerStatus>();
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
                    && animator.GetCurrentAnimatorStateInfo(0).IsName("ability") && !collision.isTrigger)
        {
            Enemy.GetComponent<PlayerStatus>().setForceEnemy(true);
            if (Enemy.transform.GetChild(0).transform.position.x - transform.position.x < 0)
                temp = Vector2.left;
            else
                temp = Vector2.right;


            Enemy.GetComponent<PlayerStatus>().setForce(9 * temp);
            StartCoroutine("Force");
            plStEnemy.TakeDamage(20);
            ability = false;
        }
    }
}
