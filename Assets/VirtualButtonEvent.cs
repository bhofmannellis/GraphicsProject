using UnityEngine;
using System.Collections.Generic;
using Vuforia;

public class VirtualButtonEvent : MonoBehaviour, IVirtualButtonEventHandler {

	// private GameObject AceObject;
	// private GameObject JackObject;
	// private GameObject KingObject;
	// private GameObject QueenObject;

	// private Animation AceAnimation;
	// private Animation JackAnimation;
	// private Animation KingAnimation;
	// private Animation QueenAnimation;

	HealthScript hs;

	// Use this for initialization
	void Start () {
		// Application.targetFrameRate = 30;
		
		VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour> ();

		for (int i = 0; i < vbs.Length; i++) {
			vbs [i].RegisterEventHandler (this);
		}

		// AceObject = GameObject.Find ("AceModel");
		// AceAnimation = AceObject.GetComponent<Animation> ();

		// JackObject = GameObject.Find ("JackModel");
		// JackAnimation = JackObject.GetComponent<Animation> ();

		// KingObject = GameObject.Find ("KingModel");
		// KingAnimation = KingObject.GetComponent<Animation> ();

		// QueenObject = GameObject.Find ("QueenModel");
		// QueenAnimation = QueenObject.GetComponent<Animation> ();

	}

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

	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb){
		switch (vb.VirtualButtonName) {
		case "AceAttackButton":
			//if (hs.aceAlive){
				GameObject.Find ("AceModel").GetComponent<Animation> ().Play("AceAttack1");
				//GameObject.Find ("AceModel").GetComponent<Animation> ().PlayQueued("AceIdle", QueueMode.CompleteOthers);
			//}
			Debug.Log ("<<<<<AceAttack Released>>>>>");
			break;
		case "AceSpecialButton":
			//if (hs.aceAlive){
				GameObject.Find ("AceModel").GetComponent<Animation> ().Play("AceAttack2");
				//GameObject.Find ("AceModel").GetComponent<Animation> ().PlayQueued("AceIdle", QueueMode.CompleteOthers);
			//}
			Debug.Log ("<<<<<AceSpecial Released>>>>>");
			break;
		case "JackAttackButton":
			//if (hs.jackAlive){
				GameObject.Find ("JackModel").GetComponent<Animation> ().Play("JackAttack1");
				//GameObject.Find ("JackModel").GetComponent<Animation> ().PlayQueued("JackIdle", QueueMode.CompleteOthers);
			//}
			Debug.Log ("<<<<<JackAttack Released>>>>>");
			break;
		case "JackSpecialButton":
			//if (hs.jackAlive) {
				GameObject.Find ("JackModel").GetComponent<Animation> ().Play("JackAttack2");
				//GameObject.Find ("JackModel").GetComponent<Animation> ().PlayQueued("JackIdle", QueueMode.CompleteOthers);
			//}
			Debug.Log ("<<<<<JackSpecial Released>>>>>");
			break;
		case "KingAttackButton":
			//if (hs.kingAlive) {
				GameObject.Find ("KingModel").GetComponent<Animation> ().Play("KingAttack1");
				//GameObject.Find ("KingModel").GetComponent<Animation> ().PlayQueued("KingIdle", QueueMode.CompleteOthers);
			//}
			Debug.Log("<<<<<KingAttack Released>>>>>");
			break;
		case "KingSpecialButton":
			//if (hs.kingAlive){
				GameObject.Find ("KingModel").GetComponent<Animation> ().Play("KingAttack2");
				GameObject.FindObjectOfType<HealthScript>().kingDamageCooldown();
				//GameObject.Find ("KingModel").GetComponent<Animation> ().PlayQueued("KingIdle", QueueMode.CompleteOthers);
			//}
			Debug.Log("<<<<<KingSpecial Released>>>>>");
			break;
		case "QueenAttackButton":
			//if (hs.queenAlive){
				GameObject.Find ("QueenModel").GetComponent<Animation> ().Play("QueenAttack1");
				//GameObject.Find ("QueenModel").GetComponent<Animation> ().PlayQueued("QueenIdle", QueueMode.CompleteOthers);
			//}
			Debug.Log("<<<<<QueenAttack Released>>>>>");
			break;
		case "QueenSpecialButton":
			//if (hs.queenAlive){
				GameObject.Find ("QueenModel").GetComponent<Animation> ().Play("QueenAttack2");
				GameObject.FindObjectOfType<HealthScript>().healSpecial();
				//GameObject.Find ("QueenModel").GetComponent<Animation> ().PlayQueued("QueenIdle", QueueMode.CompleteOthers);
			//}
			Debug.Log("<<<<<QueenSpecial Released>>>>>");
			break;
		}
	}

	// Update is called once per frame
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
