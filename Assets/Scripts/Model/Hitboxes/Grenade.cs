using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

public class Grenade : ProjectileInput
{
	private	Vector3		newDirection;
	private float 		timer;
	private Vector3 	target;
	
	void Start()
	{
		this.newDirection = Vector3.zero;
		this.timer = 0f;
	}
	
	protected override void Execute(){
		this.ReCenter();
		if(timer > 0.3f && timer < 0.6f)
		{
			this.transform.Translate(new Vector3(0.03f, -0.1f, 0).normalized * speed * Time.deltaTime);			
			speed = speed * 1.25f;
		}
		else{
			this.transform.position += direction;
		}

		timer += Time.deltaTime;
	}
}

