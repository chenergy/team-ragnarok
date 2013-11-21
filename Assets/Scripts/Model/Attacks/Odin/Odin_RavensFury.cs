﻿using UnityEngine;
using System.Collections;
using FightGame;


//unique range - none
namespace FightGame{
	public class Odin_RavensFury : Attack_Projectile {
		public Odin_RavensFury(string animationName, A_Fighter attackOwner, float animationSpeed = 1.0f) : base(animationName, animationSpeed, attackOwner){			

			ProjectileHitBoxInstruction hitbox1 = new ProjectileHitBoxInstruction (
				                                      "odin_ravens", 		// projectile name
				                                      "r_wrist_jnt",				
				                                      new Vector3 (1.0f, 0.0f, 0.0f), 	// direction
				                                      10.0f, 							// speed
				                                      attackOwner, 					// A_fighter
				                                      3.0f, 							// radius
				                                      1.0f, 							// damage
				                                      0.2f, 							// startTime
				                                      0.8f,							// endTime
				                                      new Vector3 (0.0f, 0.0f, 0.0f),// offset
				                                      new Vector3 (0.0f, 0.0f, 0.0f)	// movement
			                                      );
			hitbox1.onStartSound = GameManager.Sounds.Odin_RavenFury;
			this.AddInstruction (hitbox1);
		}		
	}
}
