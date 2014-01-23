using UnityEngine;
using System.Collections;

public class ObjectInteraction : MonoBehaviour {
	
	public float range;
	public float objectTransSpeed;
	public int throwingPower;
	
	float startTime;
	float journeyLength;
	GameObject interObject;
	GameObject m_displayText;
	RaycastHit m_hit;
	Ray m_ray;
	bool pickUp;

	void Start () 
	{
		m_displayText = GameObject.FindGameObjectWithTag("playertext");
		pickUp = false;
	}
	
	void Update () 
	{	
		m_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Debug.DrawRay(m_ray.origin, this.transform.forward*range, Color.blue);
		
		if(Physics.Raycast( m_ray, out m_hit, range)){
			if(m_hit.transform.tag == "object"){
				m_displayText.guiText.text = "Press E to Pick Up";
				m_displayText.guiText.enabled = true;
			}else{
				m_displayText.guiText.enabled = false;
			}
		}else{
			m_displayText.guiText.enabled = false;
		}
		
		if(Input.GetKeyDown("e")){
			if(!pickUp && Physics.Raycast( m_ray, out m_hit, range)){
				if(m_hit.transform.tag == "object"){
					interObject = m_hit.transform.gameObject;
					startTime = Time.time;
					journeyLength = Vector3.Distance(interObject.transform.localPosition, new Vector3(0, 0, interObject.transform.localPosition.z));
					pickUp = true;
				}
			}else if(pickUp){
				interObject.rigidbody.useGravity = true;
				interObject.transform.parent = null;
				interObject.rigidbody.constraints = RigidbodyConstraints.None;
				pickUp = false;
			}
		}
		
		if(pickUp && Input.GetMouseButton(0)){
			interObject.rigidbody.AddForce(this.transform.GetChild(1).transform.forward*throwingPower);
			interObject.rigidbody.useGravity = true;
			interObject.transform.parent = null;
			interObject.rigidbody.constraints = RigidbodyConstraints.None;
			pickUp = false;
		}
		
		if(pickUp){
			interObject.transform.parent = this.transform.GetChild(1);
			float distCovered = (Time.time - startTime) * objectTransSpeed;
			float fracJourney = distCovered/journeyLength;
			interObject.transform.localPosition = Vector3.Lerp(interObject.transform.localPosition, new Vector3(0, 0, interObject.transform.localPosition.z), fracJourney);
			interObject.rigidbody.useGravity = false;
			interObject.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
		}
	}
}
