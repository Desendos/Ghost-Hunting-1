//Michael Bishop

using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
	
	public bool isNewGame, isLoadGame, isOptions, isQuit;
	public int selectionIndex;	
	public string[] mainSelection;
	
	// Use this for initialization
	void Start () 
	{
		isNewGame = false;
		isLoadGame = false;
		isOptions =  false;
		isQuit = false;
		
		selectionIndex = 0;		
	}
	
	// Update is called once per frame
	void Update () 
	{	
		if(selectionIndex > 4)
		{
			selectionIndex = 4;
		}
		
		if(selectionIndex < 0)
		{
			selectionIndex = 0;			
		}
		
		if(Input.GetAxis("360_VerticalDPad") > 0)
		{
			selectionIndex -= 1;
		}
		
		if(Input.GetAxis("360_VerticalDPad") < 0)
		{
			selectionIndex += 1;
		}
	}
	
	void buttonAction()
	{
		if(isNewGame == true && selectionIndex == 0)
		{
			Application.LoadLevel("Test");
		}
		if(isLoadGame == true && selectionIndex == 1)
		{
			Application.LoadLevel("Test2");
		}
		if(isOptions == true && selectionIndex == 2)
		{
			//Application.CALLBULLSHIT	
		}
		if(isQuit == true && selectionIndex == 3)
		{
			Application.Quit();	
		}
	}
}
