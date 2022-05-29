using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    private SpawnHeroes spawnHeroes;
    private Animator ani;
    private string Player1;
    private string Player2;

    public void Start()
    {
        spawnHeroes = Camera.main.GetComponent<SpawnHeroes>();
        ani = GetComponent<Animator>();
        Player1 = spawnHeroes.GetNamePl1();
        Player2 = spawnHeroes.GetNamePl2();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == Player1 || collision.name == Player2)
        {
            StartCoroutine(CheFly());
        }
    }


    IEnumerator CheFly()
    {
        ani.SetBool("stone", true);
        yield return new WaitForSeconds(0.1f);
        ani.SetBool("stone", false);                    
    }
}
