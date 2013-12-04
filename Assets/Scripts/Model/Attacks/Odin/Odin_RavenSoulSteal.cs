using UnityEngine;
using System.Collections;
using FightGame;

//unique attack - down
namespace FightGame{
	public class Odin_RavenSoulSteal : Attack_Projectile {
		public Odin_RavenSoulSteal(string animationName, A_Fighter attackOwner, float animationSpeed = 1.0f) : base(animationName, animationSpeed, attackOwner){
					
			ProjectileHitBoxInstruction hitbox1 = new ProjectileHitBoxInstruction (
				                                      "Amaterasu_projectile", 		// projectile name
				                                      "l_ball_jnt", 					// starting joint
				                                      new Vector3 (0, 1f, 0), 			// direction
				                                      7.0f, 							// speed
				                                      attackOwner, 					// A_fighter
				                                      2.0f, 							// radius
				                                      4.0f, 							// damage
				                                      0.1f, 							// startTime
				                                      0.7f,							// endTime
				                                      new Vector3 (-3.0f, 0.2f, 0.0f),	// offset
				                                      new Vector3 (0.0f, 0.0f, 0.0f)	// movement
			                                      );
			hitbox1.onStartSound = GameManager.Sounds.Odin_RavenSoulSteel;
			this.AddInstruction (hitbox1);

			this.AddInstruction(new ProjectileHitBoxInstruction(
				"Amaterasu_projectile", 		// projectile name
				"l_ball_jnt", 					// starting joint
				new Vector3(0, 1f, 0), 			// direction
				7.0f, 							// speed
				attackOwner, 					// A_fighter
				2.0f, 							// radius
				4.0f, 							// damage
				0.2f, 							// startTime
				0.8f,							// endTime
				new Vector3(-3.0f, 0.2f, 0.0f),	// offset
				new Vector3(0.0f, 0.0f, 0.0f)	// movement
				));
			this.AddInstruction(new ProjectileHitBoxInstruction(
				"Amaterasu_projectile", 		// projectile name
				"l_ball_jnt", 					// starting joint
				new Vector3(0, 1f, 0), 			// direction
				7.0f, 							// speed
				attackOwner, 					// A_fighter
				2.0f, 							// radius
				4.0f, 							// damage
				0.3f, 							// startTime
				0.9f,							// endTime
				new Vector3(-3.0f, 0.2f, 0.0f),	// offset
				new Vector3(0.0f, 0.0f, 0.0f)	// movement
				));
			/*//flame clone at different Z Axis
			this.AddInstruction(new ProjectileHitBoxInstruction(
				"Amaterasu_projectile", 		// projectile name
				"l_ball_jnt", 					// starting joint
				new Vector3(0, 1f, 0), 			// direction
				7.0f, 							// speed
				attackOwner, 					// A_fighter
				1.0f, 							// radius
				0.0f, 							// damage
				0.1f, 							// startTime
				0.7f,							// endTime
				new Vector3(-3.0f, 0.2f, -1.0f),	// offset
				new Vector3(0.0f, 0.0f, 0.0f)	// movement
				));
			this.AddInstruction(new ProjectileHitBoxInstruction(
				"Amaterasu_projectile", 		// projectile name
				"l_ball_jnt", 					// starting joint
				new Vector3(0, 1f, 0), 			// direction
				7.0f, 							// speed
				attackOwner, 					// A_fighter
				1.0f, 							// radius
				0.0f, 							// damage
				0.2f, 							// startTime
				0.8f,							// endTime
				new Vector3(-3.0f, 0.2f, -1.0f),	// offset
				new Vector3(0.0f, 0.0f, 0.0f)	// movement
				));
			this.AddInstruction(new ProjectileHitBoxInstruction(
				"Amaterasu_projectile", 		// projectile name
				"l_ball_jnt", 					// starting joint
				new Vector3(0, 1f, 0), 			// direction
				7.0f, 							// speed
				attackOwner, 					// A_fighter
				1.0f, 							// radius
				0.0f, 							// damage
				0.3f, 							// startTime
				0.9f,							// endTime
				new Vector3(-3.0f, 0.2f, -1.0f),	// offset
				new Vector3(0.0f, 0.0f, 0.0f)	// movement
				));*/
		}	
	}
}