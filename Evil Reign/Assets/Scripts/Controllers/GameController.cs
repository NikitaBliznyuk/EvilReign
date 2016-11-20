using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController: MonoBehaviour 
{
	public GameObject GUI;
	public GameObject inventoryMenu;
	public GameObject pauseMenu;
	public GameObject healthBar;
	public GameObject energyBar;

	private bool menuEnabled = false;
	private Model model;

	private void Start()
	{
		model = Model.Instance;
		pauseMenu.SetActive (false);
	}

	public void OnPauseMenuClicked()
	{
		GUI.SetActive (menuEnabled);
		pauseMenu.SetActive (!menuEnabled);
		model.SetPlayerMoveState (menuEnabled);
		menuEnabled = !menuEnabled;
	}

	public void OnInventoryMenuClicked ()
	{
		
	}

	public void OnExitToMainMenuClicked()
	{
		SceneManager.LoadScene (0);
	}

	private void OnDestroy()
	{
		model.Dispose ();
	}

	private void Update()
	{
		UpdateHealthBar ();
		UpdateEnergyBar ();
	}

	private void UpdateHealthBar()
	{
		float size = (float) model.GetPlayerCharacteristics ().CurrentHealth / model.GetPlayerCharacteristics ().MaxHealth;
		healthBar.GetComponent<Transform> ().localScale = new Vector3 (size, 1, 1);
	}

	private void UpdateEnergyBar()
	{
		float size = (float) model.GetPlayerCharacteristics ().CurrentEnergy / model.GetPlayerCharacteristics ().MaxEnergy;
		energyBar.GetComponent<Transform> ().localScale = new Vector3 (size, 1, 1);
	}
}
