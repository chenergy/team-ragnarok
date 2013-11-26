﻿using UnityEngine;
using System.Collections;
using FightGame;

public class UI_Script : MonoBehaviour
{	
	public Vector2 timerOffset;
	public float portraitW, portraitH,portraitOffX,portraitOffY,portraitOffXp2;
	enum playStates {GAME,WINP1,WINP2,CHOOSE,PAUSE,BOTHLOSE};
	playStates playState = playStates.GAME;
	public int ROUNDTIME = 60;
	private bool created , p1Pick = false;
	private bool p2Pick = false;
	GameObject player;
	float length_default, height_default;
	float	length_p1health,
					length_p2health,
					length_p1meter,
					length_p2meter,
					max_p1meter,
					max_p2meter,
					max_p1hp,
					max_p2hp,
					cur_p1hp,
					cur_p2hp,
					cur_p1meter,
					cur_p2meter;
	public GUIStyle health_style, meter_style;
	public Texture2D controls;
	
	//float 	p1_CorX, p1_CorY,
	//				p2_CorX, p2_CorY,
	//				meterPosY;
	
	//private float	p1_GUIstartX,
	//				p1_GUIstartY,
	//				p2_GUIstartX,
	//				p2_GUIstartY;
	
	[HideInInspector]
	public bool	hitboxOn, hurtboxOn, controlsOn = false;
	
	//tom for gui
	public int maxRounds = 5;
	float aspectW = Screen.width/1024.0f;
	float aspectH = Screen.height/768.0f;
	
	public Texture2D UI_base;
	public Texture2D UI_healthGreen;
	public Texture2D UI_healthGreenp2;
	public Texture2D UI_healthRed;
	public Texture2D UI_staminaBlue;
	public Texture2D UI_roundsMax;
	public Texture2D UI_roundsWon;
	public Texture2D UI_bghealthBar;
	public int x,y=20;
	Texture2D P1_portrait, P2_portrait;
	
	public float dmgRedBarSpeed = 0.002f;
	float dmgBarHealth_P1,dmgBarHealth_P2;
	public GUIStyle playerName_GuiStyle_p1;
	public GUIStyle timerGS;
	GUIStyle p2GS;
	int initFontSize,timerInitFontSize;
	float roundTimer;
	public const float KOTIMER = 5;
	float koTimer;
	
	PlayerSelectOptions playerOptionsGob;
	// end tom
	
	void Start()
	{
		
		GameManager.ReInitGameModel();
		// chracternames
		p2GS = new GUIStyle(playerName_GuiStyle_p1);
		p2GS.alignment = TextAnchor.UpperRight;
		initFontSize = playerName_GuiStyle_p1.fontSize;
		timerInitFontSize = timerGS.fontSize;
		// end chracterNames
		
		aspectW = Screen.width/1024.0f;
		aspectH = Screen.height/768.0f;
		
		dmgBarHealth_P1 = dmgBarHealth_P2 = 100.0f;
		
		playerOptionsGob = GameObject.Find("PlayerSelection").GetComponent<PlayerSelectOptions>();
		if(playerOptionsGob!=null)
		{
			GameManager.CreateFighter("Fighter_"+playerOptionsGob.p1Name,1);
			GameManager.CreateFighter("Fighter_"+playerOptionsGob.p2Name,2);
			created = p1Pick =p2Pick = true;
			roundTimer = ROUNDTIME;
		}
		maxRounds = playerOptionsGob.rounds;
		
	}
	
	public void InitPlayers()
	{
		roundTimer = ROUNDTIME;
		GameManager.Restart();
	}
	
