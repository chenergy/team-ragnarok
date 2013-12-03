using UnityEngine;
using System.Collections;
using FightGame;


//regular melee - down
namespace FightGame{
	public class PatriotV_Jab : Attack_Melee {
		public PatriotV_Jab(string animationName, A_Fighter attackOwner, float animationSpeed = 1.0f) : base(animationName, animationSpeed, attackOwner){
			JointHitBoxInstruction attack1 = new JointHitBoxInstruction (
				                                 "FK_L_hand_jnt",
				                                 attackOwner,
				                                 1.0f,
				                                 2.0f,
				                                 0.3f,
				                                 0.5f,
				                                 Vector3.zero,
				                                 new Vector3 (0.0f, 0f, 0)
			                                 );
			attack1.onStartSound = GameManager.Sounds.PatriotV_Jab;
			this.AddInstruction (attack1);
		}		
	}
}
