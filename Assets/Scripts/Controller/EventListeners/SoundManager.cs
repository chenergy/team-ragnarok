using UnityEngine;
using System.Collections;

[System.Serializable]
public class GameSounds{
	// Ama sounds
	public AudioClip Ama_AxeKick;
	public AudioClip Ama_BackDraft;
	public AudioClip Ama_Block;
	public AudioClip Ama_Death;
	public AudioClip Ama_FlinchDown;
	public AudioClip Ama_FlinchUp;
	public AudioClip Ama_Fury;
	public AudioClip Ama_KnockDown;
	public AudioClip Ama_LightFlash;
	public AudioClip Ama_QuakeWithFear;
	public AudioClip Ama_RisingSun;
	public AudioClip Ama_SettingSun;
	public AudioClip Ama_Idle;
	public AudioClip Ama_SolarRoundhouseKick;
	public AudioClip Ama_SpinningHookKick;
	public AudioClip Ama_Victory;
	public AudioClip Ama_WalkBackward;
	public AudioClip Ama_WalkForward;
	public AudioClip Ama_DawnFirstLight;

	// Heavy
	public AudioClip Heavy_Block;
	public AudioClip Heavy_ColdShoulder;
	public AudioClip Heavy_Death;
	public AudioClip Heavy_Fire123;
	public AudioClip Heavy_FireCarpet;
	public AudioClip Heavy_FlinchDown;
	public AudioClip Heavy_FlinchUp;
	public AudioClip Heavy_HeatSeeker;
	public AudioClip Heavy_Idle;
	public AudioClip Heavy_KnockDown;
	public AudioClip Heavy_MegatonPunch;
	public AudioClip Heavy_NapalmFlame;
	public AudioClip Heavy_Railgun;
	public AudioClip Heavy_TriplePunch;
	public AudioClip Heavy_WalkBackward;
	public AudioClip Heavy_WalkForward;

	// Odin
	public AudioClip Odin_Block;
	public AudioClip Odin_Death;
	public AudioClip Odin_FlinchDown;
	public AudioClip Odin_FlinchUp;
	public AudioClip Odin_Idle;
	public AudioClip Odin_KnockDown;
	public AudioClip Odin_RavenFury;
	public AudioClip Odin_RavenSoulSteel;
	public AudioClip Odin_RavenStorm;
	public AudioClip Odin_ScorpionUppercut;
	public AudioClip Odin_SpeedJab;
	public AudioClip Odin_SweepingSpear;
	public AudioClip Odin_Teleport;
	public AudioClip Odin_ThrustLunge;
	public AudioClip Odin_WalkBackward;
	public AudioClip Odin_WalkForward;

	// Odin
	public AudioClip PatriotV_Block;
	public AudioClip PatriotV_Death;
	public AudioClip PatriotV_FlinchDown;
	public AudioClip PatriotV_FlinchUp;
	public AudioClip PatriotV_Idle;
	public AudioClip PatriotV_KnockDown;
	public AudioClip PatriotV_WalkBackward;
	public AudioClip PatriotV_WalkForward;
	public AudioClip PatriotV_Victory;
	public AudioClip PatriotV_Backhand;
	public AudioClip PatriotV_Claws;
	public AudioClip PatriotV_Counter;
	public AudioClip PatriotV_ExecutionDrop;
	public AudioClip PatriotV_ExplosivePunch;
	public AudioClip PatriotV_FreedomSpins;
	public AudioClip PatriotV_GrenadeToss;
	public AudioClip PatriotV_GutBuster;
	public AudioClip PatriotV_Jab;
	public AudioClip PatriotV_Unload;
	public AudioClip PatriotV_Uppercut;
}

public class SoundManager : MonoBehaviour
{
	public GameSounds gameSounds;
}

