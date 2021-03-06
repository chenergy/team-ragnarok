using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Attack_Projectile : A_Attack
	{
		public Attack_Projectile (string animationName, float animationSpeed, A_Fighter attackOwner) : base(animationName, animationSpeed, attackOwner) { }
		
		public void AddInstruction ( ProjectileHitBoxInstruction hbi ){
			base.AddInstruction( hbi );
		}
	}
}

