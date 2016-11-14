using UnityEngine;
using System.Collections;

public class MainMenuController 
{
	private GameObject settingsButtons;

	private Transform buttonsTransform;
	private int direction;
	private float speed;
	private float startPosition;
	private float range;

	public MainMenuController()
	{
		buttonsTransform = GameObject.FindGameObjectWithTag ("Movable").GetComponent<Transform>();
		settingsButtons = GameObject.FindGameObjectWithTag ("Settings");
		settingsButtons.SetActive (false);
		direction = 0;
		speed = 4000.0f;
		range = Screen.width / 2;
		startPosition = buttonsTransform.position.x;
	}

	public void ShowSettings()
	{
		settingsButtons.SetActive (true);
	}

	private void CloseSetting()
	{
		settingsButtons.SetActive (false);
	}

	public void ShowWindow()
	{
		direction = -1;
	}

	public void CloseWindow()
	{
		direction = 1;
	}

	public void SaveSettings ()
	{
		Debug.Log ("Save settings");
	}

	public void Update()
	{
		if(direction != 0)
			MoveButtons ();
	}

	private void MoveButtons()
	{
		if ((startPosition - buttonsTransform.position.x) * direction <= (range - direction * (range - 150)) * direction)
		{
			buttonsTransform.Translate (startPosition - (1 - direction) * range - buttonsTransform.position.x, 0.0f, 0.0f);
			if (direction == 1)
			{
				CloseSetting ();
			}
			direction = 0;
		}
		else
		{
			buttonsTransform.Translate (direction * speed * Time.deltaTime, 0.0f, 0.0f);
		}
	}
}
