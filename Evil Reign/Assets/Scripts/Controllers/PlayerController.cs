using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public Text touches;

	private float speed = 10.0f;
	private Vector3 movePosition;
	private bool onTheMove = false;
	private Transform playerTransform;

	public Characteristics PlayerCharacteristics { get; set; }

	public bool EnableToMove { get; set; }

	private void Start()
	{
		EnableToMove = true;
		PlayerCharacteristics = new Characteristics ();
		PlayerCharacteristics.MaxHealth = 100;
		PlayerCharacteristics.MaxEnergy = 100;
		PlayerCharacteristics.CurrentHealth = 78;
		PlayerCharacteristics.CurrentEnergy = 54;
		movePosition = Vector3.zero;
		playerTransform = GetComponent<Transform> ();
	}

	private void Update()
	{
		touches.text = "" + Input.touchCount;
		if (EnableToMove) {
			CheckInput ();
			Move ();
		}
	}

	private void CheckInput()
	{
		if (Input.touchCount > 0) {
			onTheMove = true;
			Ray ray = Camera.main.ScreenPointToRay (new Vector3 (Input.GetTouch (0).position.x, Input.GetTouch (0).position.y, 0.0f));
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 300.0f)) {
				movePosition = hit.point;
			}
		} else {
			movePosition = playerTransform.position;
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
