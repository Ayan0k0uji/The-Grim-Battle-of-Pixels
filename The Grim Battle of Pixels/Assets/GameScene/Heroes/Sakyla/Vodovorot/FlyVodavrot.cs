using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyVodavrot : MonoBehaviour
{
    private SpawnHeroes spawnHeroes;
    private float speed = 3000f;                        // �������� ����������
    private Rigidbody2D _body;
    private GameObject enemy;
    private GameObject player;
    private PlayerStatus plStEnemy;
    private Animator whirlpoolAnimator;                   // �������� ����������
    private Animator playerAnimator;                     // �������� ������

    private void Start()
    {
        spawnHeroes = Camera.main.GetComponent<SpawnHeroes>();

        whirlpoolAnimator = GetComponent<Animator>();
        _body = GetComponent<Rigidbody2D>();

        if (transform.parent.gameObject.name == spawnHeroes.GetNamePl1())       // ���� ������ 1 �����
        {
            enemy = GameObject.Find(spawnHeroes.GetNamePl2());
            player = GameObject.Find(spawnHeroes.GetNamePl1());
        }
        else                                                                    // ���� ������ 2 �����
        {
            enemy = GameObject.Find(spawnHeroes.GetNamePl1());
            player = GameObject.Find(spawnHeroes.GetNamePl2());
        }

        playerAnimator = player.GetComponent<Animator>();
        plStEnemy = enemy.GetComponent<PlayerStatus>();
        Vector2 movement = Vector2.right * speed * Time.deltaTime * player.GetComponent<Transform>().localScale.x;
        _body.velocity = movement;
        transform.parent = null;
    }

    public void OnTriggerEnter2D(Collider2D collision)                          
    {
        if (collision.name == enemy.name && !collision.isTrigger)                   // ���� ������ ����� �����������
        {
            transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y + 1, enemy.transform.position.z - 1);
            plStEnemy.setJumpForce(0);
            enemy.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            playerAnimator.SetBool("ulta_med", true);
            whirlpoolAnimator.SetBool("popal", true);
            enemy.GetComponent<Rigidbody2D>().gravityScale = 0;
            plStEnemy.SetSpeed�oefficient(0);
            _body.velocity = Vector2.zero;
        }
        else if (collision.name != player.name && !collision.isTrigger)
            Destroy(gameObject);
    }

    public void Damage()
    {
        plStEnemy.TakeDamage(13);
    }

    public void EnemyLifting()                             
    {
        enemy.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y + 0.33f, enemy.transform.position.z);
    }

    public void WhirlpoolDestroy()
    {
        playerAnimator.SetBool("ulta_med", false);
        Destroy(gameObject);
    }

    public void ExitEnemyFromWhirlpool()
    {
        enemy.GetComponent<Rigidbody2D>().gravityScale = 3;
        plStEnemy.SetSpeed�oefficient(1);
        plStEnemy.setJumpForce(15);
        /*enemy.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y + 1, enemy.transform.position.z);
        enemy.GetComponent<SpriteRenderer>().sprite = null;*/
    }
}
