using UnityEngine;
using System.Collections;

public class ghostCapture : MonoBehaviour {
	public int captureRange = 10;
	public string captureKey = "e";
	
	//Used for modifying the percentages over time
	public int captureTime = 3;
	public int captureDecreaseTime = 6;
	public int batteryDrainTime = 10;
	public int batteryChargeTime = 15;
	
	float m_capturePercent;
	float m_batteryPercent;
	
	bool m_hasHitGhost;
	bool m_batteryCharged;
	bool m_captureKeyPressed;
	
	Transform m_cam;
	
	void Start () 
	{
		m_capturePercent = 0;
		m_batteryPercent = 100;
		
		//These checks make sure that a divide by 0 error doesnt happen later in the code
		if(captureDecreaseTime <= 0)
		{
			captureDecreaseTime = 1;	
		}
		if(captureTime <= 0)
		{
			captureTime = 1;	
		}
		
		m_hasHitGhost = false;
		m_batteryCharged = true;
		m_captureKeyPressed = false;
	}
	
	void Update () 
	{
		m_cam = Camera.main.transform;
		RaycastHit hit;
		m_hasHitGhost = false;
		m_captureKeyPressed = false;
		
		if(Input.GetKey(captureKey))
		{
			m_captureKeyPressed = true;
		}
		
		//If the battery hasn't been depleted, the player has pressed the capture key and the ray has hit the ghost the hasHitGhost bool is set to true
		if(m_batteryCharged)
		{
			if(m_captureKeyPressed)
			{
				if(Physics.Raycast(m_cam.position, m_cam.TransformDirection(Vector3.forward), out hit, captureRange))
				{
					if(hit.transform.tag == "ghost")
					{
						m_hasHitGhost = true;
					}
					else
					{
						m_hasHitGhost = false;
					}
				}
			}
		}
		
		//Increases capture percent when a ghost has been hit
		if(m_hasHitGhost)
		{
			if(!GetComponent<ParticleSystem>().isPlaying)
			{
				GetComponent<ParticleSystem>().Play();	
			}
			m_capturePercent += Time.deltaTime * (100/captureTime);
			m_batteryPercent += Time.deltaTime * (100/batteryChargeTime);	
		}
		//Decreases the capture time if a ghost hasn't been hit
		else 
		{
			GetComponent<ParticleSystem>().Stop();
			m_capturePercent -= Time.deltaTime * (100/captureDecreaseTime);
			//Decreases the battery charge when the device is used without hitting a ghost
			if(m_captureKeyPressed)
			{
				m_batteryPercent -= Time.deltaTime * (100/batteryDrainTime);	
			}
			else
			{
				m_batteryPercent += Time.deltaTime * (100/batteryChargeTime);	
			}
		}
		
		//Below keeps the percentage variables within 0 - 100 range
		if(m_capturePercent >= 100)
		{
			Destroy(hit.transform.gameObject);
			m_capturePercent = 0;
		}
		else if(m_capturePercent <= 0)
		{
			m_capturePercent = 0;	
		}
		
		if(m_batteryPercent <= 0)
		{
			m_batteryCharged = false;
			m_batteryPercent = 0;
		}
		else if(m_batteryPercent >= 100)
		{
			m_batteryCharged = true;
			m_batteryPercent = 100;
		}
		
		m_hasHitGhost = false;
	}
	
	void OnGUI()
	{
		GUI.Box(new Rect(10, 10, 200, 25), "Capture Percent : " + (int)m_capturePercent);
		GUI.Box(new Rect(10, 40, 200, 25), "Battery Charge : " + (int)m_batteryPercent);
		if(!m_batteryCharged)
		{
			GUI.Box(new Rect(10, 70, 200, 25), "BATTERY DEPLETED");
		}
	}
}
