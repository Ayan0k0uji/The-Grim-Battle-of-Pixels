using UnityEngine;

public class BattleTehnik : MonoBehaviour
{
    private SpawnHeroes spawnHeroes;
    private Animator animator;
    private PlayerStatus plStEnemy;
    private PlayerStatus plSt;
    private GameObject Enemy;
    private bool check_kick;
    private bool botKick, topKick;                  // показывает можно ли бить тем или иным ударом
    private bool bot_kick = false, t_kick = false;  // проверяет произошел удар или нет
    private int bot_damage = 14, top_damage = 17;   

    void Start()
    {
        spawnHeroes = Camera.main.GetComponent<SpawnHeroes>();
        animator = GetComponent<Animator>();
        plSt = GetComponent<PlayerStatus>();
        if (name == spawnHeroes.GetNamePl1())
        {
            Enemy = GameObject.Find(spawnHeroes.GetNamePl2()).gameObject; 
        }
        else
        {
            Enemy = GameObject.Find(spawnHeroes.GetNamePl1()).gameObject;
        }
        plStEnemy = Enemy.GetComponent<PlayerStatus>();
    }



    void Update()
    {
        if (check_kick)
            topKick = botKick = true;
        check_kick = !animator.GetCurrentAnimatorStateInfo(0).IsName("bottom_kick")
                            && !animator.GetCurrentAnimatorStateInfo(0).IsName("top_kick");
    }

    void FixedUpdate()
    {
        if (botKick)
        {
            bot_kick = true;
            botKick = false;
        }
        else if (topKick)
        {
            t_kick = true;
            topKick = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (bot_kick && collision != null && collision.name == Enemy.name
                    && animator.GetCurrentAnimatorStateInfo(0).IsName("bottom_kick") && !collision.isTrigger)       // если попал нижним ударом
        {
            plSt.setCurrentMana(5);
            plStEnemy.TakeDamage(bot_damage);
            bot_kick = false;
        }
        if (t_kick && collision != null && collision.name == Enemy.name
                    && animator.GetCurrentAnimatorStateInfo(0).IsName("top_kick") && !collision.isTrigger)          // ели попал верхним ударом
        {
            plSt.setCurrentMana(5);
            plStEnemy.TakeDamage(top_damage);
        }
    }
}