	void Update ()
	{
		
		//inGame State Machine
		if(created)
		{
			if ((GameManager.P2.Fighter.cur_hp ==GameManager.P1.Fighter.cur_hp) && roundTimer <=0)
			{
				if(playState==playStates.GAME)
				{
					//GameManager.P1.roundsWon+=1;
					//GameManager.P2.roundsWon+=1;
					GameManager.P2.Fighter.ForceDeath();
					GameManager.P2.roundsWon-=1;
					GameManager.P1.Fighter.ForceDeath();
					GameManager.P1.roundsWon-=1;
				}
				playState = playStates.BOTHLOSE;

			}
			else if ((GameManager.P1.roundsWon >= maxRounds || GameManager.P2.roundsWon >= maxRounds) && koTimer > KOTIMER)
			{
					playState = playStates.CHOOSE;
			}
			else if (GameManager.P1.Fighter.cur_hp <= 0)
			{
				playState = playStates.WINP2;
				GameManager.P1.Fighter.ForceDeath();
				
			}
			else if (GameManager.P2.Fighter.cur_hp <= 0)
			{
				playState = playStates.WINP1;
				GameManager.P2.Fighter.ForceDeath();
				
			}

			else 
			{
					playState = playStates.GAME;
					koTimer=0;
			}
		}
		//end state machine
		
		//KO ANIMATION TIMER
		if( (playState == playStates.WINP1 || playState == playStates.WINP2 || playState == playStates.BOTHLOSE) && koTimer > KOTIMER)
		{
			
			koTimer = 0;
			InitPlayers(); 
		}
		else if(playState == playStates.WINP2 ||playState == playStates.WINP1 || playState == playStates.BOTHLOSE )
		{
			koTimer+=Time.deltaTime; 
		}
		
		// ROUND TIMER
		if(created)
		{
			if(playState == playStates.GAME)
			{
				roundTimer-= Time.deltaTime;
			}
			if(roundTimer<0)
			{
				//death if timer is zero
				roundTimer=0;
				if(GameManager.P1.Fighter.cur_hp < GameManager.P2.Fighter.cur_hp)GameManager.P1.Fighter.cur_hp = 0;
				else if(GameManager.P2.Fighter.cur_hp < GameManager.P1.Fighter.cur_hp)GameManager.P2.Fighter.cur_hp = 0;
				else if(GameManager.P1.Fighter.cur_hp == GameManager.P2.Fighter.cur_hp)GameManager.P1.Fighter.cur_hp = GameManager.P2.Fighter.cur_hp = 0;
				
			}
		}
		
		length_default = Screen.width/4;
		//p2_GUIstartX = Screen.width - (length_default + p1_GUIstartX);
		//p2_GUIstartY = p1_GUIstartY;
		//meterPosY = Screen.height*5/6;
		
		//redBarCurrentWidth = redBarCurrentWidthp2 = UI_healthGreen.width * Screen.width/1024.0f * max_p1hp/max_p1hp;
		
		height_default = Mathf.Min(Screen.height/18,30f);
		
		
		//Debug.Log ("Screen width: "+ Screen.width);
		//Debug.Log ("Screen height: "+ Screen.height);
		
		if(GameManager.P1.Fighter != null && GameManager.P2.Fighter != null)
		{
			if(P1_portrait==null)
			{
				P1_portrait =  Resources.Load("Portraits/"+GameManager.P1.Fighter.name) as Texture2D;
				if (P1_portrait==null) Debug.Log("can't find Resources/"+"Portraits/"+GameManager.P1.Fighter.name);
			}
			if(P2_portrait==null)
			{
				Debug.Log("Portraits/"+GameManager.P2.Fighter.name);
				P2_portrait =  Resources.Load("Portraits/"+GameManager.P2.Fighter.name) as Texture2D;
				if (P2_portrait==null) Debug.Log("can't find Resources/"+"Portraits/"+GameManager.P2.Fighter.name);
			}
			
			max_p1hp = GameManager.P1.Fighter.max_hp;
			max_p2hp = GameManager.P2.Fighter.max_hp;
			
			max_p1meter = GameManager.P1.Fighter.max_meter;
			max_p2meter = GameManager.P2.Fighter.max_meter;
			
			//update both player's hp during fighting time
			cur_p1hp = GameManager.P1.Fighter.cur_hp;
			cur_p2hp = GameManager.P2.Fighter.cur_hp;
			
			cur_p1meter = GameManager.P1.Fighter.cur_meter;
			cur_p2meter = GameManager.P2.Fighter.cur_meter;
			
			length_p1meter = length_default*(cur_p1meter/max_p1meter);
			length_p2meter = length_default*(cur_p2meter/max_p2meter);
			
			length_p1health = length_default*(cur_p1hp/max_p1hp);
			length_p2health = length_default*(cur_p2hp/max_p2hp);
		}
	}
	
