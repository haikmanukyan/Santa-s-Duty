using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour 
{
	public float Torque = 1.0f;
	public Rigidbody2D body;

	void Start () 
	{
		body = GetComponent<Rigidbody2D>();
		body.angularVelocity = Torque;
	}
	
	void FixedUpdate () 
	{	
		//rigidbody.MoveRotation(rigidbody.rotation + Torque);
	}
}
