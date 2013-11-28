using UnityEngine;
using System.Collections;

public class flyingDrone : MonoBehaviour {

	public 	float 		resetPoint = 55.0f;
	public	float		flySpeed;
	public 	float 		amplitude;	
	public 	float		frequency;
	private	Vector3 	startPos;
	
	void Start () {
		startPos = this.transform.position;	
	}
	
	void Update () {
		Vector3	currentPos 		= this.transform.position;
		float 	angularFreq  	= currentPos.x * frequency;
		Vector3 droneMovement 	= new Vector3(flySpeed, SineWave(amplitude, angularFreq), 0); 
		
		if(this.transform.position.x < resetPoint){
			this.transform.Translate(droneMovement, Space.World);
		}
		if(this.transform.position.x >= resetPoint){
			this.transform.position = startPos;
		}
	}
	
	void switchValues(float a, float b){
		float temp = a;
		a = b;
		b = temp;		
	}
	
	float SineWave(float A, float wt){
		float y;
		y = A * Mathf.Sin(wt);
		return y;
	}
}
