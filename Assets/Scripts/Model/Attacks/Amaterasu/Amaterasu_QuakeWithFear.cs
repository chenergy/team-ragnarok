using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Amaterasu_QuakeWithFear: Attack_Projectile
	{	
		public Amaterasu_QuakeWithFear(string animationName, A_Fighter attackOwner, float animationSpeed = 1.0f) : base(animationName, animationSpeed, attackOwner)
		{
			
			ProjectileHitBoxInstruction hitbox1 = new ProjectileHitBoxInstruction (
				                                      "Amaterasu_projectile", 		// projectile name
				                                      "l_ball_jnt",					
				                                      new Vector3 (1.0f, 0.0f, 0.0f), 	// direction
				                                      10.0f, 							// speed
				                                      attackOwner, 					// A_fighter
				                                      1.0f, 							// radius
				                                      1.0f, 							// damage
				                                      0.8f, 							// startTime
				                                      1.2f,							// endTime
				                                      new Vector3 (0.0f, 0.0f, 0.0f),	// offset
				                                      new Vector3 (0.0f, 0.0f, 0.0f)	// movement
			                                      );
			hitbox1.onStartSound = GameManager.Sounds.Ama_QuakeWithFear;
			this.AddInstruction (hitbox1);

			this.AddInstruction(new ProjectileHitBoxInstruction(
				"Amaterasu_projectile", 		// projectile name
				"l_ball_jnt",					
				new Vector3(1.0f, 0.0f, 0.0f), 	// direction
				10.0f, 							// speed
				attackOwner, 					// A_fighter
				1.0f, 							// radius
				1.0f, 							// damage
				1.1f, 							// startTime
				1.3f,							// endTime
				new Vector3(0.0f, 0.0f, 0.0f),	// offset
				new Vector3(0.0f, 0.0f, 0.0f)	// movement
				));				

		}
	}
}

