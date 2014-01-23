using UnityEngine;
using System.Collections;

public class CreateLantern : MonoBehaviour 
{
	
	public GameObject Lantern;
	public float cooldownTimer;
	public float lanternLifeSpan;
	
	GameObject m_newLantern;
	float m_time;
	bool m_cooldown;
	bool m_lanternPlaced;
	
	void Start () 
	{
		
		m_newLantern = null;
		m_cooldown = false;
		m_time = 0;
	}
	
	void Update ()
	{
		//Resets the cooldown
		if(m_cooldown)
		{
			if(Time.time > m_time+cooldownTimer)
			{
				m_cooldown = false;
			}
		}
		
		//Create a new lantern when e is pressed if it isnt on cooldown
		if(Input.GetKeyDown("q") && !m_cooldown)
		{
			//Clean up previous lantern
			if(m_lanternPlaced)
			{
				//Add effect here - Future change
				Destroy(m_newLantern);
				m_newLantern = null;
			}
			
			m_time = Time.time;
			m_cooldown = true;
			m_lanternPlaced = true;
			
			//Change creation position to specific location - Future change
			m_newLantern = Instantiate(Lantern, transform.position, Quaternion.identity) as GameObject;
		}
		
		//Deletes the lantern after a given time
		if(m_lanternPlaced){
			if(Time.time > m_time+lanternLifeSpan){
				Destroy(m_newLantern);
				m_newLantern = null;
				m_lanternPlaced = false;
			}
		}
	}
}
