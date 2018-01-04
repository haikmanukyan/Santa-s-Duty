using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
	new Rigidbody2D rigidbody;
	float angle = 0.0f;

	Vector2 targetDirection;
	public float Speed = 1.0f;

    void Start()
    {
		rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
		Vector2 clockwise = GameMaster.GetForward(rigidbody);
		Vector2 up;
		up.x = -clockwise.y;
		up.y = clockwise.x;

		angle = Mathf.Atan2(clockwise.y, clockwise.x) * Mathf.Rad2Deg;

		//rigidbody.MoveRotation(angle * Mathf.Rad2Deg);
		//Quaternion newRotation = Quaternion.EulerAngles(0, 0, angle);

		targetDirection = Vector2.zero;
		if (Input.GetKey(KeyCode.A))
		{
			targetDirection -= clockwise;
		}
		if (Input.GetKey(KeyCode.D))
		{
			targetDirection += clockwise;
		}

		if (Input.GetKeyUp(KeyCode.Space))
		{
			rigidbody.AddForce(500.0f * up);
		}

		Vector2 baseVelocity = GameMaster.Planet.angularVelocity * Vector2.Distance(rigidbody.position, 
							GameMaster.Planet.position) * Mathf.Deg2Rad * clockwise;

		
		float velocityComponent = Vector2.Dot(rigidbody.velocity + baseVelocity, clockwise);
		Vector2 relativeVelocity = rigidbody.velocity + baseVelocity;

		float velocityDifferenceComponent = Speed - Vector2.Dot(relativeVelocity, targetDirection);

		if (velocityDifferenceComponent > 0)
		{
			rigidbody.AddForce(velocityDifferenceComponent * 30.0f * targetDirection);
		}

		//graphics.transform.rotation = Quaternion.Euler(0,0,angle);
		rigidbody.MoveRotation(angle);

		if (velocityComponent > 1.0f)
			transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
		else if (velocityComponent < -1.0f)
			transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }

	void LateUpdate()
	{
	}
}
