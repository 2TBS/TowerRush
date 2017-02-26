using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

///Button action for inventory slot
public class InvSlot : MonoBehaviour {

	public int id;
	public Item currentItem;
	public Inventory inv;
	public bool hasItem = false, spriteEmpty = true;
	public Image itemSprite;

	// Use this for initialization
	void Start () {
		id = Int32.Parse(name);
		
		itemSprite = GetComponentsInChildren<Image> ()[1]; 
		inv = GetComponentInParent<Inventory>();
		itemSprite.sprite = inv.EmptySprite;
		itemSprite.enabled = true;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	///Changes sprite to empty sprite if spriteEmpty == true
	void ToggleEmpty () {
		spriteEmpty = !spriteEmpty;
		itemSprite.sprite = (spriteEmpty) ? inv.EmptySprite : currentItem.sprite;
	}

	///Selects a method from below to run 
	public void ClickAction () {
		if(inv.mouseImage.enabled && !hasItem) PutDownItem();
		else if(inv.mouseImage.enabled && hasItem) SwapItem();
		else if(!inv.mouseImage.enabled && hasItem) SelectItem();
	}

	///Used by Inventory when items are picked up 
	public void PutDownItem(Item itm) {
		
		hasItem = true;
		currentItem = itm;
		itm.inv = inv;
		ToggleEmpty();
		Debug.Log("Placed " + itm + " in slot " + id);
	}


	///When no items are selected and there is an item in the slot
	void SelectItem () {
		inv.mouseImage.enabled = true;
		inv.selectedItem = currentItem;
		hasItem = false;
		ToggleEmpty();
	}

	///When an item is selected and there are no items in the slot
	void PutDownItem() {
		inv.mouseImage.enabled = false;
		currentItem = inv.selectedItem;
		hasItem = true;
		ToggleEmpty();
	}


	///When item is selected and there is an item in the slot
	void SwapItem() {
		Item buffer = inv.selectedItem;
		SelectItem();
		currentItem = buffer;
		inv.selectedItem = buffer;
		itemSprite.sprite = currentItem.sprite;
	}
}
