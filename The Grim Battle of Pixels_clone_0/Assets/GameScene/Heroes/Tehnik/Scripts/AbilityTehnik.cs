using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityTehnik : MonoBehaviour
{
    private SpawnHeroes spawnHeroes;
    [SerializeField] GameObject shit;
    private Animator animator;
    private Animator anim;
    private GameObject Enemy;
    private PlayerStatus plSt;
    private PlayerStatus myPlSt;
    private bool ability = false;
    private bool flag = true;


    void Start()
    {
        spawnHeroes = Camera.main.GetComponent<SpawnHeroes>();
        animator = GetComponent<Animator>();
        anim = shit.GetComponent<Animator>();
        if (name == spawnHeroes.GetNamePl1())
        {
            Enemy = GameObject.Find(spawnHeroes.GetNamePl2()).gameObject; 
        }
        else
        {
            Enemy = GameObject.Find(spawnHeroes.GetNamePl1()).gameObject;
        }
        plSt = Enemy.GetComponent<PlayerStatus>();
        myPlSt = GetComponent<PlayerStatus>();
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
            shit.SetActive(true);
            myPlSt.SetCurrentArmor(30);
            plSt.TakeDamage(35);
            ability = false;
            StartCoroutine("Armor");
        }
    }

    IEnumerator Armor()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            if (myPlSt.GetCurrentArmor() == 0)
            {
                anim.SetBool("shit", true);
                break;
            }
        }
    }
}
