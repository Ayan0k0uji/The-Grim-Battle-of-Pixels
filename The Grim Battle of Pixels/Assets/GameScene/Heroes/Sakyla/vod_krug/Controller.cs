using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private GameObject enemy;
    private PlayerStatus plStEnemy;
    private void Start()
    {
        plStEnemy = enemy.transform.parent.gameObject.GetComponent<PlayerStatus>();
        if (transform.parent.gameObject.transform.parent.gameObject.name == "Player1")
            enemy = GameObject.Find("Player2").transform.GetChild(0).gameObject;
        else
            enemy = GameObject.Find("Player1").transform.GetChild(0).gameObject;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == enemy.name && !collision.isTrigger)
        {
            plStEnemy.TakeDamage(40);
           
        }
    }
    void KrugOff(){
        Destroy(gameObject);
    }
}
