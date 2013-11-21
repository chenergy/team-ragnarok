using UnityEngine;
using System.Collections;
using FightGame;


//regular/unique melee - forward
namespace FightGame{
	public class Odin_ThrustLunge : Attack_Melee {
		public Odin_ThrustLunge(string animationName, A_Fighter attackOwner, float animationSpeed = 1.0f) : base(animationName, animationSpeed, attackOwner){
			
			JointHitBoxInstruction hitbox1 = new JointHitBoxInstruction (
				                                 "spear_endpoint_gobj", 		//joint
				                                 attackOwner, 				//fighter
				                                 1.0f, 						//radius
				                                 1.0f, 						//damage
				                                 0.2f, 						//start time 
				                                 3.0f, 						//end time
				                                 Vector3.zero, 				//offset
				                                 new Vector3 (0.1f, 0, 0) 		//movement
			                                 );
			hitbox1.onStartSound = GameManager.Sounds.Odin_ThrustLunge;
			this.AddInstruction (hitbox1);

			this.AddInstruction(new JointHitBoxInstruction(
				"spear_endpoint_gobj2", 	//joint
				attackOwner, 				//fighter
				1.0f, 						//radius
				1.0f, 						//damage
				0.3f, 						//start time 
				3.0f, 						//end time
				Vector3.zero, 				//offset
				Vector3.zero 				//movement
				));
			this.AddInstruction(new JointHitBoxInstruction(
				"spear_endpoint_gobj3", 	//joint
				attackOwner, 				//fighter
				1.0f, 						//radius
				1.0f, 						//damage
				0.3f, 						//start time 
				3.0f, 						//end time
				Vector3.zero, 				//offset
				Vector3.zero 				//movement
				));
			this.AddInstruction(new JointHitBoxInstruction(
				"spear_endpoint_gobj4", 	//joint
				attackOwner, 				//fighter
				1.0f, 						//radius
				1.0f, 						//damage
				0.3f, 						//start time 
				3.0f, 						//end time
				Vector3.zero, 				//offset
				Vector3.zero 				//movement
				));
		}
	}
}
