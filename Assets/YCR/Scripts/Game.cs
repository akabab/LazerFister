using UnityEngine;
using System.Collections;
using System.Collections.Generic; //Needed for namespace 'List'

// ---- GAME MANAGER ----
// Contains a reference to active game important elements:
//  + Teams
//  + Players
//  + Time
//  + Score
// ----------------------

public class Game : MonoBehaviour {

    public static List<Team> teams = new List<Team>();
    public static List<Player> players = new List<Player>();

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

    void OnJoinedRoom() {
        Debug.Log("Hello");
    }

    public static void addPlayer(Player newPlayer) {
        players.Add(newPlayer);
    }

    public static Player getPlayerById(int id) {
        foreach (Player player in players) {
            if (player.id == id)
                return player;
        }
        return null;
    }

    public static void listPlayers() {
        Debug.Log("Players in game: ");
        foreach (Player player in players) {
            Debug.Log(player.id + ": " + player.name);
        }
    }

    public static Player getPlayerByName(string name) {
        foreach (Player player in players) {
            if (player.name == name)
                return player;
        }
        return null;
    }
}
