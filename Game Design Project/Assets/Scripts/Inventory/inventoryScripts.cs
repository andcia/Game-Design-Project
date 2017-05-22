// John Scerri 12/5/17
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryScripts : MonoBehaviour {

	// PLayer
	GameObject player;

	// Amount of items in inventory
	int[] itemCount = new int[3]{0,0,0};

	// Sprites
	// Item List: 0 = logs, 1 = fruit, 2 =  water
	GameObject[] itemList = new GameObject[3];
	public Sprite[] activeSpr = new Sprite[3];
	public Sprite[] inactiveSpr = new Sprite[3];
	public GameObject selectionFrame;

	// Current selected Item
	int curSelected = 0;

	// Use this for initialization
	void Awake () {
        // populate Item List
        itemList[0] = gameObject.transform.GetChild(1).gameObject; // Log
        itemList[1] = gameObject.transform.GetChild(2).gameObject; // Fruit
        itemList[2] = gameObject.transform.GetChild(3).gameObject; // Water
        // Move Slection on first item
        MoveSelection();
		// Set sprites to inactive
		itemList[0].GetComponent<Image>().sprite = inactiveSpr[0];
		itemList[1].GetComponent<Image>().sprite = inactiveSpr[1];
		itemList[2].GetComponent<Image>().sprite = inactiveSpr[2];
	}
	
	// Update is called once per frame
	void Update () {
		ScrollItems ();
	}

	// Add Item on pickup
	public void AddItem(int num, int fill){
		// num = The position in list
		// fill = The amount to add

		// Chekc if list is empty
		if(itemCount[num] == 0){
			// change Sprite sprite
			itemList[num].GetComponent<Image>().sprite = activeSpr[num];
			// Add count
			AddRemoveCount(num, fill);
		}
		// else if already filled
		else{
			// Add count
			AddRemoveCount(num, fill);
		}
	}

	// Remove item on use
	public void RemoveItem(int num, int fill){
		int newAmount = itemCount [num] - fill;

		// If amount removed is smaller then 0
		// Do not allow action ------------------------------------------------- ****
		if (newAmount < 0) {
			
		}
		// If newAmount = 0, then  deactivate icon
		else if (newAmount == 0) {
			itemList [num].GetComponent<Image> ().sprite = inactiveSpr [num];
		}
		// Else update amount
		else{
			AddRemoveCount (num, newAmount, false);
		}
	}


	// Add remove Count
	void AddRemoveCount(int num, int fill, bool isAdd = true){
		int action = 1;
		// Change to negative if remove item
		if (!isAdd) {
			action = -1;
		}
		// Update
		itemCount[num] += (action * fill);
        // Update on Screen Text
        itemList[num].transform.GetChild(0).gameObject.GetComponent<Text>().text = "" + itemCount[num];

	}

	void ScrollItems(){
		if (Input.GetKeyDown (KeyCode.A)) {
			curSelected += 1;
			CleanSelection (true);
		} 
		else if (Input.GetKeyDown(KeyCode.D)){
			curSelected -= 1;
			CleanSelection (false);
		}
		// Update Selection
		MoveSelection();
	}

	// If election ecxeeds lenght of array or is smaller then 0 is looped 
	void CleanSelection(bool isPos){
		// I selection is incersing
		if (isPos) {
			if (curSelected > itemList.Length - 1) {
				curSelected = 0;
			}
		}

		// else if selection is decreasing
		else {
			if (curSelected < 0) {
				curSelected = itemList.Length - 1;
			}
		}
	}

	// Move Selection Frame
	void MoveSelection(){
		// Set selection frame
		selectionFrame.transform.position = itemList[curSelected].transform.position;
	}

    // Set Player
	public GameObject SetPlayer{
		set{ player = value;}
	}
}
