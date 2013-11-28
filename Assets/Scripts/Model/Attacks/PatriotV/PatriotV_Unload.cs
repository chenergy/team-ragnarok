using UnityEngine;
using System.Collections;
using FightGame;


//regular melee - down
namespace FightGame{
	public class PatriotV_Unload : Attack_Melee {
		public PatriotV_Unload(string animationName, A_Fighter attackOwner, float animationSpeed = 1.0f) : base(animationName, animationSpeed, attackOwner){
			//1
			this.AddInstruction(
				new JointHitBoxInstruction(
					"FK_L_hand_jnt", 					// joint
					attackOwner, 					// fighter
					1.0f, 							// radius
					2.0f,							// damage
					0.35f, 							// startTime
					0.6f,  							// endTime
					Vector3.zero,					// offset
					new Vector3( 0.0f, 0, 0 )		// movement				
				)
			);
			//2
			this.AddInstruction(
				new JointHitBoxInstruction(
					"FK_R_hand_jnt",
					attackOwner, 					// fighter
					1.0f, 							// radius
					2.0f,							// damage
					1.2f, 							// startTime
					1.5f,  							// endTime
					Vector3.zero,					// offset
					new Vector3( 0.0f, 0, 0 )		// movement				
				)
			);
			
			//3
			this.AddInstruction(
				new JointHitBoxInstruction(
					"FK_L_hand_jnt", 					
					attackOwner, 					// fighter
					1.0f, 							// radius
					2.0f,							// damage
					2.0f, 							// startTime
					2.6f,  							// endTime
					Vector3.zero,					// offset
					new Vector3( 0.0f, 0, 0 )		// movement				
				)
			);
			
			//4
			this.AddInstruction(
				new JointHitBoxInstruction(
					"FK_R_hand_jnt", 					// joint
					attackOwner, 					// fighter
					1.0f, 							// radius
					2.0f,							// damage
					3.1f, 							// startTime
					3.6f,  							// endTime
					new Vector3(1,0,0),					// offset
					new Vector3( 0.0f, 0, 0 ),		// movement	
					true							//knockdown
				)
			);
			
		}		
	}
}
