using UnityEngine;
using System.Collections;
using FightGame;


//regular melee - down
namespace FightGame{
	public class PatriotV_GrenadeDrop : Attack_Melee {
		public PatriotV_GrenadeDrop(string animationName, A_Fighter attackOwner, float animationSpeed = 1.0f) : base(animationName, animationSpeed, attackOwner){
			this.AddInstruction(new ProjectileHitBoxInstruction(
				"Grenade", 						// projectile name
				"FK_L_hand_jnt",				// starting joint
				new Vector3(0.05f, -0.1f, 0), 	// direction
				6.0f, 							// speed
				attackOwner, 					// A_fighter
				0.0f, 							// radius
				1.0f, 							// damage
				0.8f, 							// startTime
				5.0f,							// endTime
				new Vector3(0.0f, 0.4f, 0.0f),	// offset
				new Vector3(0.0f, 0.0f, 0.0f)	// movement
				));
			
			JointHitBoxInstruction attack1 = new JointHitBoxInstruction (
                 "FK_R_hand_jnt",
                 attackOwner,
                 2.0f,
                 2.0f,
                 1.3f,
                 1.5f,
                 new Vector3 (0.5f, 0, 0),
                 new Vector3 (0.0f, 0f, 0),
                 true
             );
			this.AddInstruction(new ProjectileHitBoxInstruction(
				"Amaterasu_projectile", 		// projectile name
				"FK_R_hand_jnt", 				// starting joint
				new Vector3(0, 1f, 0), 			// direction
				3.0f, 							// speed
				attackOwner, 					// A_fighter
				2.0f, 							// radius
				2.0f, 							// damage
				1.2f, 							// startTime
				1.5f,							// endTime
				new Vector3(-0.0f, 0.2f, 0.0f),	// offset
				new Vector3(0.0f, 0.0f, 0.0f)	// movement
				));
			attack1.onStartSound = GameManager.Sounds.PatriotV_GrenadeToss;
			this.AddInstruction (attack1);
		}		
	}
}
