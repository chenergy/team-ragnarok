using UnityEngine;
using System.Collections;
using FightGame;


//regular melee - down
namespace FightGame{
	public class PatriotV_Counter : Attack_Melee {
		public PatriotV_Counter(string animationName, A_Fighter attackOwner, float animationSpeed = 1.0f) : base(animationName, animationSpeed, attackOwner){
			//brieft invincible
			//this.buff = new Buff_TemporaryInvincible(1.0f,attackOwner,"TemporaryInvincible",0f);
			
			this.AddInstruction(
				new JointHitBoxInstruction(
					"FK_R_hand_jnt",
					attackOwner,
					1.0f,
					2.0f,
					0.9f,
					1.2f,
					Vector3.zero,								//offset
					new Vector3(0.0f,0.0f,0.0f)				//movement
				)
			);
			
			
		}		
	}
}
