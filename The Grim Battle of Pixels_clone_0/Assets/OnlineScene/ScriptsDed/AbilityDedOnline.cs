using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityDedOnline : MonoBehaviour
{
    private SpawnHeroes spawnHeroes;
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
        spawnHeroes = Camera.main.GetComponent<SpawnHeroes>();
        animator = GetComponent<Animator>();
        plSt = GetComponent<PlayerStatus>();
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
