using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public int id;
    public string name;
    public Team team;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

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
