using System;
using System.Collections.Generic;
using FightGame;
using FSM;
using UnityEngine;

namespace FSM
{
	public class Action_TakeDamageEnter:FSMAction
	{
		public override void execute(FSMContext c, object o){
			A_Fighter fighter = (A_Fighter)o;				
			GameObject gobj = fighter.gobj;

			fighter.globalActionTimer = 0.0f;

			gobj.animation.Stop();
			
			//this.gobj.animation[this.animationNameMap[FighterAnimation.IDLE]].AddMixingTransform(this.joints["master_amaterasu_ctr"]);
			if (fighter.name == "Amaterasu")
				fighter.joints["master_amaterasu_ctr"].transform.localRotation = Quaternion.identity;
		}
	}
}
