using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
	#region Characteristics

	public int CurrentHealth { get; private set; }
	public int MaxHealth { get; private set; }
	public string Name { get; private set; }

	#endregion

	private Transform enemyTransform;
	private float speed;

	private void Start()
	{
		speed = 5.0f;
		MaxHealth = 100;
		CurrentHealth = MaxHealth;
		Name = "Test Enemy <3";
		enemyTransform = GetComponent<Transform> ();
	}

	private void Update()
	{
		enemyTransform.Rotate (0.0f, 45.0f * Time.deltaTime, 0.0f);
		enemyTransform.Translate (Vector3.forward * Time.deltaTime * speed);
	}

	public void Hit(int damage)
	{
		CurrentHealth -= damage;
		if (CurrentHealth <= 0)
			Destroy (gameObject);
	}
}
