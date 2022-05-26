using System.Collections;
using UnityEngine;

public class bab : MonoBehaviour
{
	private Animator animator;

	private void Start()
	{
		animator = GetComponent<Animator>();
		StartCoroutine(BatFly());
	}


	IEnumerator BatFly()
	{
		while (true)
		{
			animator.SetBool("Bab", true);
			yield return new WaitForSeconds(0.1f);
			animator.SetBool("Bab", false);
			yield return new WaitForSeconds(10f);
		}
	}
}
