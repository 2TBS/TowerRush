using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Code for the entire main menu (EXCEPT Options)
public class MainMenu : MonoBehaviour {
	
	public Canvas homeScreen, options, joinRoom, creditsMenu, playPanel;
	public Dropdown optionDropdown;
	public Canvas general, controls;

	private int levelNumber;

	void Start () {

		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;

		Debug.Log("Started MainMenu, scene " + SceneManager.GetActiveScene().buildIndex);

		CloseSubmenu();
	}

	public void OpenOptions() {
		
		homeScreen.enabled = false;
		options.enabled = true;
		optionDropdown.value = 0;
		general.transform.rotation = new Quaternion (0.0f, 0.0f, 0.0f, 0.0f);
		general.enabled = true;
	}

	///Code for closing every submenu
	public void CloseSubmenu() {
		
		homeScreen.enabled = true;

		options.enabled = false;
		general.enabled = false;
		joinRoom.enabled = false;
		creditsMenu.enabled = false;
		playPanel.enabled = false;

	}

	///Quits the entire game
	public void Quit() {
		Application.Quit ();
	}
		
}
