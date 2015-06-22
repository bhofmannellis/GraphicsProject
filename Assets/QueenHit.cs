using UnityEngine;
using System.Collections;

public class QueenHit : MonoBehaviour {
	
	public Animation attackAnimation;
	
	void Awake() {
		// Get animations for Queen
		if (attackAnimation == null) 
			attackAnimation = GameObject.Find ("QueenModel").GetComponent<Animation> ();
		
	}
	
	void OnTriggerEnter(Collider col) {
		
		if ((attackAnimation != null) && (attackAnimation.isPlaying)) {
			
			// Check that QueenTarget exists in the game space
			if (GameObject.Find ("AceTarget") != null) {
				// Next, check that the collision is with the Queen's hitbox
				if (col.gameObject.name == "Bip01") {
					
					// If so, apply damage
					GameObject.FindObjectOfType<HealthScript> ().hitAce (20);
				}
			}
			
			// Check that KingTarget exists in the game space
			if (GameObject.Find ("JackTarget") != null) {
				// Next, check that the collision is with the King's hitbox
				if (col.gameObject.name == "Bip01"){
					
					// If so, apply damage
					GameObject.FindObjectOfType<HealthScript> ().hitJack (25);		
				}
			} 
		}
	}
}