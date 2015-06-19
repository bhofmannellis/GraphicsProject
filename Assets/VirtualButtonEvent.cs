using UnityEngine;
using System.Collections.Generic;
using Vuforia;

public class VirtualButtonEvent : MonoBehaviour, IVirtualButtonEventHandler {

	// Register listeners for Virtual Buttons
	void Start () {
		// Application.targetFrameRate = 30;
		
		VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour> ();

		for (int i = 0; i < vbs.Length; i++) {
			vbs [i].RegisterEventHandler (this);
		}
	}

	// Called when Virtual Button is pressed
	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb){
		switch (vb.VirtualButtonName){
		case "AceAttackButton":
			Debug.Log ("<<<<<AceAttack Pressed>>>>>");
			break;
		case "AceSpecialButton":
			Debug.Log("<<<<<AceSpecial Pressed>>>>>");
			break;
		case "JackAttackButton":
			Debug.Log("<<<<<JackAttack Pressed>>>>>");
			break;
		case "JackSpecialButton":
			Debug.Log("<<<<<JackSpecial Pressed>>>>>");
			break;
		case "KingAttackButton":
			Debug.Log("<<<<<KingAttack Pressed>>>>>");
			break;
		case "KingSpecialButton":
			Debug.Log("<<<<<KingSpecial Pressed>>>>>");
			break;
		case "QueenAttackButton":
			Debug.Log("<<<<<QueenAttack Pressed>>>>>");
			break;
		case "QueenSpecialButton":
			Debug.Log("<<<<<QueenSpecial Pressed>>>>>");
			break;
		}
	}

	// Called when Virtual Button is released -- First checks if character is alive
	// If so, animate attack/special
	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb){
		switch (vb.VirtualButtonName) {
		case "AceAttackButton":
			if (GameObject.FindObjectOfType<HealthScript> ().aceAlive){
				GameObject.Find ("AceModel").GetComponent<Animation> ().Play("AceAttack1");
			}
			Debug.Log ("<<<<<AceAttack Released>>>>>");
			break;
		case "AceSpecialButton":
			if (GameObject.FindObjectOfType<HealthScript> ().aceAlive){
				GameObject.Find ("AceModel").GetComponent<Animation> ().Play("AceAttack2");
			}
			Debug.Log ("<<<<<AceSpecial Released>>>>>");
			break;
		case "JackAttackButton":
			if (GameObject.FindObjectOfType<HealthScript> ().jackAlive){
				GameObject.Find ("JackModel").GetComponent<Animation> ().Play("JackAttack1");
			}
			Debug.Log ("<<<<<JackAttack Released>>>>>");
			break;
		case "JackSpecialButton":
			if (GameObject.FindObjectOfType<HealthScript> ().jackAlive) {
				GameObject.Find ("JackModel").GetComponent<Animation> ().Play("JackAttack2");
			}
			Debug.Log ("<<<<<JackSpecial Released>>>>>");
			break;
		case "KingAttackButton":
			if (GameObject.FindObjectOfType<HealthScript> ().kingAlive) {
				GameObject.Find ("KingModel").GetComponent<Animation> ().Play("KingAttack1");
			}
			Debug.Log("<<<<<KingAttack Released>>>>>");
			break;
		case "KingSpecialButton":
			if (GameObject.FindObjectOfType<HealthScript> ().kingAlive){
				GameObject.Find ("KingModel").GetComponent<Animation> ().Play("KingAttack2");
				GameObject.FindObjectOfType<HealthScript>().kingDamageCooldown();
			}
			Debug.Log("<<<<<KingSpecial Released>>>>>");
			break;
		case "QueenAttackButton":
			if (GameObject.FindObjectOfType<HealthScript> ().queenAlive){
				GameObject.Find ("QueenModel").GetComponent<Animation> ().Play("QueenAttack1");
			}
			Debug.Log("<<<<<QueenAttack Released>>>>>");
			break;
		case "QueenSpecialButton":
			if (GameObject.FindObjectOfType<HealthScript> ().queenAlive){
				GameObject.Find ("QueenModel").GetComponent<Animation> ().Play("QueenAttack2");
				GameObject.FindObjectOfType<HealthScript>().healSpecial();
			}
			Debug.Log("<<<<<QueenSpecial Released>>>>>");
			break;
		}
	}

	// Update is called once per frame -- Check if each model is alive and not animating, if so play Idle animation
	void Update () {
	
		// Check if models are animating and if not, play the Idle animation
		if (!GameObject.Find ("AceModel").GetComponent<Animation> ().isPlaying && GameObject.FindObjectOfType<HealthScript> ().aceAlive)
			GameObject.Find ("AceModel").GetComponent<Animation> ().Play ("AceIdle");
		if (!GameObject.Find ("JackModel").GetComponent<Animation> ().isPlaying && GameObject.FindObjectOfType<HealthScript> ().jackAlive)
			GameObject.Find ("JackModel").GetComponent<Animation> ().Play ("JackIdle");
		if (!GameObject.Find ("KingModel").GetComponent<Animation> ().isPlaying && GameObject.FindObjectOfType<HealthScript> ().kingAlive)
			GameObject.Find ("KingModel").GetComponent<Animation> ().Play ("KingIdle");
		if (!GameObject.Find ("QueenModel").GetComponent<Animation> ().isPlaying && GameObject.FindObjectOfType<HealthScript> ().queenAlive)
			GameObject.Find ("QueenModel").GetComponent<Animation> ().Play ("QueenIdle");
	}
}
