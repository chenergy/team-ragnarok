using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Heavy_ColdShoulder: A_Attack
	{	
		public Heavy_ColdShoulder(string animationName, A_Fighter attackOwner, float animationSpeed = 1.0f) : base(animationName, animationSpeed, attackOwner)
		{
			this.instructions.Add(new JointHitBoxInstruction(
				"l_elbow_jnt", 					// joint
				attackOwner, 					// fighter
				5.0f, 							// radius
				100.0f,							// damage
				0.7f, 							// startTime
				1.6f,  							// endTime
				new Vector3(0.0f, 0.0f, 0.0f), 	// offset
				new Vector3(0.4f, 0.0f, 0.0f)
				));
		}
	}
}
