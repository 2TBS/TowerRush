using UnityEngine;
using UnityEngine.SceneManagement;
using DarkRift;


public class ButtonActions : MonoBehaviour {

	Pl_GUI pgui;
	Pl_TeamManager pTM;
	
	[SerializeField]
	Transform playerTransform;


	void Start () {
		pgui = GetComponentInParent<Pl_GUI> ();
		pTM = GetComponentInParent<Pl_TeamManager> ();
	}
	
	public void QuitToMainMenu () {
        PhotonNetwork.LeaveRoom();
		SceneManager.LoadScene(0); //Load Main Menu
	}
	
	public void SwitchTeams () {
		pgui.SwitchTeams();
	}
	
	public void CloseTeamSelect () {
		pgui.CloseTeamSelect();
	}

	public void joinBlue()
    {
            Debug.Log("JOINING BLUE");
        	playerTransform.position = Vars.testMapBlue;
       		pTM.team = Vars.Team.blue;
        	CloseTeamSelect();
        	playerTransform.tag = "BluePlayer";
			pTM.Refresh();
    }

    public void joinGold()
    {
       
            Debug.Log("JOINING GOLD");
        	playerTransform.position = Vars.testMapGold;
       		pTM.team = Vars.Team.gold;
        	CloseTeamSelect();
        	playerTransform.tag = "GoldPlayer";
			pTM.Refresh();
    }

	public void StartGame()
	{
		GetComponentInParent<Pl_Controller>().roomlogic.StartGame();
	}
}
