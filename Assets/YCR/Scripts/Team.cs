using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Team : MonoBehaviour {

    public int id;
    public string name;
    public int score;
    public List<Player> players = new List<Player>();

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

    public int getScore() {
        return this.score;
    }

    /*SETTERS*/

    public void setId(int newId) {
        this.id = newId;
    }

    public void setName(string newName) {
        this.name = newName;
    }

    public void setScore(int newScore) {
        this.score = newScore;
    }



    public void addPlayer(Player newPlayer) {
        players.Add(newPlayer);

        //Add it to current game players
        Game.addPlayer(newPlayer);
    }

    public Player getPlayerById(int id) {
        foreach (Player player in players) {
            if (player.id == id)
                return player;
        }
        return null;
    }

    public Player getPlayerByName(string name) {
        foreach (Player player in players) {
            if (player.name == name)
                return player;
        }
        return null;
    }

    public void listPlayers() {
        Debug.Log("Players in team '" + this.name + "':");
        foreach (Player player in players) {
            Debug.Log(player.id + ": " + player.name);
        }
    }
}
