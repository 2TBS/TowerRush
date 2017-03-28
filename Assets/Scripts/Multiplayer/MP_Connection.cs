using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MP_Connection : MonoBehaviour {

    public string networkVersion;

    public Text connectionText;
    public Text roomName;
    public Text playerName;

    public Text roomNameC;
    public Text playerNameC;


    void Start () {
        if (!PhotonNetwork.connected)
            PhotonNetwork.ConnectUsingSettings(networkVersion);
        else
            Debug.Log("Already Connected");
        
    }
	
	// Update is called once per frame
	void Update () {
        connectionText.text = PhotonNetwork.connectionState.ToString();
	}

    public void joinRoom()
    {
        string player = playerName.text;
        string name = roomName.text;

        PhotonNetwork.playerName = player;
        PhotonNetwork.JoinRoom(name);
        
    }
    
    public void createRoom()
    {
        if(roomNameC.text.Equals(null) || roomNameC.text.Equals(""))
        {
            return;
        }

        if (playerNameC.text.Equals(null) || playerNameC.text.Equals(""))
        {
            return;
        }

        PhotonNetwork.playerName = playerNameC.text;
        PhotonNetwork.CreateRoom(roomNameC.text);
    }


 
    void OnJoinedRoom()
    {
        Debug.Log("Joined Room");
        PhotonNetwork.isMessageQueueRunning = false;
        SceneManager.LoadScene("TestMap");
    }
    



}
