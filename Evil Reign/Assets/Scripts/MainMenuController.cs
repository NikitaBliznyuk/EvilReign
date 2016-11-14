using UnityEngine;
using System.Collections;

public class MainMenuController 
{
	private Transform buttonsTransform;
	private Transform settingsButtonsTransform;
	private int direction;
	private float speed;
	private float startPosition;
	private float range;

	public MainMenuController()
	{
		GameObject[] list = GameObject.FindGameObjectsWithTag ("Movable");
		buttonsTransform = list [0].GetComponent<Transform>();
		settingsButtonsTransform = list [1].GetComponent<Transform>();
		direction = 0;
		speed = 4000.0f;
		range = Screen.width / 2;
		startPosition = buttonsTransform.position.x;
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
		Debug.Log ("start buttons: " + buttonsTransform.position.x + ", settings: " + settingsButtonsTransform.position.x);
		if(direction != 0)
			MoveButtons ();
	}

	private void MoveButtons()
	{
		if ((startPosition - buttonsTransform.position.x) * direction <= (range - direction * (range - 150)) * direction)
		{
			buttonsTransform.Translate (startPosition - (1 - direction) * range - buttonsTransform.position.x, 0.0f, 0.0f);
			settingsButtonsTransform.Translate (buttonsTransform.position.x + range * 2 - settingsButtonsTransform.position.x, 0.0f, 0.0f);
			direction = 0;
		}
		else
		{
			buttonsTransform.Translate (direction * speed * Time.deltaTime, 0.0f, 0.0f);
			settingsButtonsTransform.Translate (direction * speed * Time.deltaTime, 0.0f, 0.0f);
		}
	}
}
