using UnityEngine;
using System.Collections.Generic;

///File containing all global variables. All variables accessible through Vars.[varname]
public class Vars : MonoBehaviour {

	//Coordinates for TestMap (index 1)
	public static Vector3 testMapBlue = new Vector3(0,4,-281);
	public static Vector3 testMapGold = new Vector3(0,3,134);

	///Coordinates for lobby
	public static Vector3 lobby = new Vector3(0,0,0);
	
	///Possible teams a player can join
	public enum Team {blue, gold};

	///alias of Application.dataPath
	public static readonly string PATH = Application.dataPath;

	///Default button color for all UI elements
	public static Color BUTTON_COLOR = new Color(162, 255, 255, 138);

	///All usable items
	public static Object[] ITEM_LIST = Resources.LoadAll("", typeof(Item));

}
