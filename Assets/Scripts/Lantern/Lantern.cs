using UnityEngine;
using System.Collections;

public class Lantern : MonoBehaviour 
{
	public float slowDuration;
	public float activationTimer;
	public float activationArea;
	
	public string message;
	
	public bool instantActivation;
	
	GameObject m_displayText;
	
	float m_time, m_slowTime;
	
	bool m_triggered;
	
	void Start () 
	{
		m_displayText = GameObject.FindWithTag("playertext");
		m_triggered = false;
		//Resize trigger area to activation area
		SphereCollider m_collider = gameObject.GetComponent<SphereCollider>();
		m_collider.radius = activationArea;
	}
	
	void Update () 
	{
		//Runs the slow function if it has been x seconds since it was activated
		if(m_triggered && (Time.time > m_time+activationTimer || instantActivation))
		{
			slow ();
		}
		
		if(m_triggered)
		{
			triggerEffects();
			m_displayText.guiText.text = message;
			m_displayText.guiText.enabled = true;
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		//if any ghosts enter the lanterns range it gets triggered
		if(other.transform.tag == "ghost" && !m_triggered)
		{
			m_triggered = true;
			m_time = Time.time;
		}
	}
	
	void slow()
	{
		if(Time.time > m_time+activationTimer+slowDuration)
		{
			m_displayText.guiText.enabled = false;
			Destroy(this.gameObject);
			m_triggered = false;
		}else
		{
			//Put code to slow enemy here - Future change
			print("slow");
		}
	}
	
	void triggerEffects(){
		//Put triggered effects here - Future change
	}
}
