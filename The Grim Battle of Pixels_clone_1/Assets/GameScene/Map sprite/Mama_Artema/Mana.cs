using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    private Animator ani;
    private BoxCollider2D box;
    private string Player1;
    private string Player2;
    private int mana = 30;
    private float timeManaSpawn = 15f;

    private void Start()
    {
        ani = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
        Player1 = GameObject.Find("Player1").transform.GetChild(0).name;
        Player2 = GameObject.Find("Player2").transform.GetChild(0).name;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == Player1 || collision.name == Player2)
        {
            collision.transform.parent.gameObject.GetComponent<PlayerStatus>().setCurrentMana(mana);
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
