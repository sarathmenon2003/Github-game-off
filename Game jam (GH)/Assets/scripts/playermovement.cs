using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
	public CharacterController2D controller;
	float horizontalMove = 0f;
	public float runSpeed;
	bool jump = false;

	void Update()
	{
		horizontalMove = Input.GetAxisRaw("Horizontal")* runSpeed;
		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
		}
	}
	void FixedUpdate()
	{
		controller.Move(horizontalMove* Time.fixedDeltaTime, false, jump) ;
		jump = false;
	}
}