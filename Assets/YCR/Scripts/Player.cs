using UnityEngine;
using System.Collections;
using ExitGames.Client.Photon;

public class Player : Photon.MonoBehaviour {

	public int id;
	public string name;
	public Team team;
	public Color color;
	public string message;

	static int winId = -1;
	static Rect windowRect = new Rect(10, 250, 150, 100);

	// Use this for initialization
	void Start () {

		// --tmp--
		Debug.Log("Hello I joined");
		this.setId((int) Mathf.Round(Random.value * 10000));
		this.setName("anonymous" + this.getId());
		this.setColor(HSBColor.ToColor(new HSBColor(Random.value, 1f, 1f)));
		// -------

		Game.addPlayer(this);
	}

	// Update is called once per frame
	void Update () {
		if (photonView.isMine) {
			this.setMessage(GameChat.inputLine);
		}

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

	public string getMessage() {
		return this.message;
	}

	/*SETTERS*/
	public void setId(int id) {
		this.id = id;
	}

	public void setName(string name) {
		this.name = name;
	}

	public void setTeam(Team team) {
		this.team = team;
	}

	public void setMessage(string message) {
		this.message = message;
	}


	public Color setColor(Color color) {
		this.transform.Find("robot_head").renderer.materials[1].color = color;
		this.transform.Find("robot_body").renderer.materials[1].color = color;
		this.transform.Find("trail").renderer.material.color = color;
		return this.color = color;
	}
}