	/*
	 * 
	Stamina (int playerNumber, float stamina, float 
	maxStamina, float aspect)
	Rounds MaxBoxes (int playernumber, int 
	maxRounds,float aspect)
	Rounds WonBoxes (int playerNumber, int 
	roundsWon,float aspect)
	Portraits (a_fighter currentPlayer,float aspect)
	CharacterName (a_fighter currentPlayer)
	 */
	
	//****************************************
	// TOM GUI FUNCTIONS BEGIN
	
	void drawTimer(float aspectW, float aspectH,GUIStyle GS,int initFontSize,int time)
	{
		float OFFSET_X 	= timerOffset.x;
		float OFFSET_Y 	= timerOffset.y;
		const float T_W 		= 90;
		const float T_H 	= 90;
		GS.fontSize = (int)(initFontSize * aspectH);
		GUI.Label(new Rect( OFFSET_X*aspectW,
							OFFSET_Y*aspectH,
							T_W*aspectW,
							T_H*aspectH),time.ToString(),GS);
		
	}
	
	void drawStaminaBar(int playerNum, float stam, float maxStam, float aspectW, float aspectH, Texture2D texture)
	{
		stam*=1.1f;
		if (playerNum == 1)
		{
			const int P1_STAM_OFFSET_X 	= 130;
			const int P1_STAM_OFFSET_Y 	= 75;
			float stamBarWidth 			= (texture.width*aspectW) * (stam/maxStam);
			float stamBarHeight 		= (texture.height*aspectH);
			
			GUI.DrawTexture(
				new Rect(
					P1_STAM_OFFSET_X*aspectW,
					P1_STAM_OFFSET_Y*aspectH,
					stamBarWidth,
					stamBarHeight),
				texture,ScaleMode.StretchToFill,true,0);
		}
		if (playerNum == 2)
		{
			const int P1_STAM_OFFSET_X 	= 897;
			const int P1_STAM_OFFSET_Y 	= 75;
			float stamBarWidth 			= (texture.width*aspectW) * (stam/maxStam)*-1;
			float stamBarHeight 		= (texture.height*aspectH);
			
			GUI.DrawTexture(
				new Rect(
					P1_STAM_OFFSET_X*aspectW,
					P1_STAM_OFFSET_Y*aspectH,
					stamBarWidth,
					stamBarHeight),
				texture,ScaleMode.StretchToFill,true,0);
		}
		
	}
	
	void drawHealthBar(int playerNum, float health, float maxHealth, float aspectW, float aspectH, Texture2D texture)
	{
		health*=1.10f;
		if (playerNum == 1)
		{
			const int P1_HEALTHBAR_OFFSET_X = 130;
			const int P1_HEALTHBAR_OFFSET_Y = 37;
			float healthBarWidth 			= (texture.width*aspectW) * (health/maxHealth);
			float healthBarHeight 			= (texture.height*aspectH);
			
			GUI.DrawTexture(
				new Rect(
					P1_HEALTHBAR_OFFSET_X*aspectW,
					P1_HEALTHBAR_OFFSET_Y*aspectH,
					healthBarWidth,
					healthBarHeight),
				texture,ScaleMode.StretchToFill,true,0);
		}
		
		if (playerNum == 2)
		{
			const int P2_HEALTHBAR_OFFSET_X = 580;
			const int P2_HEALTHBAR_OFFSET_Y = 37;
			const int P2_HEALTHBAR_INITSIZE = 320;
			float healthBarWidth 			= (texture.width*aspectW) * (health/maxHealth);
			float healthBarHeight 			= (texture.height*aspectH);
			
			GUI.DrawTexture(
				new Rect(
					(P2_HEALTHBAR_OFFSET_X+P2_HEALTHBAR_INITSIZE) *aspectW ,
					P2_HEALTHBAR_OFFSET_Y*aspectH,
					-healthBarWidth,
					healthBarHeight),
				texture,ScaleMode.StretchToFill,true,0);
		}
		
	}
	
	float drawDmgBar(int playerNum, float currentDmgBarVal, float lerpValue, float health, float maxHealth, float aspectW, float aspectH, Texture2D texture)
	{
		float newDmgBarVal = Mathf.Lerp(currentDmgBarVal,health,lerpValue);
		drawHealthBar(playerNum,newDmgBarVal,maxHealth,aspectW,aspectH,texture);
		return newDmgBarVal;
	}
	
