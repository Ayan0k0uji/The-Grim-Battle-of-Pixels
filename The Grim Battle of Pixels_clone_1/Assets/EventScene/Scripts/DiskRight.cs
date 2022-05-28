using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskRight : MonoBehaviour
{
    private Transform transformObject;
    private PlayerStatus plSt1;
    private PlayerStatus plSt2;




    // Start is called before the first frame update
    void Start()
    {
        transformObject = GetComponent<Transform>();
        plSt1 = GameObject.Find("Player1").transform.GetComponent<PlayerStatus>();
        plSt2 = GameObject.Find("Player2").transform.GetComponent<PlayerStatus>();
        StartCoroutine("DiskiKrytitsi");
    }

    IEnumerator DiskiKrytitsi()
    {
        for (int i = 0; i < 110; i++)
        {
            transformObject.position = new Vector3(transformObject.position.x - 0.1f, transformObject.position.y, transformObject.position.z);
            yield return new WaitForSeconds(0.1f);
        }
        for (int i = 0; i < 110; i++)
        {
            transformObject.position = new Vector3(transformObject.position.x + 0.1f, transformObject.position.y, transformObject.position.z);
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null && !collision.isTrigger && collision.transform.parent.transform.name == "Player1")
            plSt1.TakeDamage(100);
        if (collision != null && !collision.isTrigger && collision.transform.parent.transform.name == "Player2")
            plSt2.TakeDamage(100);
    }
}
