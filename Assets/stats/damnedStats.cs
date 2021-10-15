using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damnedStats : CharacterStat
{
    Animator animator;
    public override void Awake()
    {
        base.Awake();
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("isDying", false);
    }
    public override void Die()
    {
        //base.Die();
        animator.SetBool("isDying", true);
        Destroy(gameObject, 3f);
    }
}