	void drawBGHealthBar(int playerNum, float currentDmgBarVal, float lerpValue, float health, float maxHealth, float aspectW, float aspectH, Texture2D texture)
	{
		drawHealthBar(playerNum,100,100,aspectW,aspectH,texture);
	}
	
	void drawUIOverlay(float aspectH,Texture2D texture)
	{
		GUI.DrawTexture(new Rect(0, 0, Screen.width , aspectH * texture.height),texture,ScaleMode.StretchToFill,true,0);
	}
	
	void drawRoundsWon(int playerNum, int roundsWon,float aspectW, float aspectH, Texture2D texture,int maxRounds)
	{
		if(roundsWon > maxRounds) roundsWon = maxRounds;
		drawMaxRounds(playerNum, roundsWon,aspectW,aspectH,texture);
	}
	
	void drawMaxRounds(int playerNum, int maxRounds,float aspectW, float aspectH, Texture2D texture)
	{
		float round_padding = 10*aspectW;
		if (playerNum==1)
		{
			const int P1_ROUND_OFFSET_X = 440;
			const int P1_ROUND_OFFSET_Y = 120;
			float roundWidth 			= (texture.width*aspectW);
			float roundHeight 			= (texture.height*aspectH);
			
			for(int i = 0; i < maxRounds;i++)
			{
			
			GUI.DrawTexture(
				new Rect(
					(P1_ROUND_OFFSET_X *aspectW)  + (i* -roundWidth)+ (i*-round_padding) ,
					P1_ROUND_OFFSET_Y  *aspectH  ,
					roundWidth,
					roundHeight),
				texture,ScaleMode.StretchToFill,true,0);
			}
			
		}
		
		if (playerNum==2)
		{
			const int P1_ROUND_OFFSET_X = 562;
			const int P1_ROUND_OFFSET_Y = 120;
			float roundWidth 			= (texture.width*aspectW);
			float roundHeight 			= (texture.height*aspectH);
			
			for(int i = 0; i < maxRounds;i++)
			{
			
			GUI.DrawTexture(
				new Rect(
					(P1_ROUND_OFFSET_X *aspectW)  + (i* roundWidth)+ (i*round_padding) ,
					P1_ROUND_OFFSET_Y  *aspectH  ,
					roundWidth,
					roundHeight),
				texture,ScaleMode.StretchToFill,true,0);
			}
			
		}
		
	}
	
