using UnityEngine;
using System.Collections;

public class QueenHit : MonoBehaviour {
	
	// Drag the main object's Animation component onto this in the Inspector:
	public Animation attackAnimation;
	
	void Awake() {
		// Get animations for Ace
		if (attackAnimation == null) 
			attackAnimation = GameObject.Find ("QueenModel").GetComponent<Animation> ();
		
	}
	
	void OnTriggerEnter(Collider col) {
		
		if ((attackAnimation != null) && (attackAnimation.isPlaying)) {
			
			// Check that QueenTarget exists in the game space
			if (GameObject.Find ("AceTarget") != null) {
				// Next, check that the collision is with the Queen's hitbox
				if (col.gameObject.name == "Bip01") {
					
					// If so, apply damage according to which attack is active
					// if (attackAnimation ["AceAttack1"].enabled)
						GameObject.FindObjectOfType<HealthScript> ().hitAce (25);
				}
			}
			
			// Check that KingTarget exists in the game space
			if (GameObject.Find ("JackTarget") != null) {
				// Next, check that the collision is with the King's hitbox
				if (col.gameObject.name == "Bip01"){
					
					// If so, apply damage according to which attack is active
					// if (attackAnimation ["QueenAttack1"].enabled)
						GameObject.FindObjectOfType<HealthScript> ().hitJack (25);		
				}
			} 
		}
	}
}
