using UnityEngine;
using System.Collections;

public class MainMenuView : MonoBehaviour {

	private MainMenuController controller;

	private void Start()
	{
		controller = new MainMenuController ();
	}

	public void OnNewGameButtonClicked()
	{
		Debug.Log ("New game");
	}

	public void OnLoadGameButtonClicked()
	{
		Debug.Log ("Load game");
		controller.ShowWindow ();
	}

	public void OnSettingButtonClicked()
	{
		Debug.Log ("Settings");
		controller.ShowWindow ();
	}

	public void OnExitButtonClicked()
	{
		Debug.Log ("Exit");
	}

	public void OnCloseSettingsClicked()
	{
		controller.CloseWindow ();
	}

	public void OnSaveSettingsClicked()
	{
		controller.SaveSettings ();
		controller.CloseWindow ();
	}

	private void Update()
	{
		controller.Update ();
	}
}
