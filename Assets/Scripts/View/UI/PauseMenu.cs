using UnityEngine;
using System.Collections;
using FightGame;
public class PauseMenu : MonoBehaviour {
	bool activated;
	void Update()
	{
        if (Input.GetKeyDown(KeyCode.Escape))
		{
			activated = !activated;
            if (activated)
			{
                Time.timeScale = 0.0F;
			}
			else
			{
				Time.timeScale = 1.0f;
			}
            //Time.fixedDeltaTime = 0.02F * Time.timeScale;
			//Debug.Log(Time.timeScale);
        }
    }
	
	void OnGUI()
	{
		if(activated)
		{
			if (GUI.Button(new Rect(Screen.width/2 - 100, Screen.height/2 - 60, 200, 100), "Char Select"))
			{
				Time.timeScale = 1.0f;
				Application.LoadLevel("2P_CharSelect");
			}
			
			//if (GUI.Button(new Rect(Screen.width/2 - 100, Screen.height/2 + 60, 200, 100), "Restart"))
			//{	
			//	GameObject.Find("UI").GetComponent<UI_Script>().InitPlayers();
			//	GameManager.P1.roundsWon = 0;
			//	GameManager.P2.roundsWon = 0;
			//	Time.timeScale = 1.0f;
			//	activated = false;
			//}
		}
	}
}