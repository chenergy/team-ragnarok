using System;
using System.Collections.Generic;
using FightGame;
using FSM;
using UnityEngine;

namespace FSM
{
	public class Action_IdleUpdate:FSMAction
	{
		public override void execute(FSMContext c, object o){
			A_Fighter fighter = (A_Fighter)o;
			fighter.gobj.animation.CrossFade(fighter.animationNameMap[FighterAnimation.IDLE]);
		}
	}
}

