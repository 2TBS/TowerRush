using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

///Base class for Inventory: one required per player
public class Inventory : MonoBehaviour {

///complete list of inventory slots present in one inventory
public List<InvSlot> InvSlots;

///all items currently present in the inventory. Do not confuse with Vars.ITEMLIST
public List<Item> items;

///currently selected item (following mouse)
public Item selectedItem;

///What shows when an invSlot is empty
public Sprite EmptySprite;

///Enabled when an item is selected to be moved
public Image  mouseImage;

	// Use this for initialization
	void Start () {

		mouseImage.enabled = false;

		//find inventory slot buttons, and sorts them into a List based on numerical names
		foreach (InvSlot slot in GameObject.FindObjectsOfType<InvSlot>())
			InvSlots.Add(slot);	
		foreach(InvSlot slot in InvSlots) {
			int oldIndex = InvSlots.IndexOf(slot);
			int index = Int32.Parse(slot.name);
			InvSlot buffer = InvSlots[index];
			InvSlots[index] = slot;
			InvSlots[oldIndex] = buffer;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(mouseImage.enabled) {
			mouseImage.transform.position = Input.mousePosition;
			mouseImage.sprite = selectedItem.sprite;
		}	
	}

	///Accepts an item ID instead of the physical Item object (overload of PlaceItem(Item itm))
	public void PlaceItem(int itemId) {
		PlaceItem(CreateItem(itemId));
	}

	///Puts an Item into the first available item slot
	public void PlaceItem(Item itm) {
		int placed = 0;
		while(placed >= 0 && placed < InvSlots.Count) {
			if(!InvSlots[placed].hasItem) {
				InvSlots[placed].PutDownItem(itm);
				placed = -1;
			} else placed++;
		}

		if(placed > 0)
			Debug.Log("Could not pick up " + itm + ": no space!");
		else
			items.Add(itm);
	}

	///returns an Item based on its ID
	public Item CreateItem(int itemId) {
		foreach(Item itm in Vars.ITEM_LIST) 
			if(itm.id == itemId) return itm;
		
		throw new ArgumentException("Item " + itemId + " could not be found.");
	}
}
