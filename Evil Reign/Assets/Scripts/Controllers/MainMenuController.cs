using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
	public GameObject settingsButtons;
	public Transform buttonsTransform;

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
		LoadNewGame ();
	}

	public void OnLoadGameButtonClicked()
	{
		// TODO 1. file list
		//		2. loading by choosing
	}

	public void OnSettingButtonClicked()
	{
		ShowSettings ();
		ShowWindow ();
	}

	public void OnExitButtonClicked()
	{
		// TODO 1. exit
	}

	public void OnCloseSettingsClicked()
	{
		CloseWindow ();
	}

	public void OnSaveSettingsClicked()
	{
		SaveSettings ();
		CloseWindow ();
	}

	public void OnCloseNewGameClicked()
	{
		LoadMainMenu ();
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
