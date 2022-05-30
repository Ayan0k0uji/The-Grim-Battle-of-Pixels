using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CepiScriptOnline : MonoBehaviour
{
    private SpawnHeroes spawnHeroes;
    private Animator animatorPlayer;
    private GameObject Enemy;
    private PlayerStatus plSt;
    private bool flag = true;


    private void Start()
    {
        spawnHeroes = Camera.main.GetComponent<SpawnHeroes>();

        if (transform.parent.transform.name == spawnHeroes.GetNamePl1())
        {
            Enemy = GameObject.Find(spawnHeroes.GetNamePl2()).gameObject;
        }
        else
        {
            Enemy = GameObject.Find(spawnHeroes.GetNamePl1()).gameObject;
        }
        plSt = Enemy.GetComponent<PlayerStatus>();
        animatorPlayer = transform.parent.GetComponent<Animator>();
    }
    public void endUlta()
    {
        animatorPlayer.SetBool("ulta", false);
        gameObject.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null && collision.name == Enemy.name
                    && !collision.isTrigger && flag)
        {
            flag = false;
            plSt.TakeDamage(4);
            Invoke("sFlag1", 0.2f);
        }
    }

    private void sFlag1()
    {
        flag = true;
    }
}
