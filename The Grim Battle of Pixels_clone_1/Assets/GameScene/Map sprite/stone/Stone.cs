using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    private Animator ani;
    private string Player1;
    private string Player2;

    public void Start()
    {
        ani = GetComponent<Animator>();
        Player1 = GameObject.Find("Player1").transform.GetChild(0).name;
        Player2 = GameObject.Find("Player2").transform.GetChild(0).name;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == Player1 || collision.name == Player2)
        {
            StartCoroutine(CheFly());
        }
    }


    IEnumerator CheFly()
    {
        ani.SetBool("stone", true);
        yield return new WaitForSeconds(0.1f);
        ani.SetBool("stone", false);                    
    }
}
