using UnityEngine;
using System.Collections;
using ExitGames.Client.Photon;

public class Player : MonoBehaviour {

	public int id;
	public string name;
	public Team team;

	static int winId = -1;
	static Rect windowRect = new Rect(50, 50, 200, 300);

	// Use this for initialization
	void Start () {

		// --tmp--
		Debug.Log("Hello I joined");
		this.id = (int) Mathf.Round(Random.value * 10000);
		this.name = "anonymous";
		// -------

		Game.addPlayer(this);
	}

	// Update is called once per frame
	void Update () {

	}

	/*PLAYER INFOS INTERFACE*/
	void OnMouseUp () {
		winId = winId != this.id ? this.id : -1;
	}

	void OnGUI () {
		if (winId == this.id)
			windowRect = GUILayout.Window(1, windowRect, displayWindow, "Player: " + this.id);
	}

	void displayWindow(int windowID) {
		GUI.DragWindow(new Rect(0, 0, 10000, 20));
		GUILayout.Label("Id: " + this.id);
		GUILayout.Label("Name: " + this.name);
	}

	void OnLeftRoom () {
		Game.removePlayer(this);
	}

	/*GETTERS*/
	public int getId() {
		return this.id;
	}

	public string getName() {
		return this.name;
	}

	public Team getTeam() {
		return this.team;
	}

	/*SETTERS*/
	public void setId(int newId) {
		this.id = newId;
	}

	public void setName(string newName) {
		this.name = newName;
	}

	public void setTeam(Team newTeam) {
		this.team = newTeam;
	}
}
