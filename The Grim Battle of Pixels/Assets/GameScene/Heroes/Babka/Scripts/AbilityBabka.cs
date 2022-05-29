using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBabka : MonoBehaviour
{
    private SpawnHeroes spawnHeroes;
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
        spawnHeroes = Camera.main.GetComponent<SpawnHeroes>();

        animator = GetComponent<Animator>();
        myPlSt = GetComponent<PlayerStatus>();

        if (name == spawnHeroes.GetNamePl1())
        {
            Enemy = GameObject.Find(spawnHeroes.GetNamePl2());
        }
        else
        {
            Enemy = GameObject.Find(spawnHeroes.GetNamePl1());
        }

        plStEnemy = Enemy.GetComponent<PlayerStatus>();
        rb = Enemy.GetComponent<Rigidbody2D>();
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
        if (ability && collision != null && collision.name == Enemy.name
                    && animator.GetCurrentAnimatorStateInfo(0).IsName("ability") && !collision.isTrigger)
        {
            Enemy.GetComponent<PlayerStatus>().setForceEnemy(true);
            if (Enemy.transform.position.x - transform.position.x < 0)
                temp = Vector2.left;
            else
                temp = Vector2.right;


            Enemy.GetComponent<PlayerStatus>().setForce(9 * temp);
            StartCoroutine("Force");
            plStEnemy.TakeDamage(20);
            ability = false;
        }
    }

    IEnumerator Force()
    {
        for (int i = 0; i < 10; i++)
        {
            Enemy.GetComponent<PlayerStatus>().setForceEnemy(true);
            Enemy.GetComponent<PlayerStatus>().setForce(9 * temp);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
