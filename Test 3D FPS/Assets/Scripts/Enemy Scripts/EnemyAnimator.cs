using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour {

    private Animator anim;

	void Awake () 
    {
        anim = GetComponent<Animator>();	
	}

    public void Sleep(bool sleep)
    {
        anim.SetBool("Sleep", sleep);
    }

    public void Walk(bool walk) {
        anim.SetBool("Walk", walk);
    }

    public void Run(bool run) {
        anim.SetBool("Run", run);
    }

    public void Attack() {
        anim.SetTrigger("Attack");
    }
    public void JumpAttack()
    {
        anim.SetTrigger("JumpAttack");
    }
    public void BackAttack()
    {
        anim.SetTrigger("Back Attack");
    }
    public void RightAttack()
    {
        anim.SetTrigger("Right Attack");
    }
    public void LeftAttack()
    {
        anim.SetTrigger("Left Attack");
    }
} // class































