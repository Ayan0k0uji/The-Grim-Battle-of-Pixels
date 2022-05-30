using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPonchic : MonoBehaviour
{
    private SpawnHeroes spawnHeroes;
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
        spawnHeroes = Camera.main.GetComponent<SpawnHeroes>();
        animator = GetComponent<Animator>();
        plSt = GetComponent<PlayerStatus>();
        if (name == spawnHeroes.GetNamePl1())
        {
            Enemy = GameObject.Find(spawnHeroes.GetNamePl2()).gameObject;
        }
        else
        {
            Enemy = GameObject.Find(spawnHeroes.GetNamePl1()).gameObject;
        }

        plStEnemy = Enemy.GetComponent<PlayerStatus>();
        rb = Enemy.GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (flagColor)
        {
            Enemy.GetComponent<SpriteRenderer>().color = new Color(0.7f, 0.4f, 0.6f, 1f);
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("ulta"))
            ulta = true;
        /*else if (animator.GetCurrentAnimatorStateInfo(0).IsName("ulta_walking"))
            plSt.setSpeed(1000f);
        else
        {
            plSt.setSpeed(500f);
            ulta = false;
        }*/

        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("ability"))
            flag = true;

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("ability") && flag)
        {
            ability = true;
            flag = false;
        }

    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("ass");
        if (ulta && collision != null && collision.name == Enemy.name
                    && animator.GetCurrentAnimatorStateInfo(0).IsName("ulta_walking") && !collision.isTrigger && flag1)
        {
            Enemy.GetComponent<PlayerStatus>().setForceEnemy(true);
            Enemy.GetComponent<PlayerStatus>().setForce(15 * new Vector2(Enemy.transform.position.x - transform.position.x,
                Enemy.transform.position.y - transform.position.y));
            plStEnemy.TakeDamage(7);
            flag1 = false;
            Invoke("sFlag1", 0.2f);
        }

        if (ability && collision != null && collision.name == Enemy.name
                    && animator.GetCurrentAnimatorStateInfo(0).IsName("ability") && !collision.isTrigger)
        {
            plStEnemy.TakeDamage(15);
            flagColor = true;
            Enemy.GetComponent<SpriteRenderer>().color = new Color(0.7f, 0.4f, 0.6f, 1f);
            Invoke("abilityDamage", 7);
            ability = false;
        }
    }

    public void abilityDamage()
    {
        plStEnemy.TakeDamage(20);
        flagColor = false;
        Enemy.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }

    public void sFlag1()
    {
        flag1 = true;
    }

    public void newSpeed()
    {
        plSt.setSpeed(1000f);
    }

    public void newSpeed1()
    {
        plSt.setSpeed(500f);
        ulta = false;
    }
}
