using UnityEngine;
using System;
using UnityEngine.UI;

///Required code for every inventory slot within an Inventory
public class InvSlot : MonoBehaviour {

	///Index within the array of inventory slots for this Inventory
	public int id;

	///Item being stored in this inventory slot
	public Item currentItem; 

	///inventory this itemslot belongs to
	public Inventory inv; 

	///Returns true if inventory slot contains an item
	public bool hasItem = false;

	///Child image of inventory slot
	public Image itemSprite;

	void Start () {
		id = Int32.Parse(name);
		
		itemSprite = GetComponentsInChildren<Image> ()[1]; 
		inv = GetComponentInParent<Inventory>();
		itemSprite.sprite = inv.EmptySprite;
		itemSprite.enabled = true;
		
	}

	///Changes sprite to empty sprite if spriteEmpty == true
	void ToggleEmpty () {
		hasItem = !hasItem;
		itemSprite.sprite = (hasItem) ? currentItem.sprite : inv.EmptySprite;
	}

	///Selects a method from below to run 
	public void ClickAction () {
		if(inv.mouseImage.enabled && !hasItem) PutDownItem();
		else if(inv.mouseImage.enabled && hasItem) SwapItem();
		else if(!inv.mouseImage.enabled && hasItem) SelectItem();
	}

	///Used by Inventory when items are picked up 
	public void PutDownItem(Item itm) {
		currentItem = itm;
		itm.inv = inv;
		ToggleEmpty();
		Debug.Log("Placed " + itm + " in slot " + id);
	}


	///When no items are selected and there is an item in the slot
	void SelectItem () {
		inv.mouseImage.enabled = true;
		inv.selectedItem = currentItem;
		ToggleEmpty();
	}

	///When an item is selected and there are no items in the slot
	void PutDownItem() {
		inv.mouseImage.enabled = false;
		currentItem = inv.selectedItem;
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
