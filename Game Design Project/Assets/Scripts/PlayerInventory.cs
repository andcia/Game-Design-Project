using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {

	int logsCollected = 0;

	public GameObject inventoryPanel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		inventoryPanel.SetActive(Input.GetKey(KeyCode.Escape));

	}
}
