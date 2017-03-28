using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pl_TeamManager : MonoBehaviour {

	public Vars.Team team;
	SkinnedMeshRenderer mesh;

	public Material[] goldMat, blueMat;

	// Use this for initialization
	void Start () {
		mesh = GetComponentInChildren<SkinnedMeshRenderer>();
		Refresh();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Refresh() {

		foreach(Pl_TeamManager tm in Resources.FindObjectsOfTypeAll(typeof (Pl_TeamManager)))
			tm.mesh.materials = (team == Vars.Team.gold) ? goldMat : blueMat;
	}
}
