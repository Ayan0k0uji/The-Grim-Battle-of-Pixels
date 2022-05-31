using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DdBusterScript : MonoBehaviour
{
    private SpawnHeroes spawnHeroes;
    private BattleAbstract player1Battle, player2Battle;
    private Animator animatorDd;

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
            /*if (collision.name == spawnHeroes.GetNamePl1())
                //player1Battle*/
        }
    }
}
