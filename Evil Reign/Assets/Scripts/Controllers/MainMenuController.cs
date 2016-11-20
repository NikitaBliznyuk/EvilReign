using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
	public GameObject settingsButtons;
	public Transform buttonsTransform;

	// <--- (-1)     (0)     (1)--->
	private int direction;
	private float speed;
	private float startPosition;
	private float range;

	private void Start()
	{
		GetMenuObjects ();
	}

	public void OnNewGameButtonClicked()
	{
		SceneManager.LoadScene (1);
	}

	public void OnLoadGameButtonClicked()
	{
		// TODO 1. file list
		//		2. loading by choosing
	}

	public void OnSettingButtonClicked()
	{
		settingsButtons.SetActive (true);
		direction = -1; // left direction
	}

	public void OnExitButtonClicked()
	{
		// TODO 1. exit
	}

	public void OnCloseSettingsClicked()
	{
		direction = 1;
	}

	public void OnSaveSettingsClicked()
	{
		// TODO save settings
		direction = 1;
	}

	private void GetMenuObjects()
	{
		startPosition = buttonsTransform.position.x;
		direction = 0;
		speed = 4000.0f;
		range = Screen.width / 2;
		settingsButtons.SetActive (false);
		settingsButtons.GetComponent<Transform> ().Translate (range * 2, 0.0f, 0.0f);
	}

	private void DisableAllWindows()
	{
		settingsButtons.SetActive (false);
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
