using UnityEngine;
using System.Collections;

public class KingHit : MonoBehaviour {
	
	// Drag the main object's Animation component onto this in the Inspector:
	public Animation attackAnimation;
	
	void Awake() {
		// Get animations for Ace
		if (attackAnimation == null) 
			attackAnimation = GameObject.Find ("KingModel").GetComponent<Animation> ();
		
	}
	
	void OnTriggerEnter(Collider col) {
		
		if ((attackAnimation != null) && (attackAnimation.isPlaying)) {
			
			// Check that QueenTarget exists in the game space
			if (GameObject.Find ("AceTarget") != null) {
				// Next, check that the collision is with the Queen's hitbox
				if (col.gameObject.name == "Bip01") {
					
					// If so, apply damage if the attack is active
					if (attackAnimation ["AceAttack1"].enabled)
						GameObject.FindObjectOfType<HealthScript> ().hitAce (50);
				}
			}
			
			// Check that KingTarget exists in the game space
			if (GameObject.Find ("JackTarget") != null) {
				// Next, check that the collision is with the King's hitbox
				if (col.gameObject.name == "Bip001"){
					
					// If so, apply damage if the attack is active
					if (attackAnimation ["AceAttack1"].enabled)
						GameObject.FindObjectOfType<HealthScript> ().hitJack (50);
				}
			} 
		}
	}
}
