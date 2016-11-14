using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	private float speed = 10.0f;
	private Vector3 movePosition;
	private bool onTheMove = false;
	private Transform playerTransform;

	private void Start()
	{
		movePosition = Vector3.zero;
		playerTransform = GetComponent<Transform> ();
	}

	private void Update()
	{
		CheckInput ();
		Move ();
	}

	private void CheckInput()
	{
		if (Input.GetMouseButtonDown (0))
		{
			onTheMove = true;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, 300.0f))
			{
				movePosition = hit.point;
			}
		}
	}

	private void Move()
	{
		if (onTheMove) 
		{
			Vector3 direction = movePosition - playerTransform.position; 
			direction.y = 0;
			direction = direction.magnitude > 1 ? direction.normalized : direction;
			if (direction.magnitude > 0.01f) {
				playerTransform.Translate (direction * speed * Time.deltaTime);
			}
			else
			{
				onTheMove = false;
			}
		}
	}
}
