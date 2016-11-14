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
		controller.LoadNewGame ();
	}

	public void OnLoadGameButtonClicked()
	{
		// TODO 1. file list
		//		2. loading by choosing
	}

	public void OnSettingButtonClicked()
	{
		controller.ShowSettings ();
		controller.ShowWindow ();
	}

	public void OnExitButtonClicked()
	{
		// TODO 1. exit
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

	public void OnCloseNewGameClicked()
	{
		controller.LoadMainMenu ();
	}

	private void Update()
	{
		controller.Update ();
	}
}
