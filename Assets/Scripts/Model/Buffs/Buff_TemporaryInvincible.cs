using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Buff_TemporaryInvincible : A_Buff
	{
		GameObject blockParticle;

		public Buff_TemporaryInvincible ( float duration, A_Fighter attackOwner, string name, float chargeTime = 0.7f ) : base( duration, attackOwner, name, chargeTime )
		{
			this.name = "TemporaryInvincible";
		}
		
		protected override void ApplyBuff(){
			attackOwner.invincible = true;
			
			// Particle effect
			GameObject load = (GameObject)Resources.Load("Particles/Heavy_Block", typeof(GameObject));
			this.blockParticle = GameObject.Instantiate(load, this.attackOwner.gobj.transform.position+ new Vector3(1,3,0), load.transform.rotation) as GameObject;
			this.blockParticle.transform.parent = attackOwner.gobj.transform;
			
			GameObject.Destroy(this.blockParticle, 2.0f);
			
			
			Debug.Log("Buff: " + this.name + " Applied");
			
		}
		
		public override void DeActivate(){
			attackOwner.invincible = false;
			if (this.blockParticle != null){
				GameObject.Destroy(this.blockParticle);
				this.blockParticle = null;
			}
			Debug.Log("Buff: " + this.name + " Removed");
			base.DeActivate();
		}
	}
}

