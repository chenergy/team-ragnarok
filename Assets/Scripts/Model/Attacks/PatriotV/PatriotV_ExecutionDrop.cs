using UnityEngine;
using System.Collections;
using FightGame;


//regular melee - down
namespace FightGame{
	public class PatriotV_ExecutionDrop : Attack_Melee {
		public PatriotV_ExecutionDrop(string animationName, A_Fighter attackOwner, float animationSpeed = 1.0f) : base(animationName, animationSpeed, attackOwner){
			this.AddInstruction(
				new JointHitBoxInstruction(
					"FK_R_hand_jnt",
					attackOwner,
					1.0f,
					2.0f,
					0.5f,
					0.8f,
					Vector3.zero,
					new Vector3(0.0f,0.0f,0),
					true
				)
			);				
			
			this.AddInstruction(
				new JointHitBoxInstruction(
					"FK_L_hand_jnt",
					attackOwner,
					0.0f,
					0.0f,
					0.4f,
					0.6f,
					Vector3.zero,
					new Vector3(0.35f,0f,0),
					true
				)
			);
		}		
	}
}
