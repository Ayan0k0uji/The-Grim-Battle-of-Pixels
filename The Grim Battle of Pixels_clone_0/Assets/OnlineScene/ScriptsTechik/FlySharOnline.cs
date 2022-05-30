using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlySharOnline : MonoBehaviour
{
    private SpawnHeroes spawnHeroes;
    private float speed = 800f;
    private Rigidbody2D _body;
    private GameObject enemy;
    private GameObject player;
    private PlayerStatus plSt;
    private Animator ani;
    private float deltaY, deltaX;
    private bool pl = false;

    private void Start()
    {
        spawnHeroes = Camera.main.GetComponent<SpawnHeroes>();
        ani = GetComponent<Animator>();
        _body = GetComponent<Rigidbody2D>();
        player = transform.parent.gameObject;
        if (player.name == spawnHeroes.GetNamePl1())
        {
            pl = true;
            enemy = GameObject.Find(spawnHeroes.GetNamePl2());
        }
        else
            enemy = GameObject.Find(spawnHeroes.GetNamePl1());

        plSt = enemy.GetComponent<PlayerStatus>();
        gameObject.transform.parent = null;
    }

    private void FixedUpdate()
    {
        if (pl)
        {
            ani.SetFloat("Horizontal", Input.GetAxis("Horizontal1"));
            ani.SetFloat("Vertical", Input.GetAxis("Jump1"));
            deltaX = Input.GetAxis("Horizontal1") * speed * Time.deltaTime;
            deltaY = Input.GetAxis("Jump1") * speed * Time.deltaTime;
            _body.velocity = new Vector2(deltaX, deltaY);
        }
        else
        {
            ani.SetFloat("Horizontal", Input.GetAxis("Horizontal2"));
            ani.SetFloat("Vertical", Input.GetAxis("Jump2"));
            deltaX = Input.GetAxis("Horizontal2") * speed * Time.deltaTime;
            deltaY = Input.GetAxis("Jump2") * speed * Time.deltaTime;
            _body.velocity = new Vector2(deltaX, deltaY);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == enemy.name && !collision.isTrigger)
        {
            plSt.TakeDamage(80);
            player.GetComponent<Animator>().SetBool("ultaEnd", true);
            Destroy(transform.gameObject);
        }
        else if (collision.name != player.name && !collision.isTrigger)
        {
            player.GetComponent<Animator>().SetBool("ultaEnd", true);
            Destroy(transform.gameObject);
        }
    }
}
