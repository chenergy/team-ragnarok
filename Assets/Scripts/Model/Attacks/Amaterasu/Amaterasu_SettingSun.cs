using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Amaterasu_SettingSun: Attack_Melee
	{	
		//diagonal head to ground stomp kick like replaced with somersaultkick (axekick)
		public Amaterasu_SettingSun(string animationName, A_Fighter attackOwner, float animationSpeed = 1.0f) : base(animationName, animationSpeed, attackOwner)
		{
			this.AddInstruction(new JointHitBoxInstruction(
				"r_ball_jnt", 				
				attackOwner, 					// fighter
				1.5f, 							// radius
				5.0f,							// damage
				0.5f, 							// startTime
				1.0f,  							// endTime
				new Vector3(0.0f, 0.0f, 0.0f), 	// offset
				new Vector3(0.15f, 0.15f, 0.0f)
				));	
			/*
			this.AddInstruction(new JointHitBoxInstruction(
				"l_ball_jnt", 				
				attackOwner, 					// fighter
				1f, 							// radius
				7.0f,							// damage
				0.85f, 							// startTime
				1.2f,  							// endTime
				new Vector3(0.0f, 0.0f, 0.0f), 	// offset
				new Vector3(0.0f, 0.0f, 0.0f),
				true
				));	*/
		}
	}
}

