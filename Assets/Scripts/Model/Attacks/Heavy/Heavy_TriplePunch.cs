using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Heavy_TriplePunch: Attack_Melee
	{	
		public Heavy_TriplePunch(string animationName, A_Fighter attackOwner, float animationSpeed = 1.0f) : base(animationName, animationSpeed, attackOwner)
		{
			this.AddInstruction(new JointHitBoxInstruction(
				"l_wrist_jnt", 					// joint
				attackOwner, 					// fighter
				3.0f, 							// radius
				2.0f,							// damage
				0.1f, 							// startTime
				0.5f,  							// endTime
				Vector3.zero,					// offset
				new Vector3( 0.005f, 0, 0 )		// movement
				));			
			this.AddInstruction(new JointHitBoxInstruction(
				"r_wrist_jnt", 					// joint
				attackOwner, 					// fighter
				3.0f, 							// radius
				2.0f,							// damage
				1.0f, 							// startTime
				1.4f,  							// endTime
				Vector3.zero,					// offset
				new Vector3( 0.005f, 0, 0 )		// movement
				));
		}
	}
}

