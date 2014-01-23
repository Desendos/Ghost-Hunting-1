//Michael Bishop
//Robert Wells

using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	public float m_speed = 6.0f;
	public float m_jumpSpeed = 8.0f;
	public float m_gravity = 20.0f;
	
	private Vector3 m_moveDirection = Vector3.zero;
	private float m_leftStickY = 0.0f;
	private float m_leftStickX = 0.0f;
	//private float m_jumpHeight = 0.0f;

	// Use this for initialization
	void Start ()
	{
		Messenger.AddListener<float>("360_LeftStick_Y", leftStickY);
		Messenger.AddListener<float>("360_LeftStick_X", leftStickX);
	}
	
	// Update is called once per frame
	void Update ()
	{
		CharacterController m_controller = GetComponent<CharacterController>();
		
		leftStickY(m_leftStickY);
		leftStickX(m_leftStickX);
		
		if (m_controller.isGrounded)
		{					
			m_moveDirection = new Vector3(m_leftStickY,0,m_leftStickX);
			m_moveDirection = transform.TransformDirection(m_moveDirection);;
			m_moveDirection *= m_speed;
			
			if(Input.GetButton("360_AButton"))
			{
				m_moveDirection.y = m_jumpSpeed;									
			}
		}
		m_moveDirection.y -= m_gravity * Time.deltaTime;			
		m_controller.Move(m_moveDirection * Time.deltaTime);

	}
	
	void leftStickY(float adj)
	{	
		m_leftStickY = adj;
	}
	
	void leftStickX(float adj)
	{
		m_leftStickX = adj;
	}

}
