using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Inventory : MonoBehaviour {

///complete list of inventory slots present in one inventory
public List<InvSlot> InvSlots;

///all items currently present in the inventory. Do not confuse with Vars.ITEMLIST
public List<Item> items;

///currently selected item (following mouse)
public Item selectedItem;
public bool itemSelected = false;

	// Use this for initialization
	void Start () {
		//find inventory slot buttons, and sorts them into a List based on numerical names
		foreach (GameObject slot in GameObject.FindGameObjectsWithTag("InventorySlot"))
			InvSlots.Add(slot.GetComponent<InvSlot> ());	
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
		if(itemSelected)
			selectedItem.transform.position = Input.mousePosition;
	}

	///Accepts an item ID instead of the physical Item object (overload of PlaceItem(Item itm))
	public void PlaceItem(int itemId) {
		PlaceItem(GetItem(itemId));
	}

	///Puts an Item into the first available item slot
	public void PlaceItem(Item itm) {
		int placed = 0;
		while(placed >= 0) {
			if(!InvSlots[placed].hasItem)
				InvSlots[placed].currentItem = itm;
		}
	}

	///returns an Item based on its ID
	public Item GetItem(int itemId) {
		foreach(Item itm in items) 
			if(itm.id == itemId) return itm;
		
		throw new ArgumentException("Item " + itemId + "could not be found.");

	}

}
