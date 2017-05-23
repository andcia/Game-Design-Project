using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollowScript : MonoBehaviour
{

	public GameObject player;
	Vector3 payerPos = new Vector3();
	Vector3 camPos = new Vector3();
	float dist;

	// Use this for initialization
	void Start()
	{
		camPos = gameObject.transform.position;
		payerPos = player.transform.position;
		dist = payerPos[2] - gameObject.transform.position.z;
	}

	// Update is called once per frame
	void Update()
	{
		payerPos = player.transform.position;

		gameObject.transform.position = new Vector3(payerPos[0], camPos[1], payerPos[2] - dist);

		//Change  background colour Day/night (10 mins)
		Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor, Color.black, Time.deltaTime / 10);
	}
}
