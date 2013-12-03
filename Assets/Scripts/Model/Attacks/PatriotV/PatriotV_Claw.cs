using UnityEngine;
using System.Collections;
using FightGame;


//regular melee - down
namespace FightGame{
	public class PatriotV_Claw : Attack_SelfBuff {
		public PatriotV_Claw(string animationName, A_Fighter attackOwner, float animationSpeed = 1.0f) : base(animationName, animationSpeed, attackOwner){
			this.buff = new Buff_Claw( 5.0f, attackOwner, "Claw" );
			this.buff.onStartSound = GameManager.Sounds.PatriotV_Claws;
		}		
	}
}
