using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour 
{
	public float Torque = 1.0f;
	private Rigidbody2D rigidbody;

	void Start () 
	{
		rigidbody = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () 
	{	
		rigidbody.MoveRotation(rigidbody.rotation + Torque);
	}
}
