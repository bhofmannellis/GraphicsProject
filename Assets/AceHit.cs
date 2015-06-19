using UnityEngine;
using System.Collections;

public class AceHit : MonoBehaviour {
	
	// Drag the main object's Animation component onto this in the Inspector:
	public Animation attackAnimation;

	void Awake() {
		// Get animations for Ace
		if (attackAnimation == null) 
			attackAnimation = GameObject.Find ("AceModel").GetComponent<Animation> ();	
	}
	
	void OnTriggerEnter(Collider col) {

		if ((attackAnimation != null) && (attackAnimation.isPlaying)) {

			// Check that QueenTarget exists in the game space
			if (GameObject.Find ("QueenTarget") != null) {
				// Next, check that the collision is with the Queen's hitbox
				if (col.gameObject.name == "Chr_Hips") {

					// If so, apply damage according to which attack is active
					if (attackAnimation ["AceAttack1"].enabled)
						GameObject.FindObjectOfType<HealthScript> ().hitQueen (25);
					else if (attackAnimation ["AceAttack2"].enabled)
						GameObject.FindObjectOfType<HealthScript> ().hitQueen (50);
				}
			}

			// Check that KingTarget exists in the game space
			if (GameObject.Find ("KingTarget") != null) {
				// Next, check that the collision is with the King's hitbox
				if (col.gameObject.name == "Bip001"){
			
					// If so, apply damage according to which attack is active
					if (attackAnimation ["AceAttack1"].enabled)
						GameObject.FindObjectOfType<HealthScript> ().hitKing (10);
					else if (attackAnimation ["AceAttack2"].enabled)
						GameObject.FindObjectOfType<HealthScript> ().hitKing (20);		
				}
			} 
		}
	}
}