using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	private float speed = 10.0f;
	private Vector3 moveDirection;
	private Transform playerTransform;

	private void Start()
	{
		moveDirection = Vector3.zero;
		playerTransform = GetComponent<Transform> ();
	}

	private void Update()
	{
		CheckInput ();
		Move ();
	}

	private void CheckInput()
	{
		moveDirection.x = Input.GetAxis ("Horizontal");
		moveDirection.z = Input.GetAxis ("Vertical");
		moveDirection = moveDirection.magnitude > 1 ? moveDirection.normalized : moveDirection;
	}

	private void Move()
	{
		playerTransform.Translate (moveDirection * speed * Time.deltaTime);
	}
}
