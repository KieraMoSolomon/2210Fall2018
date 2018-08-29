using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{

	public float Speed;
	public float Gravity;
	
	private Vector3 moveDirection;
	
	private CharacterController controller;
	
	// Use this for initialization
	void Start ()
	{
		controller = GetComponent<CharacterController>();
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		Move(controller, transform);
	}

	void Move(CharacterController controller, Transform transform)
	{
		if (controller.isGrounded)
		{
			if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				moveDirection.Set(1f, 0, 0);
				moveDirection = transform.TransformDirection(moveDirection);
				moveDirection *= Speed;
			}

			else if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				moveDirection.Set(-1f, 0, 0);
				moveDirection = transform.TransformDirection(moveDirection);
				moveDirection *= Speed;
			}
			
		}

		moveDirection.y -= Gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
}
