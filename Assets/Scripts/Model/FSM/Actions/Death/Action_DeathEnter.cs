using System;
using System.Collections.Generic;
using FightGame;
using FSM;

namespace FSM
{
	public class Action_DeathEnter:FSMAction
	{
		public override void execute(FSMContext c, object o){
			A_Fighter myFighter = (A_Fighter)o;
			if(myFighter.playerNumber ==1)
			{
				GameManager.P2.roundsWon+=1;
			}
			else
			{
				GameManager.P1.roundsWon+=1;
			}

			switch (myFighter.name) {
			case "Amaterasu":
				GameManager.PlayAudio (GameManager.Sounds.Ama_Death, 1.0f);
				break;
			case "Heavy":
				GameManager.PlayAudio (GameManager.Sounds.Heavy_Death, 1.0f);
				break;
			case "Odin":
				//GameManager.PlayAudio (GameManager.Sounds.Odin_Death, 1.0f);
				break;
			case "PatriotV":
				//GameManager.PlayAudio (GameManager.Sounds.PatriotV_Death, 1.0f);
				break;
			default:
				break;
			}
		}
		
	}
}

