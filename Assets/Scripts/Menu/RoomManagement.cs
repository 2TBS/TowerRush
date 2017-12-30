using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class RoomManagement : MonoBehaviour {

public Text usernameText, ipText, errorText;

protected string autofillPath;
protected string user, ip;

	// Use this for initialization
	void Start () {

		autofillPath = Vars.PATH + "/autofill.cfg";

		try {
			ipText.GetComponentInParent<InputField>().text = File.ReadAllLines(autofillPath)[0];
			usernameText.GetComponentInParent<InputField>().text = File.ReadAllLines(autofillPath)[1];
		} catch {
			Debug.LogWarning("autofill.cfg missing or corrupt.");
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//When the "Join" button is pressed (overload of LoadLevel(string ip, string user))
	public void LoadLevel(bool isCreating) {
		if(!isCreating)
			LoadLevel(ipText.text, usernameText.text);
		else {
			System.Diagnostics.Process.Start(Vars.PATH + "/server/startLocal.bat");
			LoadLevel("", "Host");
		}
	}

	///Loads a level as user from a given IP address
	public void LoadLevel(string ip, string user) {
		if(ip.Equals("")) ip = "localhost";
		if(user.Equals("")) user = "Player";

		PlayerPrefs.SetString("Username", user);

        Debug.Log("Attempting to connect to " + ip + " as " + user);
		try {
            SceneManager.LoadScene("TestMap");
		} catch {
			Popup.CreateError("Could not connect to " + ip + ". Please verify that the ip is correct.");
		}
	}
}
