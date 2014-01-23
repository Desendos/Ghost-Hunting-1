using UnityEngine;
using System.Collections;


public class Hider : MonoBehaviour {
	public int interactionDistance = 10;
	
	bool m_isHiding;
	
	Furniture furnitureScript;
	
	Transform m_cam;

	void Start () 
	{
		m_isHiding = false;
	}
	
	void Update ()
	{
		m_cam = Camera.main.transform;
		RaycastHit hit;
		
		//If the player isnt hiding it will restrict player movement when 'e' is pressed
		if(!m_isHiding)
		{
			if(Physics.Raycast(m_cam.position, m_cam.TransformDirection(Vector3.forward), out hit, interactionDistance))
			{
				if(hit.transform.tag == "furniture")
				{
					if(Input.GetKeyDown("e"))
					{
						furnitureScript = hit.transform.GetComponentInChildren<Furniture>();
						if(furnitureScript.setHider(transform))
						{
							m_isHiding = true;	
						}
						//set player movement restrictions
					}
				}
			}
		}
		//If the player is hiding, pressing 'e' will release player movement
		else
		{
			if(Input.GetKeyDown("e"))
			{
				stopHiding();
//				transform.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
				//GetComponent<Rigidbody>().constraints
				furnitureScript.releaseHider();
			}
		}
	}
	
	public void stopHiding()
	{
		m_isHiding = false;
//		transform.rigidbody.constraints = RigidbodyConstraints.None;
		//release player movement restrictions
	}
}
