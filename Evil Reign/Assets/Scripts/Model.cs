using UnityEngine;
using System.Collections;

public class Model {

	private GameObject player;
	private static Model _instance;

	public static Model Instance
	{ 
		get
		{
			if (_instance == null) 
			{
				return _instance = new Model ();
			}
			else
			{
				return _instance;
			}
		}
	}

	public void Dispose()
	{
		_instance = null;
	}

	private Model()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	public Characteristics GetPlayerCharacteristics()
	{
		return player.GetComponent<PlayerController> ().PlayerCharacteristics;
	}

	public void SetPlayerMoveState(bool state)
	{
		player.GetComponent<PlayerController> ().EnableToMove = state;
	}
}
