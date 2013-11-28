using UnityEngine;
using System.Collections;
using FightGame;


//regular melee - down
namespace FightGame{
	public class PatriotV_ExplosivePunch : Attack_Melee {
		public PatriotV_ExplosivePunch(string animationName, A_Fighter attackOwner, float animationSpeed = 1.0f) : base(animationName, animationSpeed, attackOwner){
			this.AddInstruction(
				new JointHitBoxInstruction(
					"FK_R_hand_jnt",
					attackOwner,
					1.0f,
					2.0f,
					0.5f,
					0.8f,
					new Vector3(0.2f,0f,0),
					new Vector3(0.0f,0f,0)
				)
			);
		}		
	}
}
