using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Amaterasu_DawnFirstLight: Attack_Melee
	{	
		//knee kick 
		public Amaterasu_DawnFirstLight(string animationName, A_Fighter attackOwner, float animationSpeed = 1.0f) : base(animationName, animationSpeed, attackOwner)
		{
			
			JointHitBoxInstruction hitbox1 = new JointHitBoxInstruction (
				                                 "r_knee_jnt", 				
				                                 attackOwner, 					// fighter
				                                 1.5f, 							// radius
				                                 1.5f,							// damage
				                                 0.3f, 							// startTime
				                                 1.0f,  							// endTime
				                                 new Vector3 (0.0f, 0.0f, 0.0f), 	// offset
				                                 new Vector3 (0.05f, 0.0f, 0.0f)
			                                 );
			hitbox1.onStartSound = GameManager.Sounds.Ama_DawnFirstLight;
			this.AddInstruction (hitbox1);
			recoilStrength = 2.0f;
		}			
	}
}

