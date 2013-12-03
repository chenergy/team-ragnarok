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

			switch (fighter.name) {
			case "Amaterasu":
				GameManager.PlayAudioLoop (GameManager.Sounds.Ama_Idle, 1.0f);
				break;
			case "Heavy":
				GameManager.PlayAudioLoop (GameManager.Sounds.Heavy_Idle, 1.0f);
				break;
			case "Odin":
				GameManager.PlayAudioLoop (GameManager.Sounds.Odin_Idle, 1.0f);
				break;
			case "PatriotV":
				GameManager.PlayAudioLoop (GameManager.Sounds.PatriotV_Idle, 1.0f);
				break;
			default:
				break;
			}
		}
	}
}

