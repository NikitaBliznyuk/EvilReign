using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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
		GetMenuObjects ();
	}

	private void GetMenuObjects()
	{
		buttonsTransform = GameObject.FindGameObjectWithTag ("Movable").GetComponent<Transform>();
		startPosition = buttonsTransform.position.x;
		direction = 0;
		speed = 4000.0f;
		range = Screen.width / 2;
		settingsButtons = GameObject.FindGameObjectWithTag ("Settings");
		settingsButtons.SetActive (false);
		settingsButtons.GetComponent<Transform> ().Translate (range * 2, 0.0f, 0.0f);
	}

	public void LoadNewGame()
	{
		SceneManager.LoadScene (1);
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

	private void DisableAllWindows()
	{
		CloseSetting ();
	}

	public void Update()
	{
		if(direction != 0)
			MoveButtons ();
	}

	public void LoadMainMenu ()
	{
		SceneManager.LoadScene (0);
	}

	private void MoveButtons()
	{
		if ((startPosition - buttonsTransform.position.x) * direction <= (range - direction * (range - 150)) * direction)
		{
			buttonsTransform.Translate (startPosition - (1 - direction) * range - buttonsTransform.position.x, 0.0f, 0.0f);
			if (direction == 1)
			{
				DisableAllWindows ();
			}
			direction = 0;
		}
		else
		{
			buttonsTransform.Translate (direction * speed * Time.deltaTime, 0.0f, 0.0f);
		}
	}
}
