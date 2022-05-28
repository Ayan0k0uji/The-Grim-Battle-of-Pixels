using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitikBiet : MonoBehaviour
{

    private PlayerStatus plSt1;
    private PlayerStatus plSt2;


    void Start()
    {
        plSt1 = GameObject.Find("Player1").transform.GetComponent<PlayerStatus>();
        plSt2 = GameObject.Find("Player2").transform.GetComponent<PlayerStatus>();
        Invoke("Destr", 7);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null && !collision.isTrigger && collision.transform.parent.transform.name == "Player1")
            plSt1.TakeDamage(100);
        if (collision != null && !collision.isTrigger && collision.transform.parent.transform.name == "Player2")
            plSt2.TakeDamage(100);
    }

    private void Destr()
    {
        Destroy(transform.parent.gameObject);
    }
}
