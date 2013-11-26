using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;
using FSM;

namespace FightGame
{
	public class Fighter_PatriotV : A_Fighter
	{
		public Fighter_PatriotV (GameObject gobj, int playerNumber) : base (gobj, playerNumber){
			
			this.gobj.animation[this.animationNameMap[FighterAnimation.WALK_FORWARD]].speed = 1.0f;
			this.gobj.animation[this.animationNameMap[FighterAnimation.WALK_BACKWARD]].speed = 1.25f;
			
			this.actionsCommandMap = new Dictionary<int, A_Attack>();
			
			this.actionsCommandMap[ActionCommand.REGULAR] 			= new PatriotV_ExecutionDrop(this.animationNameMap[FighterAnimation.REGULAR_ATTACK], this, 1.0f);
			this.actionsCommandMap[ActionCommand.REGULAR_FORWARD] 	= new PatriotV_ExecutionDrop(this.animationNameMap[FighterAnimation.REGULAR_FORWARD_ATTACK], this, 1.0f);
			this.actionsCommandMap[ActionCommand.REGULAR_BACK] 		= new PatriotV_ExecutionDrop(this.animationNameMap[FighterAnimation.REGULAR_BACK_ATTACK], this, 1.0f);
			this.actionsCommandMap[ActionCommand.REGULAR_UP] 		= new PatriotV_ExecutionDrop(this.animationNameMap[FighterAnimation.REGULAR_UP_ATTACK], this, 1.0f);
			this.actionsCommandMap[ActionCommand.REGULAR_DOWN] 		= new PatriotV_ExecutionDrop(this.animationNameMap[FighterAnimation.REGULAR_DOWN_ATTACK], this, 1.0f);
			
			this.actionsCommandMap[ActionCommand.UNIQUE] 			= new PatriotV_ExecutionDrop(this.animationNameMap[FighterAnimation.UNIQUE_ATTACK], this, 1.0f);
			this.actionsCommandMap[ActionCommand.UNIQUE_FORWARD] 	= new PatriotV_ExecutionDrop(this.animationNameMap[FighterAnimation.UNIQUE_FORWARD_ATTACK], this, 1.0f);
			this.actionsCommandMap[ActionCommand.UNIQUE_BACK] 		= new PatriotV_ExecutionDrop(this.animationNameMap[FighterAnimation.UNIQUE_BACK_ATTACK], this, 1.0f);
			this.actionsCommandMap[ActionCommand.UNIQUE_UP] 		= new PatriotV_ExecutionDrop(this.animationNameMap[FighterAnimation.UNIQUE_UP_ATTACK], this, 1.0f);
			this.actionsCommandMap[ActionCommand.UNIQUE_DOWN] 		= new PatriotV_ExecutionDrop(this.animationNameMap[FighterAnimation.UNIQUE_DOWN_ATTACK], this, 1.0f);
			
			this.actionsCommandMap[ActionCommand.SPECIAL] 			= new PatriotV_ExecutionDrop(this.animationNameMap[FighterAnimation.SPECIAL_ATTACK], this, 1.0f);
			this.actionsCommandMap[ActionCommand.SPECIAL_FORWARD] 	= new PatriotV_ExecutionDrop(this.animationNameMap[FighterAnimation.SPECIAL_FORWARD_ATTACK], this, 1.0f);
			this.actionsCommandMap[ActionCommand.SPECIAL_BACK] 		= new PatriotV_ExecutionDrop(this.animationNameMap[FighterAnimation.SPECIAL_BACK_ATTACK], this, 1.0f);
			this.actionsCommandMap[ActionCommand.SPECIAL_UP] 		= new PatriotV_ExecutionDrop(this.animationNameMap[FighterAnimation.SPECIAL_UP_ATTACK], this, 1.0f);
			this.actionsCommandMap[ActionCommand.SPECIAL_DOWN] 		= new PatriotV_ExecutionDrop(this.animationNameMap[FighterAnimation.SPECIAL_DOWN_ATTACK], this, 1.0f);
		}
	}
}

