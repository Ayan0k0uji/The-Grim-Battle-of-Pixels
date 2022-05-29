using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private SpawnHeroes spawnHeroes;
    private GameObject enemy;
    private PlayerStatus plStEnemy;
    private void Start()
    {
        spawnHeroes = Camera.main.GetComponent<SpawnHeroes>();
        
        if (transform.parent.name == spawnHeroes.GetNamePl1())
            enemy = GameObject.Find(spawnHeroes.GetNamePl2());
        else
            enemy = GameObject.Find(spawnHeroes.GetNamePl1());

        plStEnemy = enemy.GetComponent<PlayerStatus>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == enemy.name && !collision.isTrigger)
        {
            plStEnemy.TakeDamage(20);
           
        }
    }
    void KrugOff(){
        Destroy(gameObject);
    }
}
