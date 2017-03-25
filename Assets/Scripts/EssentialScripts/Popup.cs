using UnityEngine;
using UnityEngine.UI;

///Creates a popup with a message and a button.
///Call this class using its static reference Popup.method()
public class Popup : MonoBehaviour {

static Text header, content, popupButtonText;

static Canvas panel;

	void Start() {
		panel = GetComponent<Canvas> ();
		header = GameObject.Find("Header").GetComponent<Text>();
		content = GameObject.Find("Message").GetComponent<Text>();
		popupButtonText = GameObject.Find("PopupButtonText").GetComponent<Text>();
		panel.enabled = false;
	}

	///sets default foreground color (black), default buttonText (ok)
	public static void CreatePopup(string title, string text, Color bgColor) {
		CreatePopup(title, text, "OK", bgColor, Color.black);
	}

	///preset for error message popups
	public static void CreateError(string text) {
		CreatePopup("Error :|", text, "Close", Color.red, Color.white);
		Debug.LogError("Error: " + text);
	}

	///master method containing all possible arguments
	public static void CreatePopup(string title, string text, string buttonText, Color bgColor, Color fgColor) {
		panel.GetComponent<Image>().color = bgColor;
		header.color = content.color = popupButtonText.color = fgColor;
		header.text = title;
		content.text = text;
		popupButtonText.text = buttonText;
		panel.enabled = true;
	}
}
