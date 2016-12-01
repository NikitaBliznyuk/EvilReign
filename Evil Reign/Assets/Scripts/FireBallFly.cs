using UnityEngine;
using System.Collections;

public class FireBallFly : MonoBehaviour 
{
	private float speed = 20.0f;
	private int damage = 40;
	
	private void Update ()
	{
		GetComponent<Transform> ().Translate (Vector3.forward * speed * Time.deltaTime);
	}

	private void OnTriggerEnter(Collider collider)
	{
		if (collider.tag != "Player")
		{
			Destroy (gameObject);
		}
		if (collider.tag == "Enemy")
		{
			collider.gameObject.GetComponent<EnemyController>().Hit(damage);
		}
	}
}
