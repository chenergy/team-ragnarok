using UnityEngine;
using System.Collections;

public class Ship_UI : MonoBehaviour {


	public float Speed = 2;
	
	void Update () {
	
		transform.Rotate(Vector3.forward * Time.deltaTime * Speed);
	}
}
