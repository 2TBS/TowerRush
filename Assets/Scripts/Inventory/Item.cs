using UnityEngine;
using UnityEngine.UI;

///Base class for all Items; ID must be assigned manually
public class Item : MonoBehaviour {

public int id;

[HideInInspector] 
public int slot;
[HideInInspector]
public Sprite sprite;
[HideInInspector]
public Inventory inv;

	// Use this for initialization
	void Start () {
		sprite = GetComponentInChildren<Image>().sprite;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
