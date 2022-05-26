using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyShar : MonoBehaviour
{
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
        ani = GetComponent<Animator>();
        _body = GetComponent<Rigidbody2D>();
        player = transform.parent.gameObject;
        if (transform.parent.gameObject.transform.parent.gameObject.name == "Player1")
        {
            pl = true;
            enemy = GameObject.Find("Player2").transform.GetChild(0).gameObject;
        }
        else
            enemy = GameObject.Find("Player1").transform.GetChild(0).gameObject;
        plSt = enemy.transform.parent.gameObject.GetComponent<PlayerStatus>();
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