	void drawPortrait(int playerNum, float aspectH, float aspectW, Texture2D texture)
	{
		
		if (playerNum==1)
		{
			float P1_PORTRAIT_OFFSET_X = portraitOffX;
			float P1_PORTRAIT_OFFSET_Y = portraitOffY;
			float portraitWidth 			= (portraitW*aspectW);
			float portraitHeight 			= (portraitH*aspectH);
			
			GUI.DrawTexture(
				new Rect(
					(P1_PORTRAIT_OFFSET_X) *aspectW ,
					P1_PORTRAIT_OFFSET_Y*aspectH,
					portraitWidth,
					portraitHeight),
				texture,ScaleMode.StretchToFill,true,0);
			
		}
		
		if (playerNum==2)
		{
			float P1_PORTRAIT_OFFSET_X = portraitOffXp2;
			float P1_PORTRAIT_OFFSET_Y = portraitOffY;
			float portraitWidth 			= (-portraitW*aspectW);
			float portraitHeight 			= (portraitH*aspectH);
			
			GUI.DrawTexture(
				new Rect(
					(P1_PORTRAIT_OFFSET_X) *aspectW ,
					P1_PORTRAIT_OFFSET_Y*aspectH,
					portraitWidth,
					portraitHeight),
				texture,ScaleMode.StretchToFill,true,0);
			
		}
		
	}
	
	
	void drawPlayerName(string name, int playerNum, float aspectW, float aspectH,GUIStyle GS,int initFontSize)
	{
		const int NAME_WDTH = 224;
		const int NAME_HGHT = 27;
		if (playerNum==1)
		{
			const int P1_NAME_OFFSET_X = 115;
			const int P1_NAME_OFFSET_Y = 128;
			GS.fontSize = (int)(initFontSize * aspectH);
			GS.alignment = TextAnchor.UpperLeft;
			GUI.Label(new Rect( P1_NAME_OFFSET_X*aspectW,
								P1_NAME_OFFSET_Y*aspectH,
								NAME_WDTH*aspectW,
								NAME_HGHT*aspectH)
					  ,name,GS);
		}
		
		if (playerNum==2)
		{
			const int P2_NAME_OFFSET_X = 915;
			const int P2_NAME_OFFSET_Y = 128;
			GS.fontSize = (int)(initFontSize * aspectH);
			GS.alignment = TextAnchor.UpperRight;
			GUI.Label(new Rect( (P2_NAME_OFFSET_X - NAME_WDTH)*aspectW ,
								P2_NAME_OFFSET_Y*aspectH,
								NAME_WDTH*aspectW,
								NAME_HGHT*aspectH)
					  ,name,GS);
		}
		
	}
	
	
	//****************************************	
	// TOM GUI FUNCTIONS END
	
	
    void OnGUI() {
		
		

		
		//Hieu add
		
		PickFighter();
		
		if(GameManager.P1.Fighter != null && GameManager.P2.Fighter != null)
		{
			
			//THOMAS NEW GUI - sept 2013
		
			float aspectW = Screen.width/1024.0f;
			float aspectH = Screen.height/768.0f;

			drawPortrait(1,aspectH,aspectW,P1_portrait);
			drawPortrait(2,aspectH,aspectW,P2_portrait);
			
			drawBGHealthBar(1,dmgBarHealth_P1,0,100,100,aspectW,aspectH,UI_bghealthBar);
			drawBGHealthBar(2,dmgBarHealth_P1,0,100,100,aspectW,aspectH,UI_bghealthBar);
			dmgBarHealth_P1 = drawDmgBar(1,dmgBarHealth_P1,dmgRedBarSpeed,cur_p1hp,max_p1hp,aspectW,aspectH,UI_healthRed);
			dmgBarHealth_P2 = drawDmgBar(2,dmgBarHealth_P2,dmgRedBarSpeed,cur_p2hp,max_p2hp,aspectW,aspectH,UI_healthRed);
			drawHealthBar(1,cur_p1hp,max_p1hp,aspectW,aspectH,UI_healthGreen);
			drawHealthBar(2,cur_p2hp,max_p2hp,aspectW,aspectH,UI_healthGreen);
			drawStaminaBar(1,cur_p1meter,max_p1meter,aspectW,aspectH,UI_staminaBlue);
			drawStaminaBar(2,cur_p2meter,max_p2meter,aspectW,aspectH,UI_staminaBlue);
			

			
			drawMaxRounds(1,maxRounds,aspectW,aspectH,UI_roundsMax);
			drawMaxRounds(2,maxRounds,aspectW,aspectH,UI_roundsMax);
			
			drawRoundsWon(1,GameManager.P1.roundsWon,aspectW,aspectH,UI_roundsWon,maxRounds);
			drawRoundsWon(2,GameManager.P2.roundsWon,aspectW,aspectH,UI_roundsWon,maxRounds);
			
			drawUIOverlay(aspectH,UI_base);
			
			drawPlayerName(GameManager.P1.Fighter.name,1,aspectW,aspectH,playerName_GuiStyle_p1,initFontSize);
			drawPlayerName(GameManager.P2.Fighter.name,2,aspectW,aspectH,p2GS,initFontSize);
			
			drawTimer(aspectW, aspectH,timerGS,timerInitFontSize,(int)roundTimer);
			
			//end THOMAS NEW GUI
			
			
			// PLAYER CHOOSE SCREEN
			if (playState == playStates.CHOOSE)
			{
				if (GUI.Button(new Rect(Screen.width/2 - 100, Screen.height/2 - 60, 200, 100), "Char Select"))
				{
					
	
					//TO TO CHARACTER SELECT
					
					//GameManager.Instance.ReInitGameModel(GameManager.Instance);
					//InitPlayers();
					//GameManager.CreateFightCamera();
			
					Application.LoadLevel("2P_CharSelect");
										
					
				}
				
				if (GUI.Button(new Rect(Screen.width/2 - 100, Screen.height/2 + 60, 200, 100), "Restart"))
				{
					
					InitPlayers();
					GameManager.P1.roundsWon = 0;
					GameManager.P2.roundsWon = 0;
					//InitPlayers();
					//created = false;
					//p1Pick = false;
					//p2Pick = false;
					//GameObject.Destroy(GameObject.Find("PlayerSelection"));
					//Application.LoadLevel("TitleScreen");
				}
			}
			
			this.hitboxOn = GUI.Toggle(new Rect(Screen.width * 0.05f, Screen.height * 0.25f, 130, 20), hitboxOn, "Show HitBoxes");
			this.hurtboxOn = GUI.Toggle(new Rect(Screen.width * 0.05f, Screen.height * 0.25f + 20, 130, 20), hurtboxOn, "Show HurtBoxes");
			this.controlsOn = GUI.Toggle(new Rect(Screen.width * 0.05f, Screen.height * 0.25f + 40, 130, 20), controlsOn, "Show Controls");
			

			
			
			//draw empty bars
			//GUI.Box(new Rect(p1_GUIstartX,p1_GUIstartY,length_default,height_default),"");
			//GUI.Box(new Rect(p2_GUIstartX,p2_GUIstartY,length_default,height_default),"");
			
			//GUI.Box(new Rect(p1_GUIstartX,p1_GUIstartY+meterPosY,length_default,height_default),"");
			//GUI.Box(new Rect(p2_GUIstartX,p2_GUIstartY+meterPosY,length_default,height_default),"");
			
			//draw health bars and meter bars over
			//GUI.Box(new Rect(p1_GUIstartX,p1_GUIstartY,length_p1health,height_default),"",health_style);
			//GUI.Box(new Rect(p2_GUIstartX,p2_GUIstartY,length_p2health,height_default),"",health_style);
			
			//GUI.Box(new Rect(p1_GUIstartX,p1_GUIstartY+meterPosY,length_p1meter,height_default),"",meter_style);
			//GUI.Box(new Rect(p2_GUIstartX,p2_GUIstartY+meterPosY,length_p2meter,height_default),"",meter_style);

			
			
			if (this.controlsOn){
				GUI.DrawTexture( new Rect( 0, 0, Screen.width, Screen.height ), this.controls, ScaleMode.ScaleToFit, true, 0 );
			}
		}
		/*
		else{
			if (GUI.Button(new Rect(Screen.width/2 - 100, Screen.height/2, 100, 30), "Idle")){
				//GameManager.P1.Dispatch("idle");
			}
			if (GUI.Button(new Rect(Screen.width/2 + 100, Screen.height/2, 100, 30), "Walk Forward")){
				//GameManager.P1.Dispatch("walkForward");
			}
		}
		*/
    }
	
