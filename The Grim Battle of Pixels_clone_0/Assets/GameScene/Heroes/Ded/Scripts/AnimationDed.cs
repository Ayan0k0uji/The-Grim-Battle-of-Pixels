using UnityEngine;
using System.Collections;

public class AnimationDed : AnimationAbstract
{
    private Animator animator;
    private Animator animatorCepi;
    private Animator animatorPepel;
    private Rigidbody2D rb;
    private PlayerStatus plSt;
    private BoxCollider2D box;
    private bool pl;
    private bool flagAbility = true;
    private float time = 0;
    private Transform UltaPosition;
    private bool flag = true;



    private void Start()
    {

        box = GetComponent<BoxCollider2D>();
        animatorCepi = gameObject.transform.GetChild(1).GetComponent<Animator>();
        animatorPepel = gameObject.transform.GetChild(0).GetComponent<Animator>();
        plSt = transform.parent.gameObject.GetComponent<PlayerStatus>();
        if (transform.parent.gameObject.name == "Player1")
            pl = true;
        else
            pl = false;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("top_kick") && !animator.GetCurrentAnimatorStateInfo(0).IsName("bottom_kick"))
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

                if (Input.GetAxisRaw("Ability1").Equals(1) && flagAbility)
                    animator.SetBool("ability", true);
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

                if (Input.GetAxisRaw("Ability2").Equals(1) && flagAbility)
                    animator.SetBool("ability", true);
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

    public void sdgujdsv()
    {
        if (gameObject.transform.localScale.x == -1)
        {
            Vector3 theScale = gameObject.transform.GetChild(0).GetComponent<Transform>().localScale;
            theScale.x *= -1;
            gameObject.transform.GetChild(0).GetComponent<Transform>().localScale = theScale;
        }
        animatorPepel.SetBool("Death", true);
    }

    public void sdgujdsv1()
    {
        if (gameObject.transform.localScale.x == -1)
        {
            Vector3 theScale = gameObject.transform.GetChild(0).GetComponent<Transform>().localScale;
            theScale.x *= -1;
            gameObject.transform.GetChild(0).GetComponent<Transform>().localScale = theScale;
        }
        animatorPepel.SetBool("Death", false);
    }

    public void activCepi()
    {
        gameObject.transform.GetChild(1).gameObject.SetActive(true);

    }
}
