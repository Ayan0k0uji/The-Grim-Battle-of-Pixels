using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSakyla : MonoBehaviour
{
    private SpawnHeroes spawnHeroes;
    private Animator animator;
    private PlayerStatus plSt;
    private PlayerStatus plStEnemy;
    private GameObject Enemy;
    private bool check_kick;                            // ������������� �� �������� �����
    private bool botKick, topKick;                      // ����� �� ����
    private bool bot_kick = false, top_kick = false;    // ��������� ���� ��� ���
    private int bot_damage = 22, top_damage = 30;

    void Start()
    {
        spawnHeroes = Camera.main.GetComponent<SpawnHeroes>();
        animator = GetComponent<Animator>();
        plStEnemy = GetComponent<PlayerStatus>();
        if (name == spawnHeroes.GetNamePl1())
        {
            Enemy = GameObject.Find(spawnHeroes.GetNamePl2());
        }
        else
        {
            Enemy = GameObject.Find(spawnHeroes.GetNamePl1());
        }
        plSt = Enemy.GetComponent<PlayerStatus>();
    }



    void Update()
    {
        if (check_kick)                     // ��������� �� ���������� �� ����
            topKick = botKick = true;
        check_kick = !animator.GetCurrentAnimatorStateInfo(0).IsName("bottom_kick")
                            && !animator.GetCurrentAnimatorStateInfo(0).IsName("top_kick");
    }

    void FixedUpdate()
    {
        if (botKick)
        {
            bot_kick = true;
            botKick = false;
        }
        else if (topKick)
        {
            top_kick = true;
            topKick = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (bot_kick && collision != null && collision.name == Enemy.name                   
                    && animator.GetCurrentAnimatorStateInfo(0).IsName("bottom_kick") && !collision.isTrigger)       // ���� ����� ������
        {
            plStEnemy.setCurrentMana(5);
            plSt.TakeDamage(bot_damage);
            bot_kick = false;
        }
        if (top_kick && collision != null && collision.name == Enemy.name
                    && animator.GetCurrentAnimatorStateInfo(0).IsName("top_kick") && !collision.isTrigger)          // ���� ����� �������
        {
            plStEnemy.setCurrentMana(5);
            plSt.TakeDamage(top_damage);
            top_kick = false;
        }
    }
}
