using System.Collections;
using UnityEngine;
using System;

public class Hilka : MonoBehaviour
{
    private Animator ani;
    private BoxCollider2D box;
    private SpriteRenderer sprite;
    System.Random rnd = new System.Random();
    private int timeSpawn = 1;
    private int hp = 20;
    private int n = 0;
    private string Player1;
    private string Player2;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
        Player1 = GameObject.Find("Player1").transform.GetChild(0).name;
        Player2 = GameObject.Find("Player2").transform.GetChild(0).name;
        sprite.enabled = false;
        box.enabled = false;
        n = rnd.Next() % 6;
        switch (n)
        {
            case 0:
                transform.position = new Vector2(-2.845f, -1.688f);
                break;
            case 1:
                transform.position = new Vector2(-3.785f, -5.41f);
                break;
            case 2:
                transform.position = new Vector2(-13f, -2.31f);
                break;
            case 3:
                transform.position = new Vector2(2.845f, -1.688f);
                break;
            case 4:
                transform.position = new Vector2(3.785f, -5.41f);
                break;
            case 5:
                transform.position = new Vector2(13f, -2.31f);
                break;
        }
        Invoke("HilkaSpawn", timeSpawn);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == Player1 || collision.name == Player2)
        {
            collision.transform.parent.gameObject.GetComponent<PlayerStatus>().Hill(hp);
            StartCoroutine(Hilka1());
        }
    }

    IEnumerator Hilka1()
    {
        box.enabled = false;
        ani.SetBool("HilkaFly", true);
        yield return new WaitForSeconds(0.6f);
        sprite.enabled = false;
        n = rnd.Next() % 6;
        switch (n)
        {
            case 0:
                transform.position = new Vector2(-2.845f, -1.688f);
                break;
            case 1:
                transform.position = new Vector2(-3.785f, -5.41f);
                break;
            case 2:
                transform.position = new Vector2(-13f, -2.31f);
                break;
            case 3:
                transform.position = new Vector2(2.845f, -1.688f);
                break;
            case 4:
                transform.position = new Vector2(3.785f, -5.41f);
                break;
            case 5:
                transform.position = new Vector2(13f, -2.31f);
                break;
        }
        Invoke("HilkaSpawn", timeSpawn);
    }

    public void HilkaSpawn()
    {
        ani.SetBool("HilkaFly", false);
        sprite.enabled = true;
        box.enabled = true;
    }
}