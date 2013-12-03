using System;
using System.Collections.Generic;
using FightGame;
using FSM;
using UnityEngine;

namespace FSM
{
	public class Action_KnockDownEnter:FSMAction
	{
		public override void execute(FSMContext c, object o){
			A_Fighter fighter = (A_Fighter)o;				
			GameObject gobj = fighter.gobj;
			
			fighter.globalActionTimer = 0.0f;
			
			gobj.animation.Stop();

			switch (fighter.name) {
			case "Amaterasu":
				GameManager.PlayAudio (GameManager.Sounds.Ama_KnockDown, 1.0f);
				break;
			case "Heavy":
				GameManager.PlayAudio (GameManager.Sounds.Heavy_KnockDown, 1.0f);
				break;
			case "Odin":
				GameManager.PlayAudio (GameManager.Sounds.Odin_KnockDown, 1.0f);
				break;
			case "PatriotV":
				GameManager.PlayAudio (GameManager.Sounds.PatriotV_KnockDown, 1.0f);
				break;
			default:
				break;
			}
		}
	}
}


