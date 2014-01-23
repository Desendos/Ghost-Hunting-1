//RobertWells
//MichaelBishop

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Input360Controller : MonoBehaviour {
	
	// Update is called once per frame
	void FixedUpdate () {
		leftStick();
		rightStick();
		faceButtons();
		dPad();
		shoulderButtons();
		startBack();
	}
	
	private void leftStick()
	{
		//360 LeftStick Down + Up
		if(Input.GetAxis("360_LeftStick_Y") > 0.2f || Input.GetAxis("360_LeftStick_Y") < -0.2f)
		{
			Messenger.Broadcast<float>("360_LeftStick_Y", Input.GetAxis("360_LeftStick_Y"));
			//Debug.Log("360 LeftStick Down");
		}
		else if(Input.GetAxis ("360_LeftStick_Y") < 0.2f || Input.GetAxis ("360_LeftStick_Y") > -0.2f)
		{
			Messenger.Broadcast<float>("360_LeftStick_Y", 0.0f);
		}
		//360 LeftStick Left + Right
		//if(Input.GetAxis("360_LeftStick_X") < 0 || Input.GetAxis("360_LeftStick_X") > 0)
		//{
			Messenger.Broadcast<float>("360_LeftStick_X", Input.GetAxis("360_LeftStick_X"));
			//Debug.Log("360 LeftStick Left");
		//}
		//360 Left Thumbstick Buttton
		if(Input.GetButtonDown("360_LeftThumbstickButton"))
		{
			//Broadcast sends a message of 360_LeftThumbstickButtonDown which the listener on another script will need to listen for.
			Messenger.Broadcast("360_LeftThumbstickButtonDown");
			//Debug.Log("360 Left Thumbstick Button");
		}		
	}
	
	private void rightStick()
	{
		//360 RightStick Down + Up
		if(Input.GetAxis("360_RightStick_Y") > 0 || Input.GetAxis("360_RightStick_Y") < 0)
		{
			
			Messenger.Broadcast<float>("360_RightStick_Y", Input.GetAxis("360_RightStick_Y"));
			//Debug.Log("360 RightStick Up");
		}
		//360 RightStick Left + Right
		if(Input.GetAxis("360_RightStick_X") < 0 || Input.GetAxis("360_RightStick_X") > 0)
		{
			Messenger.Broadcast<float>("360_RightStick_X", Input.GetAxis("360_RightStick_X"));
			//Debug.Log("360 RightStick Left");
		}
		//360 Right Thumbstick Buttton
		if(Input.GetButtonDown("360_RightThumbstickButton"))
		{
			Messenger.Broadcast("360_RightThumbstickButtonDown");
			//Debug.Log("360 Right Thumbstick Button");
		}
	}
	
	private void faceButtons()
	{
		//360 A Button
		if(Input.GetButtonDown("360_AButton"))
		{
			Messenger.Broadcast("360_AButton");
			//Debug.Log("360 A Button");
		}
		//360 B Button
		 if(Input.GetButtonDown("360_BButton"))
		{
			Messenger.Broadcast("360_BButton");
			//Debug.Log("360 B Button");
		}
		//360 X Button
		if(Input.GetButtonDown("360_XButton"))
		{
			Messenger.Broadcast("360_XButton");
			//Debug.Log("360 X Button");
		}
		//360 Y Button
		if(Input.GetButtonDown("360_YButton"))
		{
			Messenger.Broadcast("360_YButton");
			//Debug.Log("360 Y Button");
		}
	}
	
	private void dPad()
	{	
		//360 DPad Down + Up
		if(Input.GetAxis("360_VerticalDPad") > 0 || Input.GetAxis("360_VerticalDPad") < 0)
		{
			Messenger.Broadcast<float>("360_VerticalDPad", Input.GetAxis("360_VerticalDPad"));
			//Debug.Log("360 DPad Vertical = " + Input.GetAxis("
		}

		//360 DPad Left + Right
		if(Input.GetAxis("360_HorizontalDPad") < 0 || Input.GetAxis("360_HorizontalDPad") > 0)
		{
			Messenger.Broadcast<float>("360_HorizontalDPad", Input.GetAxis("360_HorizontalDPad"));
			//Debug.Log("360 DPad Horizontal = " + Input.GetAxis("360_HorizontalDPad"));
		}
	}
	
	private void shoulderButtons()
	{
		//360 Left Trigger
		if(Input.GetAxis("360_Left_Trigger") > 0)
		{
			Messenger.Broadcast<float>("360_Left_Trigger", Input.GetAxis("360_Left_Trigger"));
			//Debug.Log("360 Left Trigger");
		}
		//360 Right Trigger
		if(Input.GetAxis("360_Right_Trigger") < 0)
		{
			Messenger.Broadcast<float>("360_Right_Trigger", Input.GetAxis("360_Right_Trigger"));
			//Debug.Log("360 Right Trigger");
		}
		//360 RB
		if(Input.GetButtonDown("360_RightBumper"))
		{
			Messenger.Broadcast("360_RightBumper");
			//Debug.Log("360 Right Bumper");
		}
		//360 LB
		if(Input.GetButtonDown("360_LeftBumper"))
		{
			Messenger.Broadcast("360_LeftBumper");
			//Debug.Log("360 Left Bumper");
		}
	}
	
	private void startBack()
	{	
		//360 Start Button
		if(Input.GetButtonDown("360_StartButton"))
		{
			Messenger.Broadcast("360_StartButton");
			//Debug.Log("360 Start Button");
		}
		//360 Back Button
		if(Input.GetButtonDown("360_BackButton"))
		{
			Messenger.Broadcast("360_BackButton");
			//Debug.Log("360 Back Button");
		}
	}
}
