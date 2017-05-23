﻿using UnityEngine;
using System.Collections;

public class envirnmentControlScript : MonoBehaviour {

	// World Game Objects
	GameObject inventory;
	GameObject player;

	// Inventory
	bool isInvOpen = false;

	// In game Quantitty
	int treeNum;

	// Polution Persenages
	float airPers = 100;
	float waterPers = 100;

	// Trash hold
	float trashHold = 75;
	// Degradation Speed
	float degrade = 5;
	// Total Environment Health ---*
	//float envHealth = 100;

	// Use this for initialization
	void Awake () {
		// Find Player
		player = GameObject.FindGameObjectWithTag ("Player");
		// Find Inventory
		inventory = GameObject.FindGameObjectWithTag ("Inv");
		// Set Player for Inventory
//		inventory.GetComponent<inventoryScripts>().SetPlayer = player;
		// Turn Off Inventory
		inventory.SetActive (false);
		// Update Envirnment
		EnvRefresh ();
	}
	
	// Update is called once per frame
	void Update () {
		CheckKeysInv ();
	}

	//Refresh Envirnment
	void EnvRefresh(bool reSpawnTrees = false){
		// Find all trees
		treeNum = GameObject.FindGameObjectsWithTag("Tree").Length;
		// Polution Persenages
		airPers = 100;
		waterPers = 100;

		// Total Environment Health ---*
		//envHealth = 100;

		// espawn All trees if True
		if(reSpawnTrees){
			//--------------------------------------------
		}
	}

	// Add or remove Tree
	public void TreeAddRemove(bool isAdd = true){
		// Adds a tree to total number of trees
		if (isAdd) {
			treeNum += 1;
		} 
		// Removes a tree from total number
		else {
			treeNum -= 1;
		}
	}

	// Get World Objects -- This is to avoid searching with tags
	// Get Inventory
	public GameObject GetInventory{
		get{ return inventory;}
	}

	// Get Player
	public GameObject GetPlayer{
		get{ return player;}
	}
		

	/* Determin tree polution filtering
	 * Filter will ocure during Day time every one minute resulting 10 times per day
	 * The more the trees the moreb effective the filtering
	 * if air is not poluted do not filter
	 * If air is poluted filter
	 * 
	 * NOTES: burning a fire each night with all trees should not exceed trash hold.
	 *  - May also include metal
	 *  - Tools like axe for trees and hammer for house building
	 * 
	 * If trashHold is exceeded - Poluted air will effect water
	 * Water will be less efective when drinking.
	 * Fruit will be less effective.
	 * Trees will grow Slower.
	 * */

	// Controls _____________________
	//Check for Keys
	void CheckKeysInv(){
		// Check for key
		if (Input.GetKeyDown(KeyCode.Space)) {
			if (isInvOpen) {
				isInvOpen = false;
			}
			else {
				isInvOpen = true;
			}
			// pen Close Inventory
			inventory.SetActive(isInvOpen);
			// Lock or release player if inventory is open or closed
			player.GetComponent<PlayerControl> ().SetInventoryOpen = isInvOpen;
		}
			
	}
}
