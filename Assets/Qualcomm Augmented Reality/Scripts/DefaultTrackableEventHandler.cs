/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Qualcomm Connected Experiences, Inc.
==============================================================================*/

using UnityEngine;

namespace Vuforia
{
    /// <summary>
    /// A custom handler that implements the ITrackableEventHandler interface.
    /// </summary>
    public class DefaultTrackableEventHandler : MonoBehaviour,
                                                ITrackableEventHandler
    {
        #region PRIVATE_MEMBER_VARIABLES
 
        private TrackableBehaviour mTrackableBehaviour;
    
        #endregion // PRIVATE_MEMBER_VARIABLES

        #region UNTIY_MONOBEHAVIOUR_METHODS
    
        void Start()
        {
            mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }
        }

        #endregion // UNTIY_MONOBEHAVIOUR_METHODS



        #region PUBLIC_METHODS

        /// <summary>
        /// Implementation of the ITrackableEventHandler function called when the
        /// tracking state changes.
        /// </summary>
        public void OnTrackableStateChanged(
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                OnTrackingFound();
            }
            else
            {
                OnTrackingLost();
            }
        }

        #endregion // PUBLIC_METHODS



        #region PRIVATE_METHODS


        private void OnTrackingFound()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Enable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = true;
            }

            // Enable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = true;
            }

			// Check which character was found and show their health bar
			CheckAceDrawCanvas (true);
			CheckJackDrawCanvas (true);
			CheckQueenDrawCanvas (true);
			CheckKingDrawCanvas (true);

            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
        }


        private void OnTrackingLost()
        {
			// Check which character is no longer being tracked and hide that character's heath bar
			CheckAceDrawCanvas (false);
			CheckJackDrawCanvas (false);
			CheckQueenDrawCanvas (false);
			CheckKingDrawCanvas (false);

            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Disable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = false;
            }

            // Disable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = false;
            }

            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
        }

		// Show or hide Ace health bar depending on 'enable' flag
		private void CheckAceDrawCanvas(bool enable){
			// First check if Ace object is instantiated
			if (GameObject.Find ("AceTarget") != null) {
				// Next, check if parent object which called this method is the AceTarget
				if (transform.gameObject.GetInstanceID () == GameObject.Find("AceTarget").GetInstanceID()) {
					// If 'enable' flag is true, draw healthbar, if false, hide healthbar
					if (enable){
						GameObject.Find ("AceHealthUICanvas").GetComponent<CanvasGroup> ().alpha = 1;
					} else {
						GameObject.Find ("AceHealthUICanvas").GetComponent<CanvasGroup> ().alpha = 0;
					}
				}
			}
		}

		// Show or hide Jack health bar depending on 'enable' flag
		private void CheckJackDrawCanvas(bool enable){
			// First check if Jack object is instantiated
			if (GameObject.Find ("JackTarget") != null) {
				// Next, check if parent object which called this method is the JackTarget
				if (transform.gameObject.GetInstanceID () == GameObject.Find ("JackTarget").GetInstanceID ()){
					// If 'enable' flag is true, draw healthbar, if false, hide healthbar
					if (enable) {
						GameObject.Find ("JackHealthUICanvas").GetComponent<CanvasGroup> ().alpha = 1;
					} else {
						GameObject.Find ("JackHealthUICanvas").GetComponent<CanvasGroup> ().alpha = 0;
					}
				}
			}
		}
		
		// Show or hide Queen health bar depending on 'enable' flag
		private void CheckQueenDrawCanvas(bool enable){
			// First check if Queen object is instantiated
			if (GameObject.Find ("QueenTarget") != null) {
				// Next, check if parent object which called this method is the QueenTarget
				if (transform.gameObject.GetInstanceID () == GameObject.Find ("QueenTarget").GetInstanceID ()) {
					// If 'enable' flag is true, draw healthbar, if false, hide healthbar
					if (enable) {
						GameObject.Find ("QueenHealthUICanvas").GetComponent<CanvasGroup> ().alpha = 1;
					} else {
						GameObject.Find ("QueenHealthUICanvas").GetComponent<CanvasGroup> ().alpha = 0;
					}
				}
			}
		}
		
		// Show or hide King health bar depending on 'enable' flag
		private void CheckKingDrawCanvas(bool enable){
			// First check if King object is instantiated
			if (GameObject.Find ("KingTarget") != null) {
				// Next, check if parent object which called this method is the KingTarget
				if (transform.gameObject.GetInstanceID () == GameObject.Find("KingTarget").GetInstanceID()){
					// If 'enable' flag is true, draw healthbar, if false, hide healthbar
					if (enable) {
						GameObject.Find ("KingHealthUICanvas").GetComponent<CanvasGroup> ().alpha = 1;
					} else {
						GameObject.Find ("KingHealthUICanvas").GetComponent<CanvasGroup> ().alpha = 0;
					}
				}
			}
		}

        #endregion // PRIVATE_METHODS
    }
}
