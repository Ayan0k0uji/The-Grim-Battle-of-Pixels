using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptShOnline : MonoBehaviour
{
    private Animator animator;
    public void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void onActiv()
    {
        animator.SetBool("shit", false);
        gameObject.SetActive(false);
    }
}