using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoritFlyRight : MonoBehaviour
{
    private Transform transform1;
    private Animator animator;
    private PlayerStatus plSt1;
    private PlayerStatus plSt2;
    private bool flag = true;

    void Start()
    {
        plSt1 = GameObject.Find("Player1").transform.GetComponent<PlayerStatus>();
        plSt2 = GameObject.Find("Player2").transform.GetComponent<PlayerStatus>();
        animator = GetComponent<Animator>();
        transform1 = GetComponent<Transform>();
        StartCoroutine("MeteorFly");
    }
    IEnumerator MeteorFly()
    {
        for (int i = 0; flag; i++)
        {
            transform1.position = new Vector3(transform1.position.x + 0.2f, transform.position.y - 0.2f, transform.position.z);
            yield return new WaitForSeconds(0.02f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && !collision.isTrigger && collision.transform.parent.transform.name == "Player1")
        {
            plSt1.TakeDamage(100);
            Destroy(gameObject);
        }
        if (collision != null && !collision.isTrigger && collision.transform.parent.transform.name == "Player2")
        {
            plSt2.TakeDamage(100);
            Destroy(gameObject);
        }
        if (!collision.isTrigger && collision.tag == "Ground")
        {
            animator.SetBool("Death", true);
            flag = false;
        }

    }


    public void Des()
    {
        Destroy(gameObject);
    }
}
