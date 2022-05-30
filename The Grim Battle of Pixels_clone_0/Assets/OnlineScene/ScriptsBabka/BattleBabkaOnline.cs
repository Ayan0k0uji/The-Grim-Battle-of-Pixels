using UnityEngine;

public class BattleBabkaOnline : MonoBehaviour
{
    private SpawnHeroes spawnHeroes;
    private Animator animator;
    private PlayerStatus plStEnemy;
    private PlayerStatus myPlSt;
    private GameObject Enemy;
    private bool check_kick;
    private bool bk, tk;
    private bool bot_kick = false, t_kick = false;
    private int bot_damage = 14, top_damage = 12;

    void Start()
    {
        spawnHeroes = Camera.main.GetComponent<SpawnHeroes>();

        animator = GetComponent<Animator>();
        myPlSt = GetComponent<PlayerStatus>();
        if (name == spawnHeroes.GetNamePl1())
        {
            Enemy = GameObject.Find(spawnHeroes.GetNamePl2());
            plStEnemy = Enemy.GetComponent<PlayerStatus>();
        }
        else
        {
            Enemy = GameObject.Find(spawnHeroes.GetNamePl1());
            plStEnemy = Enemy.GetComponent<PlayerStatus>();
        }
    }



    void Update()
    {
        if (check_kick)
            tk = bk =true;
        check_kick = !animator.GetCurrentAnimatorStateInfo(0).IsName("bottom_kick")
                            && !animator.GetCurrentAnimatorStateInfo(0).IsName("top_kick");
    }

    void FixedUpdate()
    {
        if (bk)
        {
            bot_kick = true;
            bk = false;
        }
        else if (tk)
        {
            t_kick = true;
            tk = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (bot_kick && collision != null && collision.name == Enemy.name
                    && animator.GetCurrentAnimatorStateInfo(0).IsName("bottom_kick") && !collision.isTrigger)
        {
            myPlSt.setCurrentMana(5);
            plStEnemy.TakeDamage(bot_damage);
            bot_kick = false;
        }
        if (t_kick && collision != null && collision.name == Enemy.name
                    && animator.GetCurrentAnimatorStateInfo(0).IsName("top_kick") && !collision.isTrigger)
        {
            myPlSt.setCurrentMana(5);
            plStEnemy.TakeDamage(top_damage);
            t_kick = false;
        }
    }
}





