/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Qualcomm Connected Experiences, Inc.
==============================================================================*/

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

using UnityEngine;
using System.Collections;

public class Custom_VirtualButton : MonoBehaviour, IVirtualButtonEventHandler
{
	// Use this for initialization
	void Start () {
		
		// here it finds any VirtualButton Attached to the ImageTarget and register it's event handler and in the
		//OnButtonPressed and OnButtonReleased methods you can handle different buttons Click state
		//via "vb.VirtualButtonName" variable and do some really awesome stuff with it.
		VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
		foreach (VirtualButtonBehaviour item in vbs)
		{
			item.RegisterEventHandler(this);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
	#region VirtualButton
	
	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb)
	{
		Debug.Log("Helllllloooooooooo");
	}
	
	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb)
	{
		Debug.Log("Goooooodbyeeee");
	}
	
	#endregion //VirtualButton
}
