using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController 
{
    Animator _anim;
	public AnimationController(Animator anim)
	{
		_anim = anim;
	}
	public void AttackAnim()
	{
		_anim.SetTrigger("isAttacking");
	}
}
