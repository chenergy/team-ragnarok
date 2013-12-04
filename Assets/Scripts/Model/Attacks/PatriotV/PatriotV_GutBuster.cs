using UnityEngine;
using System.Collections;
using FightGame;


//regular melee - down
namespace FightGame{
	public class PatriotV_GutBuster : Attack_Melee {
		public PatriotV_GutBuster(string animationName, A_Fighter attackOwner, float animationSpeed = 1.0f) : base(animationName, animationSpeed, attackOwner){
			JointHitBoxInstruction attack1 = new JointHitBoxInstruction (
				                                 "FK_R_hand_jnt",
				                                 attackOwner,
				                                 1.0f,
				                                 3.0f,
				                                 0.5f,
				                                 0.7f,
				                                 Vector3.zero,
				                                 new Vector3 (0.0f, 0f, 0)
			                                 );
			attack1.onStartSound = GameManager.Sounds.PatriotV_GutBuster;
			this.AddInstruction (attack1);
			
			this.AddInstruction(
				new JointHitBoxInstruction(
					"FK_R_hand_jnt",
					attackOwner,
					1.0f,
					3.0f,
					0.8f,
					1.0f,
					Vector3.zero,
					new Vector3(0.0f,0f,0)
				)
			);
			
			this.AddInstruction(
				new JointHitBoxInstruction(
					"FK_R_hand_jnt",
					attackOwner,
					1.0f,
					8.0f,
					1.1f,
					1.3f,
					Vector3.zero,
					new Vector3(0.0f,0f,0)
				)
			);
		}		
	}
}