	//Hieu add
	void PickFighter()
	{
		if (!created){
			if(!p1Pick){
				GUI.Box(new Rect(Screen.width/2,Screen.height*1/4,100,30),"Player 1 turn");
				//add more fighter selection for P1 here
				P1_Pick("Amaterasu",Screen.width/5,Screen.height/2);
		        P1_Pick("Odin",Screen.width*2/5, Screen.height/2);
				P1_Pick("Heavy",Screen.width*3/5,Screen.height/2);
				P1_Pick("PatriotV",Screen.width*4/5,Screen.height/2);
			}
			if(p2Pick){
				GUI.Box(new Rect(Screen.width/2,Screen.height*1/4,100,30),"Player 2 turn");
				//add more fighter selection for P2 here
			  	P2_Pick("Amaterasu",Screen.width/5,Screen.height/2);
		        P2_Pick("Odin",Screen.width*2/5, Screen.height/2);
				P2_Pick("Heavy",Screen.width*3/5,Screen.height/2);
				P2_Pick("PatriotV",Screen.width*4/5,Screen.height/2);
			}
		}
	}
	
	void P1_Pick(string fighterName, float positionX, float positionY, float width=100, float height=30)
	{
		if (GUI.Button(new Rect(positionX, positionY, width, height), fighterName)){
			GameManager.CreateFighter("Fighter_"+fighterName,1);
			p1Pick = true;
			p2Pick = true;
		}
	}
	
	void P2_Pick(string fighterName, float positionX, float positionY, float width=100, float height=30)
	{
		if (GUI.Button(new Rect(positionX, positionY, width, height), fighterName)){
			GameManager.CreateFighter("Fighter_"+fighterName,2);
			p2Pick = true;
			created = true;
			roundTimer = ROUNDTIME;
		}
	}
}