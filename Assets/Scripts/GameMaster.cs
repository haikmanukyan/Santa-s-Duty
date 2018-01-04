using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public Transform PresentPrefab;

    public static Rigidbody2D Planet;
    public static GameObject Santa;

	public static Vector2 GetForward(Rigidbody2D obj)
	{
		if (Planet == null)
        {
            return Vector2.zero;
        }

        Vector2 down = Planet.position - obj.position;
        Vector2 forward;
        forward.x = - down.y;
        forward.y = down.x;
        forward.Normalize();
        
		return forward;
	}
    public static float GetAngle(GameObject obj)
    {
        if (Planet == null)
        {
            return 0.0f;
        }

        Vector2 down = Planet.transform.position - obj.transform.position;
        Vector2 forward;
        forward.x = down.y;
        forward.y = -down.x;
        forward.Normalize();
        float angle = Mathf.Atan2(-forward.y, -forward.x) * Mathf.Rad2Deg;

        return angle;
    }

    void Start()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Planet");
		Planet = obj.GetComponent<Rigidbody2D>();

        Santa = GameObject.FindGameObjectWithTag("Santa");
    }

    void Update()
    {
        if (false && Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Input.mousePosition;
            pos.z = 10;
            pos = Camera.main.ScreenToWorldPoint(pos);
            GameObject present = Instantiate(PresentPrefab, pos, Quaternion.identity).gameObject;

            float angle = GetAngle(present);
            present.GetComponent<Rigidbody2D>().MoveRotation(angle);
        }
    }
}
