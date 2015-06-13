using UnityEngine;
using System.Collections.Generic;
using Vuforia;

public class VirtualButtonEvent : MonoBehaviour, IVirtualButtonEventHandler {

	private GameObject AceObject;
	private GameObject JackObject;
	private GameObject KingObject;
	private GameObject QueenObject;

	private Animation AceAnimation;
	private Animation JackAnimation;
	private Animation KingAnimation;
	private Animation QueenAnimation;

	// Use this for initialization
	void Start () {
		VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour> ();
		// foreach (VirtualButtonBehaviour item in vbs)
		// 	vbs [i].RegisterEventHandler(this);

		for (int i = 0; i < vbs.Length; i++)
			vbs [i].RegisterEventHandler(this);

		// AceObject = transform.FindChild ("AceModel").gameObject;
		// AceAnimation = AceObject.GetComponent<Animation> ();
		AceObject = GameObject.Find ("AceModel");
		AceAnimation = AceObject.GetComponent<Animation> ();

		// JackObject = transform.FindChild ("JackModel").gameObject;
		// JackAnimation = JackObject.GetComponent<Animation> ();
		JackObject = GameObject.Find ("JackModel");
		JackAnimation = JackObject.GetComponent<Animation> ();

		// KingObject = transform.FindChild ("KingModel").gameObject;
		// KingAnimation = KingAnimation.GetComponent<Animation> ();
		KingObject = GameObject.Find ("KingModel");
		KingAnimation = KingObject.GetComponent<Animation> ();

		// QueenObject = transform.FindChild ("QueenModel").gameObject;
		// QueenAnimation = QueenObject.GetComponent<Animation> ();
		QueenObject = GameObject.Find ("QueenModel");
		QueenAnimation = QueenObject.GetComponent<Animation> ();

	}

	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb){
		switch (vb.VirtualButtonName){
		case "AceAttackButton":
			// AceAnimation.Play("AceAttack1");
			// AceAnimation.PlayQueued("AceIdle", QueueMode.CompleteOthers);
			Debug.Log ("<<<<<AceAttack Pressed>>>>>");
			break;
		case "AceSpecialButton":
			// AceAnimation.Play("AceAttack2");
			// AceAnimation.PlayQueued("AceIdle", QueueMode.CompleteOthers);
			Debug.Log("<<<<<AceSpecial Pressed>>>>>");
			break;
		case "JackAttackButton":
			// JackAnimation.Play("JackAttack1");
			// JackAnimation.PlayQueued("JackIdle", QueueMode.CompleteOthers);
			Debug.Log("<<<<<JackAttack Pressed>>>>>");
			break;
		case "JackSpecialButton":
			// JackAnimation.Play("JackAttack1");
			// JackAnimation.PlayQueued("JackIdle", QueueMode.CompleteOthers);
			Debug.Log("<<<<<JackSpecial Pressed>>>>>");
			break;
		case "KingAttackButton":
			// KingAnimation.Play("KingAttack1");
			// KingAnimation.PlayQueued("KingIdle", QueueMode.CompleteOthers);
			Debug.Log("<<<<<KingAttack Pressed>>>>>");
			break;
		case "KingSpecialButton":
			// KingAnimation.Play("KingAttack1");
			// KingAnimation.PlayQueued("KingIdle", QueueMode.CompleteOthers);
			Debug.Log("<<<<<KingSpecial Pressed>>>>>");
			break;
		case "QueenAttackButton":
			// QueenAnimation.Play("QueenAttack1");
			// QueenAnimation.PlayQueued("QueenIdle", QueueMode.CompleteOthers);
			Debug.Log("<<<<<QueenAttack Pressed>>>>>");
			break;
		case "QueenSpecialButton":
			// QueenAnimation.Play("QueenAttack2");
			// QueenAnimation.PlayQueued("QueenIdle", QueueMode.CompleteOthers);
			Debug.Log("<<<<<QueenSpecial Pressed>>>>>");
			break;
		}
	}

	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb){
		switch (vb.VirtualButtonName){
		case "AceAttackButton":
			AceAnimation.Play("AceAttack1");
			AceAnimation.PlayQueued("AceIdle", QueueMode.CompleteOthers);
			Debug.Log ("<<<<<AceAttack Released>>>>>");
			break;
		case "AceSpecialButton":
			AceAnimation.Play("AceAttack2");
			AceAnimation.PlayQueued("AceIdle", QueueMode.CompleteOthers);
			Debug.Log("<<<<<AceSpecial Released>>>>>");
			break;
		case "JackAttackButton":
			JackAnimation.Play("JackAttack1");
			JackAnimation.PlayQueued("JackIdle", QueueMode.CompleteOthers);
			Debug.Log("<<<<<JackAttack Released>>>>>");
			break;
		case "JackSpecialButton":
			JackAnimation.Play("JackAttack2");
			JackAnimation.PlayQueued("JackIdle", QueueMode.CompleteOthers);
			Debug.Log("<<<<<JackSpecial Released>>>>>");
			break;
		case "KingAttackButton":
			KingAnimation.Play("KingAttack1");
			KingAnimation.PlayQueued("KingIdle", QueueMode.CompleteOthers);
			Debug.Log("<<<<<KingAttack Released>>>>>");
			break;
		case "KingSpecialButton":
			KingAnimation.Play("KingAttack2");
			KingAnimation.PlayQueued("KingIdle", QueueMode.CompleteOthers);
			Debug.Log("<<<<<KingSpecial Released>>>>>");
			break;
		case "QueenAttackButton":
			QueenAnimation.Play("QueenAttack1");
			QueenAnimation.PlayQueued("QueenIdle", QueueMode.CompleteOthers);
			Debug.Log("<<<<<QueenAttack Released>>>>>");
			break;
		case "QueenSpecialButton":
			QueenAnimation.Play("QueenAttack2");
			QueenAnimation.PlayQueued("QueenIdle", QueueMode.CompleteOthers);
			Debug.Log("<<<<<QueenSpecial Released>>>>>");
			break;
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
