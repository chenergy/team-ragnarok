using System;
using System.Collections.Generic;
using FightGame;
using FSM;
using UnityEngine;
namespace FSM
{
	public class Action_WalkUpdate:FSMAction
	{
		public override void execute(FSMContext c, object o){
			A_Fighter fighter = (A_Fighter)o;				
			GameObject gobj = fighter.gobj;
			float moveSpeed = fighter.moveSpeed;
			
			if(fighter.currentMovement == MoveCommand.FORWARD || fighter.currentMovement == MoveCommand.FORWARD_UP)
			{
				if ( GameManager.CheckCanMoveForward(fighter) ){
					gobj.transform.Translate(fighter.localForwardVector * moveSpeed * Time.deltaTime);
				}
				else{
					A_Fighter opponent = GameManager.GetOpponentPlayer(fighter.playerNumber).Fighter;
					if ( GameManager.CheckCanMoveBackward(opponent) ){
						opponent.gobj.transform.Translate(fighter.localForwardVector * -1 * moveSpeed * Time.deltaTime);
						//opponent.DoMoveCommand(MoveCommand.BACK);
					}
				}
				gobj.animation.CrossFade(fighter.animationNameMap[FighterAnimation.WALK_FORWARD]);

				switch (fighter.name) {
				case "Amaterasu":
					GameManager.PlayAudioLoop (GameManager.Sounds.Ama_WalkForward, moveSpeed);
					break;
				case "Heavy":
					GameManager.PlayAudioLoop (GameManager.Sounds.Heavy_WalkForward, moveSpeed);
					break;
				case "Odin":
					GameManager.PlayAudioLoop (GameManager.Sounds.Odin_WalkForward, moveSpeed);
					break;
				case "PatriotV":
					GameManager.PlayAudioLoop (GameManager.Sounds.PatriotV_WalkForward, 1.0f);
					break;
				default:
					break;
				}
			}
			else if(fighter.currentMovement == MoveCommand.BACK || fighter.currentMovement == MoveCommand.BACK_UP)
			{
				if ( GameManager.CheckCanMoveBackward(fighter) ){
					gobj.transform.Translate(fighter.localForwardVector * -1 * moveSpeed * Time.deltaTime);
				}
				gobj.animation.CrossFade(fighter.animationNameMap[FighterAnimation.WALK_BACKWARD]);

				switch (fighter.name) {
				case "Amaterasu":
					GameManager.PlayAudioLoop (GameManager.Sounds.Ama_WalkBackward, moveSpeed);
					break;
				case "Heavy":
					GameManager.PlayAudioLoop (GameManager.Sounds.Heavy_WalkBackward, moveSpeed);
					break;
				case "Odin":
					GameManager.PlayAudioLoop (GameManager.Sounds.Odin_WalkBackward, moveSpeed);
					break;
				case "PatriotV":
					GameManager.PlayAudioLoop (GameManager.Sounds.PatriotV_WalkBackward, 1.0f);
					break;
				default:
					break;
				}
			}
			
			
			if( fighter.currentMovement == MoveCommand.NONE)
			{
				c.dispatch("idle", o);
			}
		}
	}
}

