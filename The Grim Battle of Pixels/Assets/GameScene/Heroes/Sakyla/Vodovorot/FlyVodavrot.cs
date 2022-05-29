using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyVodavrot : MonoBehaviour
{
    private SpawnHeroes spawnHeroes;
    private float speed = 3000f;
    private Rigidbody2D _body;
    private GameObject enemy;
    private GameObject player;
    private PlayerStatus plStEnemy;
    private Animator ani;
    private Animator aniPlayer;
    private bool flag = true;

    private void Start()
    {
        spawnHeroes = Camera.main.GetComponent<SpawnHeroes>();

        ani = GetComponent<Animator>();
        _body = GetComponent<Rigidbody2D>();

        if (transform.parent.gameObject.name == spawnHeroes.GetNamePl1())
        {
            enemy = GameObject.Find(spawnHeroes.GetNamePl2());
            player = GameObject.Find(spawnHeroes.GetNamePl1());
        }
        else
        {
            enemy = GameObject.Find(spawnHeroes.GetNamePl1());
            player = GameObject.Find(spawnHeroes.GetNamePl2());
        }

        aniPlayer = player.GetComponent<Animator>();
        plStEnemy = enemy.GetComponent<PlayerStatus>();
        Vector2 movement = Vector2.right * speed * Time.deltaTime * player.GetComponent<Transform>().localScale.x;
        _body.velocity = movement;
        transform.parent = null;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == enemy.name && !collision.isTrigger)
        {
            plStEnemy.setJumpForce(0);
            enemy.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            aniPlayer.SetBool("ulta_med", true);
            ani.SetBool("popal", true);
            enemy.GetComponent<Rigidbody2D>().gravityScale = 0;
            plStEnemy.setSpeed(0f);

            _body.velocity = Vector2.zero;
        }
        else if (collision.name != player.name && !collision.isTrigger)
            Destroy(gameObject);
    }

    public void Damage()
    {
        plStEnemy.TakeDamage(13);
    }

    public void Podem()
    {
        enemy.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y + 0.33f, enemy.transform.position.z);
    }

    public void Destr()
    {
        aniPlayer.SetBool("ulta_med", false);
        Destroy(gameObject);
    }

    public void Inviz()
    {
        
        //enemy.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y + 1, enemy.transform.position.z);
    }

    public void Vixod()
    {
        enemy.GetComponent<Rigidbody2D>().gravityScale = 3;
        plStEnemy.setSpeed(500);
        plStEnemy.setJumpForce(15);
        /*enemy.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y + 1, enemy.transform.position.z);
        enemy.GetComponent<SpriteRenderer>().sprite = null;*/
    }
}
