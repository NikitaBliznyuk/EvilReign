using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public Text touches;
	public GameObject fireBall;

	private float speed = 10.0f;
	private Vector3 movePosition;
	private bool onTheMove = false;
	private Transform playerTransform;

	private float lastShoot = 0.0f;

	public Characteristics PlayerCharacteristics { get; set; }

	public bool EnableToMove { get; set; }

	private void Start()
	{
		EnableToMove = true;
		InitializeCharacteristics ();
		movePosition = Vector3.zero;
		playerTransform = GetComponent<Transform> ();
	}

	private void InitializeCharacteristics()
	{
		PlayerCharacteristics = new Characteristics ();
		PlayerCharacteristics.MaxHealth = 100;
		PlayerCharacteristics.MaxEnergy = 100;
		PlayerCharacteristics.CurrentHealth = 78;
		PlayerCharacteristics.CurrentEnergy = 54;
		PlayerCharacteristics.Strength = 10;
		PlayerCharacteristics.Agility = 8;
		PlayerCharacteristics.Intelligence = 16;
		PlayerCharacteristics.Luck = 12;
		PlayerCharacteristics.AttackSpeed = 1.0f;
	}

	private void Update()
	{
		lastShoot += Time.deltaTime;
		touches.text = "" + (int)(1.0f / Time.smoothDeltaTime);
		if (EnableToMove)
		{
			CheckInput ();
			Move ();
		}
	}

	private void CheckInput()
	{
		if (Input.GetMouseButton(0))
		{
			onTheMove = true;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 300.0f))
			{
				movePosition = hit.point;
				RotatePlayer ();
				if (hit.collider.tag == "Enemy")
				{
					onTheMove = false;
					if (lastShoot >= PlayerCharacteristics.AttackSpeed)
					{
						lastShoot = 0.0f;
						GameObject.Instantiate (fireBall, playerTransform.position, playerTransform.rotation);
					}
				}
			}
		}
		else 
		{
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
				playerTransform.Translate (Vector3.forward * speed * Time.deltaTime);
			}
			else
			{
				onTheMove = false;
			}
		}
	}

	private void RotatePlayer()
	{
		playerTransform.LookAt (new Vector3(movePosition.x, playerTransform.position.y, movePosition.z));
	}
}
