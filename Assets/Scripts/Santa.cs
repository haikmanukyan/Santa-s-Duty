using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Santa : MonoBehaviour 
{
	Rigidbody2D rigidbody;
	GameObject planet;
	public float Velocity = 10.0f;

	void Start () 
	{
		planet = GameObject.FindGameObjectWithTag("Planet");
		rigidbody = GetComponent<Rigidbody2D>();

		Vector2 down = planet.transform.position - transform.position;
		Vector2 forward;
		forward.x = -down.y;
		forward.y = down.x;
		forward.Normalize();

		rigidbody.velocity = forward * Velocity;
	}
	
	void Update () 
	{
		Vector2 down = planet.transform.position - transform.position;
		Vector2 forward;
		forward.x = -down.y;
		forward.y = down.x;
		forward.Normalize();

		rigidbody.velocity = forward * Velocity;

		float angle = Mathf.Atan2(forward.y, forward.x) * Mathf.Rad2Deg;
		rigidbody.MovePosition();		
		rigidbody.MoveRotation(angle);
	}
}
