using UnityEngine;
using System.Collections;
using FightGame;


//regular melee - down
namespace FightGame{
	public class PatriotV_UpperCut : Attack_Melee {
		public PatriotV_UpperCut(string animationName, A_Fighter attackOwner, float animationSpeed = 1.0f) : base(animationName, animationSpeed, attackOwner){
			this.AddInstruction(
				new JointHitBoxInstruction(
					"FK_R_hand_jnt",
					attackOwner,
					1.0f,
					2.0f,
					0.2f,
					0.4f,
					Vector3.zero,
					new Vector3(0.0f,0f,0)
				)
			);
			
			this.AddInstruction(
				new JointHitBoxInstruction(
					"FK_R_hand_jnt",
					attackOwner,
					1.0f,
					2.0f,
					0.5f,
					0.7f,
					Vector3.zero,
					new Vector3(0.0f,0f,0),
					true
				)
			);
		}		
	}
}
