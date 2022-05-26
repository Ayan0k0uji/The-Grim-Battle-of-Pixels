using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPonchic : MonoBehaviour
{
    private Animator animator;
    private GameObject Enemy;
    private PlayerStatus plSt;
    private PlayerStatus plStEnemy;
    private Rigidbody2D rb;
    private bool ulta = false;
    private bool ability = false;
    private bool flag = true;
    private bool flag1 = true;
    private bool flagColor = false;


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
        if (flagColor)
        {
            Enemy.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(0.7f, 0.4f, 0.6f, 1f);
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("ulta"))
            ulta = true;
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("ulta_walking"))
            plSt.setSpeed(1000f);
        else
        {
            plSt.setSpeed(500f);
            ulta = false;
        }

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
        if (ulta && collision != null && collision.name == Enemy.transform.GetChild(0).name
                    && animator.GetCurrentAnimatorStateInfo(0).IsName("ulta_walking") && !collision.isTrigger && flag1)
        {
            Enemy.GetComponent<PlayerStatus>().setForceEnemy(true);
            Enemy.GetComponent<PlayerStatus>().setForce(15 * new Vector2(Enemy.transform.GetChild(0).transform.position.x - transform.position.x,
                Enemy.transform.GetChild(0).transform.position.y - transform.position.y));
            plStEnemy.TakeDamage(7);
            flag1 = false;
            Invoke("sFlag1", 0.5f);
        }

        if (ability && collision != null && collision.name == Enemy.transform.GetChild(0).name
                    && animator.GetCurrentAnimatorStateInfo(0).IsName("ability") && !collision.isTrigger)
        {
            plStEnemy.TakeDamage(15);
            flagColor = true;
            Enemy.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(0.7f, 0.4f, 0.6f, 1f);
            Invoke("abilityDamage", 7);
            ability = false;
        }
    }

    public void abilityDamage()
    {
        plStEnemy.TakeDamage(20);
        flagColor = false;
        Enemy.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }

    public void sFlag1()
    {
        flag1 = true;
    }

}
