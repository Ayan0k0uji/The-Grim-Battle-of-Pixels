using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorSakylaOnline : AnimationAbstract
{
    private SpawnHeroes spawnHeroes;
    private Animator animator;
    [SerializeField] GameObject vodka;
    [SerializeField] GameObject vodavrot;
    private Rigidbody2D rb;
    private BoxCollider2D box;
    private PlayerStatus plSt;
    private bool pl;
    private bool flagAbility = true;
    private float time = 0;
    private bool flag = true;


    private void Start()
    {
        spawnHeroes = Camera.main.GetComponent<SpawnHeroes>();
        box = GetComponent<BoxCollider2D>();
        plSt = GetComponent<PlayerStatus>();
        if (name == spawnHeroes.GetNamePl1())
            pl = true;
        else
            pl = false;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("top_kick") && !animator.GetCurrentAnimatorStateInfo(0).IsName("botton_kick"))
            box.enabled = false;
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("ulta"))
            plSt.nullMana();
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("ability") && flag)
        {
            flagAbility = false;
            StartCoroutine("timeAbility");
            flag = false;

        }
        if (pl)
        {
            if (!plSt.getSquat())
            {
                animator.SetBool("squat", false);

                if (Input.GetAxisRaw("Kick1").Equals(-1))
                {
                    animator.SetBool("top_kick", true);
                    box.enabled = true;
                }
                else
                    animator.SetBool("top_kick", false);

                if (Input.GetAxisRaw("Kick1").Equals(1))
                {
                    animator.SetBool("bottom_kick", true);
                    box.enabled = true;
                }
                else
                    animator.SetBool("bottom_kick", false);

                if (Input.GetAxisRaw("Ability1").Equals(-1) && plSt.getCurrentMana() == 100)
                {
                    
                    animator.SetBool("ulta", true);
                }
                else
                    animator.SetBool("ulta", false);

                if (Input.GetAxisRaw("Ability1").Equals(1) && flagAbility)
                {
                    animator.SetBool("ability", true);
                    Vodka();
                    transform.position = new Vector3(transform.position.x + 4 * transform.localScale.x, transform.position.y, transform.position.z);
                    
                }
                else
                    animator.SetBool("ability", false);

                animator.SetFloat("speed_X", Mathf.Abs(plSt.getDeltaX()));


                animator.SetFloat("velocity_Y", rb.velocity.y);
            }
            else
                animator.SetBool("squat", true);
        }
        else
        {
            if (!plSt.getSquat())
            {
                animator.SetBool("squat", false);

                if (Input.GetAxisRaw("Kick2").Equals(-1))
                {
                    animator.SetBool("top_kick", true);
                    box.enabled = true;
                }
                else
                    animator.SetBool("top_kick", false);

                if (Input.GetAxisRaw("Kick2").Equals(1))
                {
                    animator.SetBool("bottom_kick", true);
                    box.enabled = true;
                }
                else
                    animator.SetBool("bottom_kick", false);

                if (Input.GetAxisRaw("Ability2").Equals(-1) && plSt.getCurrentMana() == 100)
                {
                    animator.SetBool("ulta", true);
                }
                else
                    animator.SetBool("ulta", false);

                if (Input.GetAxisRaw("Ability2").Equals(1) && flagAbility)
                {
                    animator.SetBool("ability", true);
                    Vodka();
                    transform.position = new Vector3(transform.position.x + 4 * transform.localScale.x, transform.position.y, transform.position.z);
                }
                else
                    animator.SetBool("ability", false);

                animator.SetFloat("speed_X", Mathf.Abs(plSt.getDeltaX()));

                animator.SetFloat("velocity_Y", rb.velocity.y);
            }
            else
                animator.SetBool("squat", true);
        }
    }

    IEnumerator timeAbility()
    {
        while (time < 9)
        {
            yield return new WaitForSeconds(0.25f);
            time += 0.25f;
        }
        time = 0;
        flagAbility = true;
        flag = true;
    }

    override
    public float getTime()
    {
        return time;
    }

    override
    public bool getFlagAbility()
    {
        return flagAbility;
    }

    public void Vodka()
    {
        GameObject sn = Instantiate(vodka, new Vector3(transform.position.x - 2 * transform.localScale.x, transform.position.y, transform.position.z), Quaternion.identity);
        sn.transform.parent = transform;
    }

    public void Vodavrot()
    {
        GameObject sn = Instantiate(vodavrot, transform.GetChild(0).position, Quaternion.identity);
        sn.transform.localScale = transform.localScale;
        sn.transform.parent = transform;
    }
}
