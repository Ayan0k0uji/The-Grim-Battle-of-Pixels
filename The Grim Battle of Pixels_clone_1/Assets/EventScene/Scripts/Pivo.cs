using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivo : MonoBehaviour
{
    private Transform transform1;
    private PlayerStatus plSt1;
    private PlayerStatus plSt2;


    // Start is called before the first frame update
    void Start()
    {
        plSt1 = GameObject.Find("Player1").transform.GetComponent<PlayerStatus>();
        plSt2 = GameObject.Find("Player2").transform.GetComponent<PlayerStatus>();
        transform1 = GetComponent<Transform>();
        StartCoroutine("PivoTechet");
    }

    IEnumerator PivoTechet()
    {
        for (int i = 0; i < 125; i++)
        {
            transform1.position = new Vector3(transform1.position.x, transform.position.y + 0.05f, transform.position.z);   
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(5f);
        for (int i = 0; i < 125; i++)
        {
            transform1.position = new Vector3(transform1.position.x, transform.position.y - 0.05f, transform.position.z);
            yield return new WaitForSeconds(0.05f);
        }
        Destroy(gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null && !collision.isTrigger && collision.transform.parent.transform.name == "Player1")
            plSt1.TakeDamage(100);
        if (collision != null && !collision.isTrigger && collision.transform.parent.transform.name == "Player2")
            plSt2.TakeDamage(100);
    }
}
