using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    private SpawnHeroes spawnHeroes;
    private Animator ani;
    private BoxCollider2D box;
    private string Player1;
    private string Player2;
    private int mana = 100;
    private float timeManaSpawn = 1f;

    private void Start()
    {
        spawnHeroes = Camera.main.GetComponent<SpawnHeroes>();
        ani = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
        Player1 = spawnHeroes.GetNamePl1();
        Player2 = spawnHeroes.GetNamePl2();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.name == Player1 || collision.name == Player2) && !collision.isTrigger)
        {
            collision.GetComponent<PlayerStatus>().setCurrentMana(mana);
            StartCoroutine(BatFly());
        }
    }

    IEnumerator BatFly()
    {
        box.enabled = false;
        ani.SetBool("mana", true);
        yield return new WaitForSeconds(timeManaSpawn);
        box.enabled = true;
        ani.SetBool("mana", false);
    }
}
