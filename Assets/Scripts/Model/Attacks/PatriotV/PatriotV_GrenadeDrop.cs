using UnityEngine;
using System.Collections;
using FightGame;


//regular melee - down
namespace FightGame{
	public class PatriotV_GrenadeDrop : Attack_Melee {
		public PatriotV_GrenadeDrop(string animationName, A_Fighter attackOwner, float animationSpeed = 1.0f) : base(animationName, animationSpeed, attackOwner){
	
		}		
	}
}
