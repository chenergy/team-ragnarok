﻿using UnityEngine;
using System.Collections;
using FightGame;

public class UI_Script2 : MonoBehaviour
{	
	private bool created = false;
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
	
	
	float 	p1_CorX, p1_CorY,
					p2_CorX, p2_CorY,
					meterPosY;
	
	float	p1_GUIstartX,
					p1_GUIstartY,
					p2_GUIstartX,
					p2_GUIstartY;
				
	
	//tom
	
	public Texture2D UI_base;
	public Texture2D UI_healthGreen;
	public Texture2D UI_healthGreenp2;
	public Texture2D UI_healthRed;
	
	public float dmgRedBarSpeed = 0.1f;
	float redBarCurrentWidth,redBarCurrentWidthp2;
	
	
	// end tom
	
	void Start()
	{
		
		
		p1_GUIstartX = 25f;
		p1_GUIstartY = 25f;
	
		//init both player hp
		//max_p1hp = GameManager.P1.max_hp;
		//max_p2hp = GameManager.P2.max_hp;
		//since p1 and p2 are not instantiate at the beginning
		//For testing purpose, we will hard code max hp here.
		
		max_p1hp = 100f;
		max_p2hp = 100f;
		max_p1meter = 100f;
		max_p2meter = 100f;
		
		//cur_p1hp = GameManager.P1.cur_hp;
		//cur_p2hp = GameManager.P2.cur_hp;
		//tom
		redBarCurrentWidth = redBarCurrentWidthp2 = UI_healthGreen.width * Screen.width/1024.0f * max_p1hp/max_p1hp;
		//end tom
	}

	void Update ()
	{
		//max_p1hp = max_p2hp = max_p1meter = max_p2meter =100f;
		length_default = Screen.width/4;
		p2_GUIstartX = Screen.width - (length_default + p1_GUIstartX);
		p2_GUIstartY = p1_GUIstartY;
		meterPosY = Screen.height*5/6;
		
		
		height_default = Mathf.Min(Screen.height/18,30f);
		
		
		//Debug.Log ("Screen width: "+ Screen.width);
		//Debug.Log ("Screen height: "+ Screen.height);
		
		if(GameManager.P1!=null && GameManager.P2!=null)
		{
			//update both player's hp during fighting time
			cur_p1hp = GameManager.P1.cur_hp;
			cur_p2hp = GameManager.P2.cur_hp;
			
			cur_p1meter = GameManager.P1.cur_meter;
			cur_p2meter = GameManager.P2.cur_meter;
			
			length_p1meter = length_default*(cur_p1meter/max_p1meter);
			length_p2meter = length_default*(cur_p2meter/max_p2meter);
			
			length_p1health=length_default*(cur_p1hp/max_p1hp);
			length_p2health=length_default*(cur_p2hp/max_p2hp);
		}
	}
	
	void TomGUI()
	{
		float texToScreenRatioH = (Screen.height/768.0f); // textures created for 768 height screen
		float texToScreenRatioW = (Screen.width/1024.0f); // textures created for 1024 width screen
		int textOffSetH =  (int)(256 * texToScreenRatioH) ; //compensate for 1024 texture when design was for 768
		
		//p1 dmg bar
		redBarCurrentWidth = Mathf.Lerp(redBarCurrentWidth,UI_healthGreen.width * texToScreenRatioW * cur_p1hp/max_p1hp,dmgRedBarSpeed);
		Rect location = new Rect(
				130*texToScreenRatioW,
				37*texToScreenRatioH,
				redBarCurrentWidth,
				UI_healthGreen.height * texToScreenRatioH);
		GUI.DrawTexture(location
			,UI_healthRed,ScaleMode.StretchToFill,true,0);
		Debug.Log(location);
				
		//p1 health bar
		GUI.DrawTexture(
			new Rect(
				130*texToScreenRatioW,
				37*texToScreenRatioH,
				UI_healthGreen.width * texToScreenRatioW * cur_p1hp/max_p1hp,
				UI_healthGreen.height * texToScreenRatioH),UI_healthGreen,ScaleMode.StretchToFill,true,0);
		
		float p2BarOffset = 573*texToScreenRatioW;
		float barWidth = 320*texToScreenRatioW;
		float initWidth = 512*texToScreenRatioW;
		
		
		//p2 dmg bar
		redBarCurrentWidthp2 = Mathf.Lerp(redBarCurrentWidthp2,UI_healthGreenp2.width * texToScreenRatioW * cur_p2hp/max_p1hp,dmgRedBarSpeed);
		GUI.DrawTexture(
			new Rect(
				Screen.width - 130*texToScreenRatioW ,
				37*texToScreenRatioH,
				-redBarCurrentWidthp2,
				UI_healthGreen.height * texToScreenRatioH),UI_healthRed,ScaleMode.StretchToFill,true,0);
		
		//p2 health bar
		
		float bar = (p2BarOffset + barWidth + (cur_p2hp/max_p1hp)*-barWidth);
		GUI.DrawTexture(
			new Rect(
				(p2BarOffset + barWidth + (cur_p2hp/max_p1hp)*-barWidth),
				37*texToScreenRatioH,
				UI_healthGreenp2.width * texToScreenRatioW * cur_p2hp/max_p1hp,
				UI_healthGreenp2.height * texToScreenRatioH),UI_healthGreenp2,ScaleMode.StretchToFill,true,0);
		
		//ui overlay
		GUI.DrawTexture(new Rect(0, 0, Screen.width , Screen.height + textOffSetH),UI_base,ScaleMode.StretchToFill,true,0);
		
	}
	
    void OnGUI() {
		if (!created){
	        if (GUI.Button(new Rect(Screen.width/2, Screen.height/2, 50, 30), "Start")){
				GameManager.CreateFighter("Fighter_Heavy",1);
				GameManager.CreateFighter("Fighter_Heavy",2);
	            created = true;
			}
			/*
			if (GUI.Button(new Rect(Screen.width/3, Screen.height/2, 50, 30), "Heacy")){
				GameManager.CreateFighter("Fighter_Heacy");
	            created = true;a
			}
			*/
		}
		
		
		
		if(GameManager.P1!=null && GameManager.P2!=null)
		{
			TomGUI();
			
			//draw empty bars
			//GUI.Box(new Rect(p1_GUIstartX,p1_GUIstartY,length_default,height_default),"");
			//GUI.Box(new Rect(p2_GUIstartX,p2_GUIstartY,length_default,height_default),"");
			GUI.Box(new Rect(p1_GUIstartX,p1_GUIstartY+meterPosY,length_default,height_default),"");
			GUI.Box(new Rect(p2_GUIstartX,p2_GUIstartY+meterPosY,length_default,height_default),"");
			
			//draw health bars and meter bars over
			//GUI.Box(new Rect(p1_GUIstartX,p1_GUIstartY,length_p1health,height_default),"",health_style);
			//GUI.Box(new Rect(p2_GUIstartX,p2_GUIstartY,length_p2health,height_default),"",health_style);
			GUI.Box(new Rect(p1_GUIstartX,p1_GUIstartY+meterPosY,length_p1meter,height_default),"",meter_style);
			GUI.Box(new Rect(p2_GUIstartX,p2_GUIstartY+meterPosY,length_p2meter,height_default),"",meter_style);
			
			
		
			
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
}