using UnityEngine;
using System.Collections;
using FightGame;


//regular melee - down
namespace FightGame{
	public class PatriotV_GrenadeDrop : Attack_Melee {
		public PatriotV_GrenadeDrop(string animationName, A_Fighter attackOwner, float animationSpeed = 1.0f) : base(animationName, animationSpeed, attackOwner){
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
			attack1.onStartSound = GameManager.Sounds.PatriotV_GrenadeToss;
			this.AddInstruction (attack1);
		}		
	}
}
