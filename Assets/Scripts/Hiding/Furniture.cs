using UnityEngine;
using System.Collections;

public class Furniture : MonoBehaviour {
	public enum Player{Ghost, Hunter, GhostAndHunter};
	
	public Player whoCanHide = Player.GhostAndHunter;
	
	public bool m_hasHider;
	
	public Transform m_hider;

	void Start()
	{
		m_hasHider = false;
	}
	
	/*
	//Code for letting ghosts hide in furniture if needed in the future
	//checks the tag of the hider against the tag of whoCanHide
	//If true the hider can hide in this object
	bool checkHiderTag(string tag)
	{
		switch(whoCanHide)
		{
		case Player.Ghost:
			if(tag == "ghost")
			{
				return true;	
			}
			break;
		case Player.Hunter:
			if(tag == "hunter")
			{
				return true;	
			}
			break;
		case Player.GhostAndHunter:
			if(tag == "ghost" || tag == "hunter")
			{
				return true;	
			}
			break;
		default:
			return false;
		}
		return false;
	}
	*/
	
	//will set the hider if there isn't a hider
	public bool setHider(Transform hider)
	{
		if(!m_hasHider)
		{
			m_hider = hider;
			m_hider.transform.position = transform.position;
			m_hasHider = true;
			return true;
		}
		else
		{
			releaseHider();
			return false;
		}
	}
	
	//release's the hider so they can continue moving
	public void releaseHider()
	{
		m_hider.GetComponent<Hider>().stopHiding();
		m_hider = null;
		m_hasHider = false;
	}
}