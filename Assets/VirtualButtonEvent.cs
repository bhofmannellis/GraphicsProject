using UnityEngine;
using System.Collections.Generic;
using Vuforia;

public class VirtualButtonEvent : MonoBehaviour, IVirtualButtonEventHandler {

	private GameObject AceModel;
	private Animation AceAnimations;

	// Use this for initialization
	void Start () {
		VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour> ();
		for (int i = 0; i < vbs.Length; i++)
			vbs [i].RegisterEventHandler(this);
		AceModel = transform.FindChild ("AceModel").gameObject;
		AceAnimations = AceModel.GetComponent<Animation> ();
	}

	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb){
		switch (vb.VirtualButtonName){
		case "AceAttackButton":
			AceAnimations.Play("AceAttack1");
			AceAnimations.PlayQueued("AceIdle", QueueMode.CompleteOthers);
			Debug.Log ("<<<<<AceAttack Pressed>>>>>");
			break;
		case "AceSpecialButton":
			AceAnimations.Play("AceAttack2");
			AceAnimations.PlayQueued("AceIdle", QueueMode.CompleteOthers);
			Debug.Log("<<<<<AceSpecial Pressed>>>>>");
			break;
		}
	}

	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb){
		if (vb.VirtualButtonName == "AceAttack") {
			Debug.Log ("<<<<<AceAttack Released>>>>>");
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
