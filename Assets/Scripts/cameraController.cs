using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
	public GameObject player;
	public float speed = 5.0f;

	private Vector3 offset;
	private float inputX;
	private float inputZ;

	// Use this for initialization
	void Start()
	{
		offset = transform.position - player.transform.position;
	}

	// Update is called once per frame
	void LateUpdate()
	{
		transform.position = player.transform.position + offset;
	}
}
