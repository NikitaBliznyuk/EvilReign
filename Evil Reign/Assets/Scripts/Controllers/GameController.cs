using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController: MonoBehaviour 
{
	public GameObject GUI;
	public GameObject inventoryMenu;
	public GameObject pauseMenu;
	public GameObject healthBar;
	public GameObject energyBar;
	public GameObject infoBar;

	private bool menuEnabled = false;
	private Model model;

	private float showTime = 0.0f;
	private float maxShowTime = 1.5f;

	private GameObject healthImage;
	private GameObject energyImage;
	private GameObject playerCharacteristics;

	private EnemyController enemy = null;

	private void Start()
	{
		Debug.Log ("Hello");
		model = Model.Instance;
		healthImage = healthBar.GetComponent<Transform>().GetChild(0).gameObject;
		energyImage = energyBar.GetComponent<Transform>().GetChild(0).gameObject;
		playerCharacteristics = inventoryMenu.GetComponent<Transform> ().GetChild (3).gameObject;
		pauseMenu.SetActive (false);
		inventoryMenu.SetActive (false);
		infoBar.SetActive (false);
	}

	public void OnPauseMenuClicked()
	{
		DisableGUI ();
		pauseMenu.SetActive (menuEnabled);
	}

	private void DisableGUI()
	{
		GUI.SetActive (menuEnabled);
		model.SetPlayerMoveState (menuEnabled);
		menuEnabled = !menuEnabled;
	}

	public void OnInventoryMenuClicked ()
	{
		DisableGUI ();
		inventoryMenu.SetActive (menuEnabled);
	}

	public void OnExitToMainMenuClicked()
	{
		SceneManager.LoadScene (0);
	}

	public void OnExit()
	{
		Application.Quit ();
	}

	private void OnDestroy()
	{
		model.Dispose ();
	}

	private void Update()
	{
		UpdateInfoBar ();
		UpdateHealthBar ();
		UpdateEnergyBar ();
		UpdateInventory ();
	}

	private void UpdateInventory()
	{
		playerCharacteristics.GetComponent<Transform> ().GetChild (1).gameObject.GetComponent<Text> ().text = "Strength: " + model.GetPlayerCharacteristics ().Strength;
		playerCharacteristics.GetComponent<Transform> ().GetChild (2).gameObject.GetComponent<Text> ().text = "Agility: " + model.GetPlayerCharacteristics ().Agility;
		playerCharacteristics.GetComponent<Transform> ().GetChild (3).gameObject.GetComponent<Text> ().text = "Intelligence: " + model.GetPlayerCharacteristics ().Intelligence;
		playerCharacteristics.GetComponent<Transform> ().GetChild (4).gameObject.GetComponent<Text> ().text = "Luck: " + model.GetPlayerCharacteristics ().Luck;
		playerCharacteristics.GetComponent<Transform> ().GetChild (5).gameObject.GetComponent<Text> ().text = "Health: " + model.GetPlayerCharacteristics ().MaxHealth;
		playerCharacteristics.GetComponent<Transform> ().GetChild (6).gameObject.GetComponent<Text> ().text = "Energy: " + model.GetPlayerCharacteristics ().MaxEnergy;
	}

	private void UpdateHealthBar()
	{
		float size = (float) model.GetPlayerCharacteristics ().CurrentHealth / model.GetPlayerCharacteristics ().MaxHealth;
		healthImage.GetComponent<Transform> ().localScale = new Vector3 (size, 1, 1);
		healthBar.GetComponent<Transform> ().GetChild (1).gameObject.GetComponent<Text> ().text = model.GetPlayerCharacteristics ().CurrentHealth + "/" + model.GetPlayerCharacteristics ().MaxHealth;
	}

	private void UpdateEnergyBar()
	{
		float size = (float) model.GetPlayerCharacteristics ().CurrentEnergy / model.GetPlayerCharacteristics ().MaxEnergy;
		energyImage.GetComponent<Transform> ().localScale = new Vector3 (size, 1, 1);
		energyBar.GetComponent<Transform> ().GetChild (1).gameObject.GetComponent<Text> ().text = model.GetPlayerCharacteristics ().CurrentEnergy + "/" + model.GetPlayerCharacteristics ().MaxEnergy;
	}

	private void UpdateInfoBar()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 300.0f))
		{
			if (hit.collider.tag == "Enemy")
			{
				infoBar.SetActive (true);
				showTime = 0.0f;
				enemy = hit.collider.gameObject.GetComponent<EnemyController> ();
				float size = (float)enemy.CurrentHealth / enemy.MaxHealth;
				infoBar.GetComponent<Transform> ().GetChild (1).GetChild (0).localScale = new Vector3 (size, 1, 1);
				infoBar.GetComponent<Transform> ().GetChild (1).GetChild (1).gameObject.GetComponent<Text> ().text = enemy.CurrentHealth + "/" + enemy.MaxHealth;
				infoBar.GetComponent<Transform> ().GetChild (2).gameObject.GetComponent<Text> ().text = enemy.Name;
			}
		}
		/**
		 * For displaying 0 in health, when enemy died
		 * */
		if (enemy == null)
		{
			infoBar.GetComponent<Transform> ().GetChild (1).GetChild (0).localScale = new Vector3 (0, 1, 1);
			string text = infoBar.GetComponent<Transform> ().GetChild (1).GetChild (1).gameObject.GetComponent<Text> ().text;
			string enemyMaxHealth = text.Split (new char[]{'/'}, 2)[1];
			infoBar.GetComponent<Transform> ().GetChild (1).GetChild (1).gameObject.GetComponent<Text> ().text = 0 + "/" + enemyMaxHealth;			
		}
		if (showTime < maxShowTime && infoBar.activeSelf)
		{
			showTime += Time.deltaTime;
		}
		else
		{
			showTime = 0.0f;
			infoBar.SetActive (false);
		}
	}
}
