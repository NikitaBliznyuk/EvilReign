using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
	public Transform playerTransform;

	private Vector3 offset;
	private Transform cameraTransform;

	void Start () 
	{
		cameraTransform = GetComponent<Transform> ();
		offset = cameraTransform.position - playerTransform.position;
	}

	void LateUpdate () {
		cameraTransform.position = playerTransform.position + offset;
	}
}
