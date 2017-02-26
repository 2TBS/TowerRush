using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour {

public int id, slot;
public bool selected = false;
public Sprite sprite;
protected Vector3 mousePosition;

public Inventory inv;

	// Use this for initialization
	void Start () {
		sprite = GetComponentInChildren<Image>().sprite;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
