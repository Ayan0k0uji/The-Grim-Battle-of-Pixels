using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlySnot : MonoBehaviour
{
    private SpawnHeroes spawnHeroes;
    private float speed = 3000f;
    private Rigidbody2D _body;
    private GameObject enemy;
    private GameObject player;
    private PlayerStatus plStEnemy;
    private SpriteRenderer spriteRenderer;          // компонент спрайта слизи
    private Animator snotAnimator;
    private int damage = 1;                         // множитель урона слизи

    private void Start()
    {
        spawnHeroes = Camera.main.GetComponent<SpawnHeroes>();

        snotAnimator = GetComponent<Animator>();
        _body = GetComponent<Rigidbody2D>();
        player = transform.parent.gameObject;

        if (player.name == spawnHeroes.GetNamePl1())
            enemy = GameObject.Find(spawnHeroes.GetNamePl2());
        else
            enemy = GameObject.Find(spawnHeroes.GetNamePl1());

        plStEnemy = enemy.GetComponent<PlayerStatus>();
        spriteRenderer = enemy.GetComponent<SpriteRenderer>();
        Vector2 movement = Vector2.right * speed * Time.deltaTime * player.GetComponent<Transform>().localScale.x;
        _body.velocity = movement;
        gameObject.transform.parent = null;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == enemy.name && !collision.isTrigger)
        {
            plStEnemy.TakeDamage(40 / damage);
            enemy.GetComponent<PlayerStatus>().setSpeed(200);
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine("PoisonDamage");
        }
        else if (damage < 2 && collision.name != player.name && !collision.isTrigger)
        {
            damage += 1;
            _body.velocity = -1 * _body.velocity;
            snotAnimator.SetBool("FlySnot", true);
        }
        else if (collision.name != player.name && !collision.isTrigger)
            Destroy(gameObject);
    }

    

    IEnumerator PoisonDamage()
    {
        plStEnemy.setFlagPoison(true);
        spriteRenderer.color = new Color(0.7f, 0.4f, 0.6f, 1f);
        for (int i = 0; i < 10; i++)
        {
            plStEnemy.TakeDamage(3);
            yield return new WaitForSeconds(0.5f);
        }
        plStEnemy.setFlagPoison(false);
        spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
        enemy.GetComponent<PlayerStatus>().setSpeed(500);
        Destroy(gameObject);
    }
}