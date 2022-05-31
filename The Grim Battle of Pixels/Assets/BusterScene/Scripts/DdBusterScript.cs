using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DdBusterScript : MonoBehaviour
{
    private SpawnHeroes spawnHeroes;
    private BattleAbstract player1Battle, player2Battle;
    private Animator animatorDd;
    private int timeBuster = 10;

    void Start()
    {
        spawnHeroes = Camera.main.GetComponent<SpawnHeroes>();
        player1Battle = GameObject.Find(spawnHeroes.GetNamePl1()).GetComponent<BattleAbstract>();
        player2Battle = GameObject.Find(spawnHeroes.GetNamePl2()).GetComponent<BattleAbstract>();
        animatorDd = GetComponent<Animator>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == spawnHeroes.GetNamePl1() || collision.name == spawnHeroes.GetNamePl2() && !collision.isTrigger)
        {
            animatorDd.SetBool("pincing", true);

            if (collision.name == spawnHeroes.GetNamePl1())
            {
                player1Battle.SetDamageCoefficient(2, timeBuster);

            }
            else
            {
                player2Battle.SetDamageCoefficient(2, timeBuster);

            }
        }
    }

    public void OnDestr()
    {
        Destroy(gameObject);
    }
}
