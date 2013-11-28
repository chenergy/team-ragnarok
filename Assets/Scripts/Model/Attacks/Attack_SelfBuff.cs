using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Attack_SelfBuff : A_Attack
	{
		private bool activated;
		protected A_Buff buff;
		
		public AudioClip onStartSound;
		
		public Attack_SelfBuff (string animationName, float animationSpeed, A_Fighter attackOwner) : base (animationName, animationSpeed, attackOwner)
		{
			this.activated = false;
		}
		
		
		public override void Execute(){
			if (!this.activated){
				if (this.onStartSound != null) 
					GameManager.PlayAudio( this.onStartSound, 1.0f );
				this.attackOwner.AddBuff(this.buff);
				this.activated = true;
			}
			this.timer += Time.deltaTime;
		}
		public void AddInstruction ( JointHitBoxInstruction hbi ){
			base.AddInstruction( hbi );
		}
		public override void Reset(){ 
			this.activated = false;
			this.timer = 0.0f;
		}
	}
}

